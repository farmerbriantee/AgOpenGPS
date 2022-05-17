/* 
	Editor: https://www.visualmicro.com/
			This file is for intellisense purpose only.
			Visual micro (and the arduino ide) ignore this code during compilation. This code is automatically maintained by visualmicro, manual changes to this file will be overwritten
			The contents of the _vm sub folder can be deleted prior to publishing a project
			All non-arduino files created by visual micro and all visual studio project or solution files can be freely deleted and are not required to compile a sketch (do not delete your own code!).
			Note: debugger breakpoints are stored in '.sln' or '.asln' files, knowledge of last uploaded breakpoints is stored in the upload.vmps.xml file. Both files are required to continue a previous debug session without needing to compile and upload again
	
	Hardware: Teensy 4.1, Platform=teensy4, Package=teensy
*/

#if defined(_VMICRO_INTELLISENSE)

#ifndef _VSARDUINO_H_
#define _VSARDUINO_H_
#define __HARDWARE_imxrt1062__
#define __HARDWARE_IMXRT1062__
#define _VMDEBUG 1
#define __IMXRT1062__
#define TEENSYDUINO 156
#define ARDUINO 108013
#define ARDUINO_TEENSY41
#define F_CPU 150000000
#define USB_SERIAL
#define LAYOUT_US_ENGLISH
#define __cplusplus 201103L
#undef __cplusplus
#define __cplusplus 201103L


#define __arm__
#define __ARM__
#define  __attribute__(x)
typedef void *__builtin_va_list;
#define __extension__
#define __ATTR_PURE__
#define __ATTR_CONST__
#define __inline__
#define __asm__(x)
#define __volatile__
#define NEW_H
#undef _WIN32
#define __STDC__ 
//#define __GNUC__ 2
//#define __GNUC_MINOR__ 5
#define __ARM_ARCH_7EM__

extern int at_quick_exit(void (*f)(void));
int at_quick_exit(void (*f)(void)) {
}
extern int quick_exit(void (*f)(void));
int quick_exit(void (*f)(void)) {
}



#define __INT64_TYPE__ 8
#define __INTPTR_TYPE__ 4
#define __INT32_TYPE__ 4

typedef long intptr_t;
typedef long __intptr_t;
typedef unsigned long __uintptr_t;
typedef long __int32_t;
typedef unsigned long __uint32_t;
typedef unsigned short  __uint16_t;
typedef short __int16_t;
typedef unsigned short  __uint8_t;
typedef short __int8_t;
typedef unsigned long __uint64_t;
typedef double __int64_t;
typedef unsigned long uint64_t;
typedef double int64_t;
typedef unsigned short uint8_t;
typedef short int8_t;

typedef unsigned int uint16_t;
typedef short int16_t;
typedef long __int32_t;
typedef unsigned long __uint32_t;

#define at_quick_exit(x)

#include "arduino.h"
#define abs(x) ((x)>0?(x):-(x))
#define constrain(amt,low,high) ((amt)<(low)?(low):((amt)>(high)?(high):(amt)))
#define round(x)     ((x)>=0?(long)((x)+0.5):(long)((x)-0.5))
#define radians(deg) ((deg)*DEG_TO_RAD)
#define degrees(rad) ((rad)*RAD_TO_DEG)
#define sq(x) ((x)*(x))

#define __asm__

#define __disable_irq() __asm__ volatile("");
#define __enable_irq()	__asm__ volatile("");


#include "A_Teensy_v56.ino"
#include "Autosteer.ino"
#include "AutosteerPID.ino"
#include "IMU.ino"
#include "NMEA.ino"
#include "zEthernet.ino"
#include "zRelPos.ino"
#include "zUdpNtrip.ino"
#endif
#endif
