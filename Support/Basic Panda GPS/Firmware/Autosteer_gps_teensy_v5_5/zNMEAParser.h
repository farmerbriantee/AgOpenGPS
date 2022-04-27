/*
   NMEA parser library for Arduino

   Simple and compact NMEA parser designed for Arduino

   Author : Glinnes Hulden

   This work is distributed under license CC0.
   Check https://creativecommons.org/publicdomain/zero/1.0/deed.en

   No Copyright

   The person who associated a work with this deed has dedicated the work
   to the public domain by waiving all of his or her rights to the work
   worldwide under copyright law, including all related and neighboring rights,
   to the extent allowed by law.

   You can copy, modify, distribute and perform the work, even for commercial
   purposes, all without asking permission. See Other Information below.

   Other Information

   In no way are the patent or trademark rights of any person affected by CC0,
   nor are the rights that other persons may have in the work or in how the
   work is used, such as publicity or privacy rights.
   Unless expressly stated otherwise, the person who associated a work with
   this deed makes no warranties about the work, and disclaims liability for
   all uses of the work, to the fullest extent permitted by applicable law.
   When using or citing the work, you should not imply endorsement by the
   author or the affirmer.
*/

#ifndef __NMEAParser_h__
#define __NMEAParser_h__

#include <Arduino.h>

namespace NMEA {
/*
   Error codes
*/
typedef enum {
  NO_ERROR,
  UNEXPECTED_CHAR,
  BUFFER_FULL,
  TYPE_TOO_LONG,
  CRC_ERROR,
  INTERNAL_ERROR
} ErrorCode;
}

/*
   The library consists of a single template: NMEAParser.
*/
template <size_t S> class NMEAParser {

  private:
    typedef void (*NMEAErrorHandler)(void);
    typedef void (*NMEAHandler)(void);
    typedef struct {
      char mToken[6];
      NMEAHandler mHandler;
    } NMEAHandlerEntry;
    typedef enum { INIT, SENT, ARG, CRCH, CRCL, CRLFCR, CRLFLF } State;
  public:
    /*
       maximum sentence size is 82 including the starting '$' and the <cr><lf>
       at the end. Since '$', the '*', the 2 characters CRC and the <cr><lf>
       are not bufferized, 82 - 6 + 1 = 77 chars  are enough.
       is enough.
    */
    static const uint8_t kSentenceMaxSize = 90;

  private:
    /*
       buffer to store the NMEA sentence excluding starting '$', the ','
       separator, the '*', the CRC and the <cr><lf>. The tail of the buffer
       is used to store the index of the arguments.
    */
    char mBuffer[kSentenceMaxSize];

    /*
       Current index to store a char of the sentence
    */
    uint8_t mIndex;

    /*
       Current index to store the index of an argument
    */
    uint8_t mArgIndex;

    /*
       A handler to notify a malformed sentence
    */
    NMEAErrorHandler mErrorHandler;

    /*
       A handler for well formed but unrecognized sentences
    */
    NMEAHandler mDefaultHandler;

    /*
       An array of NMEA handler : pointers to functions to call when a sentence
       is recognized
    */
    NMEAHandlerEntry mHandlers[S];

    /*
       The current number of mHandlers
    */
    uint8_t mHandlerCount;

    /*
       Parsing automaton variable
    */
    State mState;

    /*
       mError
    */
    NMEA::ErrorCode mError;

    /*
       True if CRC is handled, false otherwise. Defaults to true
    */
    bool mHandleCRC;

    /*
       Variables used to computed and parse the CRC
    */
    uint8_t mComputedCRC;
    uint8_t mGotCRC;

    /*
       NMEAParserStringify is used internally to temporarely replace a char
       in the buffer by a '\0' so that libc string functions may be used.
       Instantiating a NMEAParserStringify object in a pair of {} defines
       a section in which the 'stringification' is done : the constructor
       does that according to the arguments and se destructor restore the buffer.
    */
    class NMEAParserStringify {
        uint8_t       mPos;
        char          mTmp;
        NMEAParser<S> *mParent;
      public:
        NMEAParserStringify(NMEAParser<S> *inParent, uint8_t inPos) :
          mPos(inPos),
          mParent(inParent)
        {
          mTmp = mParent->mBuffer[mPos];
          mParent->mBuffer[mPos] = '\0';
        }
        ~NMEAParserStringify()
        {
          mParent->mBuffer[mPos] = mTmp;
        }
    };

    /*
       Call the error handler if defined
    */
    void callErrorHandler(void)
    {
      if (mErrorHandler != NULL) {
        mErrorHandler();
      }
    }

    /*
       Called when the parser encounter a char that should not be there
    */
    void unexpectedChar()
    {
      mError = NMEA::UNEXPECTED_CHAR;
      callErrorHandler();
      reset();
    }

    /*
       Called when the buffer is full because of a malformed sentence
    */
    void bufferFull()
    {
      mError = NMEA::BUFFER_FULL;
      callErrorHandler();
      reset();
    }

    /*
       Called when the type of the sentence is longer than 5 characters
    */
    void typeTooLong()
    {
      mError = NMEA::TYPE_TOO_LONG;
      callErrorHandler();
      reset();
    }
    /*
       Called when the CRC is wrong
    */
    void crcError()
    {
      mError = NMEA::CRC_ERROR;
      callErrorHandler();
      reset();
    }

    /*
       Called when the state of the parser is not ok
    */
    void internalError()
    {
      mError = NMEA::INTERNAL_ERROR;
      callErrorHandler();
      reset();
    }

    /*
       retuns true is there is at least one byte left in the buffer
    */
    bool spaceAvail()
    {
      return (mIndex < mArgIndex);
    }

    /*
       convert a one hex digit char into an int. Used for the CRC
    */
    static int8_t hexToNum(const char inChar)
    {
      if (isdigit(inChar)) return inChar - '0';
      else if (isupper(inChar) && inChar <= 'F') return inChar - 'A' + 10;
      else if (islower(inChar) && inChar <= 'f') return inChar - 'a' + 10;
      else return -1;
    }

    static bool strnwcmp(const char *s1, const char *s2, uint8_t len)
    {
      while (len-- > 0) {
        if (*s1 != *s2 && *s1 != '-' && *s2 != '-') return false;
        s1++;
        s2++;
      }
      return true;
    }

    /*
       return the slot number for a handler. -1 if not found
    */
    int8_t getHandler(const char *inToken)
    {
      /* Look for the token */
      for (uint8_t i = 0; i < mHandlerCount; i++) {
        if (strnwcmp(mHandlers[i].mToken, inToken, 5)) {
          return i;
        }
      }
      return -1;
    }

    /*
       When all the sentence has been parsed, process it by calling the handler
    */
    void processSentence()
    {
      /* Look for the token */
      uint8_t endPos = startArgPos(0);
      int8_t slot;
      {
        NMEAParserStringify stfy(this, endPos);
        slot = getHandler(mBuffer);
      }
      if (slot != -1) {
        mHandlers[slot].mHandler();
      }
      else {
        if (mDefaultHandler != NULL) {
          mDefaultHandler();
        }
      }
    }

    /*
       Return true if inArgNum corresponds to an actual argument
    */
    bool validArgNum(uint8_t inArgNum)
    {
      return inArgNum < (kSentenceMaxSize - mArgIndex);
    }

    /*
       Return the start index of the inArgNum th argument
    */
    uint8_t startArgPos(uint8_t inArgNum)
    {
      return mBuffer[kSentenceMaxSize - 1 - inArgNum];
    }

    /*
       Return the end index of the inArgNum th argument
    */
    uint8_t endArgPos(uint8_t inArgNum)
    {
      return mBuffer[kSentenceMaxSize - 2 - inArgNum];
    }

  public:
    /*
       Constructor initialize the parser.
    */
    NMEAParser() :
      mErrorHandler(NULL),
      mDefaultHandler(NULL),
      mHandlerCount(0),
      mError(NMEA::NO_ERROR),
      mHandleCRC(true),
      mComputedCRC(0),
      mGotCRC(0)
    {
      reset();
    }

    /*
      Reset the parser
    */
    void reset() {
      mState = INIT;
      mIndex = 0;
      mArgIndex = kSentenceMaxSize;
      mError = NMEA::NO_ERROR;
    }

    /*
       Add a sentence handler
    */
    void addHandler(const char *inToken, NMEAHandler inHandler)
    {
      if (mHandlerCount < S) {
        if (getHandler(inToken) == -1) {
          strncpy(mHandlers[mHandlerCount].mToken, inToken, 5);
          mHandlers[mHandlerCount].mToken[5] = '\0';
          mHandlers[mHandlerCount].mHandler = inHandler;
          mHandlerCount++;
        }
      }
    }

#ifdef __AVR__
    /*
       Add a sentence handler. Version with a token stored in flash.
    */
    void addHandler(const __FlashStringHelper *ifsh, NMEAHandler inHandler)
    {
      char buf[6];
      PGM_P p = reinterpret_cast<PGM_P>(ifsh);
      for (uint8_t i = 0; i < 6; i++) {
        char c = pgm_read_byte(p++);
        buf[i] = c;
        if (c == '\0') break;
      }
      addHandler(buf, inHandler);
    }
#endif

    /*
       Set the error handler which is called when a sentence is malformed
    */
    void setErrorHandler(NMEAErrorHandler inHandler)
    {
      mErrorHandler = inHandler;
    }

    /*
       Set the default handler which is called when a sentence is well formed
       but has no handler associated to
    */
    void setDefaultHandler(NMEAHandler inHandler)
    {
      mDefaultHandler = inHandler;
    }

    /*
       Give a character to the parser
    */
    void operator<<(char inChar)
    {
      int8_t tmp;

      switch (mState) {

        /* Waiting for the starting $ character */
        case INIT:
          mError = NMEA::NO_ERROR;
          if (inChar == '$') {
            mComputedCRC = 0;
            mState = SENT;
          }
          else unexpectedChar();
          break;

        case SENT:
          if (isalnum(inChar)) {
            if (spaceAvail()) {
              if (mIndex < 5) {
                mBuffer[mIndex++] = inChar;
                mComputedCRC ^= inChar;
              }
              else {
                typeTooLong();
              }
            }
            else bufferFull();
          }
          else {
            switch (inChar) {
              case ',' :
                mComputedCRC ^= inChar;
                mBuffer[--mArgIndex] = mIndex;
                mState = ARG;
                break;
              case '*' :
                mGotCRC = 0;
                mBuffer[--mArgIndex] = mIndex;
                mState = CRCH;
                break;
              default :
                unexpectedChar();
                break;
            }
          }
          break;

        case ARG:
          if (spaceAvail()) {
            switch (inChar) {
              case ',' :
                mComputedCRC ^= inChar;
                mBuffer[--mArgIndex] = mIndex;
                break;
              case '*' :
                mGotCRC = 0;
                mBuffer[--mArgIndex] = mIndex;
                mState = CRCH;
                break;
              default :
                mComputedCRC ^= inChar;
                mBuffer[mIndex++] = inChar;
                break;
            }
          }
          else bufferFull();
          break;

        case CRCH:
          tmp = hexToNum(inChar);
          if (tmp != -1) {
            mGotCRC |= (uint8_t)tmp << 4;
            mState = CRCL;
          }
          else unexpectedChar();
          break;

        case CRCL:
          tmp = hexToNum(inChar);
          if (tmp != -1) {
            mGotCRC |= (uint8_t)tmp;
            mState = CRLFCR;
          }
          else unexpectedChar();
          break;

        case CRLFCR:
          if (inChar == '\r') {
            mState = CRLFLF;
          }
          else unexpectedChar();
          break;

        case CRLFLF:
          if (inChar == '\n') {
            if (mHandleCRC && (mGotCRC != mComputedCRC)) {
              crcError();
            }
            else {
              processSentence();
            }
            reset();
          }
          else unexpectedChar();
          break;

        default:
          internalError();
          break;
      }
    }

    /*
       Returns the number of arguments discovered in a well formed sentence.
    */
    uint8_t argCount()
    {
      return kSentenceMaxSize - mArgIndex - 1;
    }

    /*
       Returns one of the arguments. Different versions according to data type.
    */
    bool getArg(uint8_t num, char &arg)
    {
      if (validArgNum(num)) {
        uint8_t startPos = startArgPos(num);
        uint8_t endPos = endArgPos(num);
        arg = mBuffer[startPos];
        return (endPos - startPos) == 1;
      }
      else return false;
    }

    bool getArg(uint8_t num, char *arg)
    {
      if (validArgNum(num)) {
        uint8_t startPos = startArgPos(num);
        uint8_t endPos = endArgPos(num);
        {
          NMEAParserStringify stfy(this, endPos);
          strcpy(arg, &mBuffer[startPos]);
        }
        return true;
      }
      else return false;
    }

#ifdef ARDUINO
    bool getArg(uint8_t num, String &arg)
    {
      if (validArgNum(num)) {
        uint8_t startPos = startArgPos(num);
        uint8_t endPos = endArgPos(num);
        {
          NMEAParserStringify stfy(this, endPos);
          arg = &mBuffer[startPos];
        }
        return true;
      }
      else return false;
    }
#endif

    bool getArg(uint8_t num, int &arg)
    {
      if (validArgNum(num)) {
        uint8_t startPos = startArgPos(num);
        uint8_t endPos = endArgPos(num);
        {
          NMEAParserStringify stfy(this, endPos);
          arg = atoi(&mBuffer[startPos]);
        }
        return true;
      }
      else return false;
    }

    bool getArg(uint8_t num, float &arg)
    {
      if (validArgNum(num)) {
        uint8_t startPos = startArgPos(num);
        uint8_t endPos = endArgPos(num);
        {
          NMEAParserStringify stfy(this, endPos);
          arg = atof(&mBuffer[startPos]);
        }
        return true;
      }
      else return false;
    }
    /*
       Returns the type of sentence.
    */
    bool getType(char *arg)
    {
      if (mIndex > 0) {
        uint8_t endPos = startArgPos(0);
        {
          NMEAParserStringify stfy(this, endPos);
          strncpy(arg, mBuffer, 5);
          arg[5] = '\0';
        }
        return true;
      }
      else return false;
    }

#ifdef ARDUINO
    bool getType(String &arg)
    {
      if (mIndex > 0) {
        uint8_t endPos = startArgPos(0);
        {
          NMEAParserStringify stfy(this, endPos);
          arg = mBuffer;
        }
        return true;
      }
      else return false;
    }
#endif

    bool getType(uint8_t inIndex, char &outTypeChar)
    {
      if (mIndex > 0) {
        uint8_t endPos = startArgPos(0);
        if (inIndex < endPos) {
          outTypeChar = mBuffer[inIndex];
          return true;
        }
        else return false;
      }
      else return false;
    }

    NMEA::ErrorCode error() {
      return mError;
    }

    void setHandleCRC(bool inHandleCRC)
    {
      mHandleCRC = inHandleCRC;
    }
#ifdef __amd64__
    void printBuffer()
    {
      {
        NMEAParserStringify stfy(this, startArgPos(0));
        printf("%s\n", mBuffer);
      }
      for (uint8_t i = 0; i < argCount(); i++) {
        uint8_t startPos = startArgPos(i);
        uint8_t endPos = endArgPos(i);
        {
          NMEAParserStringify stfy(this, endPos);
          printf("%s\n", &mBuffer[startPos]);
        }
      }
    }
#endif
};

#endif
