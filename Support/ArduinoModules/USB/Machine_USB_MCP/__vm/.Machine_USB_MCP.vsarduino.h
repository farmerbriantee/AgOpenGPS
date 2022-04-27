/* 
	Editor: https://www.visualmicro.com/
			This file is for intellisense purpose only.
			Visual micro (and the arduino ide) ignore this code during compilation. This code is automatically maintained by visualmicro, manual changes to this file will be overwritten
			The contents of the _vm sub folder can be deleted prior to publishing a project
			All non-arduino files created by visual micro and all visual studio project or solution files can be freely deleted and are not required to compile a sketch (do not delete your own code!).
			Note: debugger breakpoints are stored in '.sln' or '.asln' files, knowledge of last uploaded breakpoints is stored in the upload.vmps.xml file. Both files are required to continue a previous debug session without needing to compile and upload again
	
	Hardware: ATmega328P (Arduino Nano), Platform=avr, Package=arduino
*/

#if defined(_VMICRO_INTELLISENSE)

#ifndef _VSARDUINO_H_
#define _VSARDUINO_H_
#define __AVR_atmega328p__
#define __AVR_ATmega328P__
#define __AVR_ATmega328p__
#define _VMDEBUG 1
#define F_CPU 16000000L
#define ARDUINO 108013
#define ARDUINO_AVR_NANO
#define ARDUINO_ARCH_AVR
#define __cplusplus 201103L
#define _Pragma(x)
#define __AVR__
#define __inline__
#define __asm__(...)
#define __extension__
#define __inline__
#define __volatile__
// Redefine __cplusplus to correct version: https://www.visualmicro.com/forums/YaBB.pl?num=1592217268
#undef __cplusplus
#define __cplusplus 201103L

//#define GCC_VERSION 40902
//https://www.visualmicro.com/forums/YaBB.pl?num=1569762585/5#5
#define __GNUC__             5
#define __GNUC_MINOR__       4
#define __GNUC_PATCHLEVEL__  0
#define GCC_VERSION ((__GNUC__*10000)+(__GNUC_MINOR__*100)+__GNUC_PATCHLEVEL__)) 


#define volatile(va_arg) 
#define _CONST
#define __builtin_va_start
#define __builtin_va_end
#define __attribute__(...)
#define NOINLINE __attribute__((noinline))
#define prog_void
#define PGM_VOID_P int


#ifndef __builtin_constant_p
	#define __builtin_constant_p __attribute__((__const__))
#endif
#ifndef __builtin_strlen
	#define __builtin_strlen  __attribute__((__const__))
#endif


#define NEW_H
typedef void *__builtin_va_list;
//extern "C" void __cxa_pure_virtual() {;}

typedef int div_t;
typedef int ldiv_t;


typedef void *__builtin_va_list;
//extern "C" void __cxa_pure_virtual() {;}



#include "arduino.h"
#include <pins_arduino.h> 
//#undef F
//#define F(string_literal) ((const PROGMEM char *)(string_literal))
#undef PSTR
#define PSTR(string_literal) ((const PROGMEM char *)(string_literal))

//typedef unsigned char uint8_t;
//typedef unsigned int uint8_t;

#define pgm_read_byte_near(address_short) uint8_t()
#define pgm_read_byte(address_short) uint8_t() 
#define pgm_read_word(address_short) uint16_t() 
#define pgm_read_dword(address_short) uint32_t()
#define pgm_read_float(address_short) float()
#define pgm_read_ptr(address_short)   short()

#include "Machine_USB_MCP.ino"
#endif
#endif
