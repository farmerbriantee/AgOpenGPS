/*
 * This file is free software; you can redistribute it and/or modify
 * it under the terms of either the GNU General Public License version 3
 * as published by the Free Software Foundation.
 */

/**
 * @file ISOBUS.h
 * Include file for Arduino-based ISOBUS projects.
 */


#ifndef CAN_h
#define CAN_h

#include "Arduino.h"

#include <inttypes.h>
#include "mcp2515.h"

#define DEFAULT_CAN_ID          0x0555
#define CAN_BYTES_MAX           8


/** PG names and numbers */
/** PGN 61444 (R) Electronic Engine Controller 1 - EEC1 */
#define EEC1_PGN						61444
#define EngineSpeed_SPN					190

/** PGN 65096 WBSD_TECU */
#define WBSD_TECU_PGN					65096
#define WheelBasedMachineDirection_SPN 	1864

#define GBSD_TECU_PGN					65097
#define FHS_TECU_PGN					65094
#define RHS_TECU_PGN					65093

/* Macros for going between CAN IDs and PDU/PGN fields */
#define ISOBUS_PGN_POS        8
#define ISOBUS_PGN_MASK       0x03FFFFLU

/** Operation Modes of the MCP2515 */
enum CAN_MODE {
    CAN_MODE_NORMAL,        /**< Transmit and receive as normal */
    CAN_MODE_SLEEP,         /**< Low power mode */
    CAN_MODE_LOOPBACK,      /**< Test mode; any CAN messages sent are not
                              *  transmitted on the CAN network, but instead
                              *  appear in the receive buffer as though they
                              *  were received from another CAN node. */
    CAN_MODE_LISTEN_ONLY,   /**< Receive only; do not transmit or otherwise
                              *  interact with the CAN network. */
    CAN_MODE_CONFIG,        /**< Default; Allows writing to config registers */

    CAN_MODE_COUNT
};

/** Predefined CAN speeds - Included mostly for backward compatibility */
enum CAN_SPEED {
    CAN_SPEED_500000            = MCP2515_SPEED_500000,
    CAN_SPEED_250000            = MCP2515_SPEED_250000,
    CAN_SPEED_125000            = MCP2515_SPEED_125000,
    CAN_SPEED_100000            = MCP2515_SPEED_100000,
    CAN_SPEED_62500             = MCP2515_SPEED_62500,
    CAN_SPEED_50000             = MCP2515_SPEED_50000,
    CAN_SPEED_31250             = MCP2515_SPEED_31250,
    CAN_SPEED_25000             = MCP2515_SPEED_25000,
    CAN_SPEED_20000             = MCP2515_SPEED_20000,
    CAN_SPEED_15625             = MCP2515_SPEED_15625,
};

/**
 * A class representing a single CAN message.
 * This class is used to build a message to be sent, and to read messages
 * that have been received.
 */
class CanMessage {
    public:
        /** A flag indicating whether this is an extended CAN message */
        uint8_t extended;
        /** The identifier of the CAN message.  The ID is 29 bytes long
          * if the extended flag is set, or 11 bytes long if not set. */
        uint32_t id;
        /** The number of bytes in the data field (0-8) */
        uint8_t len;
        /** Array containing the bytes of the CAN message.  This array
          * may be accessed directly to set or read the CAN message.
          * This field can also be set by the set<Type>Data functions and
          * read by the get<Type>Data functions. */
        uint8_t data[CAN_BYTES_MAX];

        CanMessage();

        /**
         * Simple interface to set up a CAN message for sending a byte data
         * type.  When received, this message should be unpacked with the
         * getByteData function.  This interface only allows one byte to be
         * packed into a message.  To pack more data, access the data array
         * directly.
         * @param b - The byte to pack into the message.
         */
        void setByteData (byte b);

        /**
         * Simple interface to set up a CAN message for sending an int data
         * type.  When received, this message should be unpacked with the
         * getIntData function.  This interface only allows one int to be
         * packed into a message.  To pack more data, access the data array
         * directly.
         * @param i - The int to pack into the message.
         */
        void setIntData (int i);

        /**
         * Simple interface to set up a CAN message for sending a long data
         * type.  When received, this message should be unpacked with the
         * getLongData function.  This interface only allows one long to be
         * packed into a message.  To pack more data, access the data array
         * directly.
         * @param l - The long to pack into the message.
         */
        void setLongData (long l);

        /**
         * A convenience function for copying multiple bytes of data into
         * the message.
         * @param data - The data to be copied into the message
         * @param len  - The size of the data
         */
        void setData (const uint8_t *data, uint8_t len);
        void setData (const char *data, uint8_t len);

        /**
         * Send the CAN message.  Once a message has been created, this
         * function sends it.
         */
        void send();

        /**
         * Simple interface to retrieve a byte from a CAN message.  This
         * should only be used on messages that were created using the
         * setByteData function on another node.
         * @return The byte contained in the message.
         */
        byte getByteFromData ();

        /**
         * Simple interface to retrieve an int from a CAN message.  This
         * should only be used on messages that were created using the
         * setIntData function on another node.
         * @return The int contained in the message.
         */
        int getIntFromData ();

        /**
         * Simple interface to retrieve a long from a CAN message.  This
         * should only be used on messages that were created using the
         * setLongData function on another node.
         * @return The long contained in the message.
         */
        long getLongFromData ();

        /**
         * A convenience function for copying multiple bytes out of a
         * CAN message.
         * @param data - The location to copy the data to.
         */
        void getData (uint8_t *data);
        void getData (char *data);

        /**
         * Clear message data so that a message variable can be reused.
         * If you are using the "set" functions and using a CanMessage
         * variable more than once, this method must be called to clear the
         * data in the message before setting new data values.  It is not
         * necessary to call this before receiving a message, as the received
         * message completely replaces the old message.
         */
        void clear (void);

        /**
         * Print out the CAN message identifier, length and data bytes.
         * This is useful for debugging programs or monitoring other
         * CAN networks.
         * @param format - An optional format specifier to be passed to the
         *                 Arduino print funtion (e.g. HEX or DEC).
         */
        void print (uint8_t format = HEX);

    private:
        /** The current position of reading/writing data out of the message */
        uint8_t pos;
};

/**
 * A class representing a single CAN message.
 * This class is used to build a message to be sent, and to read messages
 * that have been received.
 */
class ISOBUSMessage {
    public:
        /** A flag indicating whether this is an extended CAN message */
        uint8_t extended;
        /** The identifier of the CAN message.  The ID is 29 bytes long (ISOBUS)
          * if the extended flag is set, or 11 bytes long if not set. */
        uint32_t id;
        /** The number of bytes in the data field (0-8) */
        uint8_t len;
        /** Array containing the bytes of the CAN message.  This array
          * may be accessed directly to set or read the CAN message.
          * This field can also be set by the set<Type>Data functions and
          * read by the get<Type>Data functions. */
        uint8_t data[CAN_BYTES_MAX];
        /** The PGN of a CAN frame */
		unsigned int pgn;
		/** Specific SPN data */
		uint32_t spn_data;
        /** status number 
		  *	0 = status OK
		  *	10 = PGN not available*/
        uint8_t status;
        ISOBUSMessage();
};

/**
 * A class for managing the CAN driver.
 */
class CANClass {
    public:
        /**
         * Call before using any other CAN functions.
         * @param bit_time - Desired width of a single bit in nanoseconds.
         *                   The CAN_SPEED enumerated values are set to
         *                   the bit widths of some common frequencies.
         */
        static void begin(uint32_t bit_time);

        /** Call when all CAN functions are complete */
        static void end();

        /**
         * Set operational mode.
         * @param mode - One of the enumerated mode values
         * @see enum CAN_MODE */
        static void setMode(uint8_t mode);

        /** Check whether a message may be sent */
        static uint8_t ready ();

        /**
         * Check whether received CAN data is available.
         * @return True if a message is available to be retrieved.
         */
        static boolean available ();

        /**
         * Retrieve a CAN message.
         * @return A CanMessage containing the retrieved message
         */
        static CanMessage getMessage ();
		
		 /**
         * Retrieve a ISOBUS message.
         * @return A ISOBUSMessage containing the retrieved message
         */
        static ISOBUSMessage getMessageISOBUS (unsigned int pgn, unsigned int spn, char *buffer);
};

extern CANClass ISOBUS;

#endif
