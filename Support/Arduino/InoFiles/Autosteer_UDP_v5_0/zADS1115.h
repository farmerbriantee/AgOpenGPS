/*
ADS1115 lite library - Adapted from adafruit ADS1015/ADS1115 library

	This library is stripped down version with bug fixes from the adafruit ADS1015/ADS1115 library in order to save as much space as possible
		1. No explicit "Read ADC" functions exist to save space.  Simply set your mux manually, trigger a conversion manually, and read the value manually.  See the example program
		2. ADS1015 functionality removed to save space.  Note that this library should work for the ADS1015, the only difference is the sample rate constants.
		3. Continuous Conversion removed
			a. If "continuous conversion" is required, perhaps you should rethink your requirements.  Continuous conversion is never REALLY required.
			b. That being said, if you want a continuous conversion simply start a conversion after reading a value by executing "adc.triggerConversion()" immediatly AFTER an "adc.getConversion();".  That's all the chip does anyway...
		4. Comparator functionality removed to save space.  Cmon..you can program that functionality if you REALLY need it, this is a lite library
		5. I2C abstraction removed to save space.  Is anyone using old Arduino IDE versions?
		6. keywords.txt added in order to display proper keyword coloring in the Arduino IDE
		7. All report bug fixes from the adafruit library on github
			a. Most notably the incorrect sample rate used when using the ADS1115.  Yes that's right, if you used the Adafruit library the sample rate was set to the fastest, noisiest sample rate by default with no way to change it!  Opps!
		8. Proper ifndef added to prevent multiple calls
		9. Removed explicit delays and intead poll the Operational Status bit (conversion done)
		 
	https://github.com/terryjmyers/ADS1115-Lite.Git
    v1.0 - First release
*/
#ifndef ADS1115_lite_H
#define ADS1115_lite_H

#include <Arduino.h>
#include <Wire.h>

/*=========================================================================
    I2C ADDRESS/BITS
    -----------------------------------------------------------------------*/
	#define ADS1115_ADDRESS_ADDR_GND    0x48 // address pin low (GND)
	#define ADS1115_ADDRESS_ADDR_VDD    0x49 // address pin high (VCC)
	#define ADS1115_ADDRESS_ADDR_SDA    0x4A // address pin tied to SDA pin
	#define ADS1115_ADDRESS_ADDR_SCL    0x4B // address pin tied to SCL pin
	#define ADS1115_DEFAULT_ADDRESS     ADS1115_ADDRESS_ADDR_GND
/*=========================================================================*/

/*=========================================================================
    POINTER REGISTERS
    -----------------------------------------------------------------------*/
    #define ADS1115_REG_POINTER_CONVERT     (0x00)
    #define ADS1115_REG_POINTER_CONFIG      (0x01)
/*=========================================================================*/

/*=========================================================================
    CONFIG REGISTER
    -----------------------------------------------------------------------*/
    #define ADS1115_REG_CONFIG_OS_SINGLE    (0x8000)  // Write: Set to start a single-conversion

	//Mux Parameters.  Used as input to setMux()
    #define ADS1115_REG_CONFIG_MUX_DIFF_0_1 (0x0000)  // Differential P = AIN0, N = AIN1 (default)
    #define ADS1115_REG_CONFIG_MUX_DIFF_0_3 (0x1000)  // Differential P = AIN0, N = AIN3
    #define ADS1115_REG_CONFIG_MUX_DIFF_1_3 (0x2000)  // Differential P = AIN1, N = AIN3
    #define ADS1115_REG_CONFIG_MUX_DIFF_2_3 (0x3000)  // Differential P = AIN2, N = AIN3
    #define ADS1115_REG_CONFIG_MUX_SINGLE_0 (0x4000)  // Single-ended AIN0
    #define ADS1115_REG_CONFIG_MUX_SINGLE_1 (0x5000)  // Single-ended AIN1
    #define ADS1115_REG_CONFIG_MUX_SINGLE_2 (0x6000)  // Single-ended AIN2
    #define ADS1115_REG_CONFIG_MUX_SINGLE_3 (0x7000)  // Single-ended AIN3

	//Gain parameter.  Used as input to setGain()
    #define ADS1115_REG_CONFIG_PGA_6_144V   (0x0000)  // +/-6.144V range = Gain 2/3
    #define ADS1115_REG_CONFIG_PGA_4_096V   (0x0200)  // +/-4.096V range = Gain 1
    #define ADS1115_REG_CONFIG_PGA_2_048V   (0x0400)  // +/-2.048V range = Gain 2 (default)
    #define ADS1115_REG_CONFIG_PGA_1_024V   (0x0600)  // +/-1.024V range = Gain 4
    #define ADS1115_REG_CONFIG_PGA_0_512V   (0x0800)  // +/-0.512V range = Gain 8
    #define ADS1115_REG_CONFIG_PGA_0_256V   (0x0A00)  // +/-0.256V range = Gain 16

	//NSingle Shot or Continuous Mode.  Cont mode is not used in this program but is preserved here for posterity
    //#define ADS1115_REG_CONFIG_MODE_CONTIN  (0x0000)  // Continuous conversion mode
    #define ADS1115_REG_CONFIG_MODE_SINGLE  (0x0100)  // Power-down single-shot mode (default)

	//Sample Rate or Data Rate.  Used as input to setSampleRate().  Note
	//Note that there is some overhead time of the I2C bus so the actual throughput is slightly less
    #define ADS1115_REG_CONFIG_DR_8SPS    (0x0000)  // 8 SPS(Sample per Second), or a sample every 125ms
    #define ADS1115_REG_CONFIG_DR_16SPS    (0x0020)  // 16 SPS, or every 62.5ms
    #define ADS1115_REG_CONFIG_DR_32SPS    (0x0040)  // 32 SPS, or every 31.3ms
    #define ADS1115_REG_CONFIG_DR_64SPS    (0x0060)  // 64 SPS, or every 15.6ms
    #define ADS1115_REG_CONFIG_DR_128SPS   (0x0080)  // 128 SPS, or every 7.8ms  (default)
    #define ADS1115_REG_CONFIG_DR_250SPS   (0x00A0)  // 250 SPS, or every 4ms, note that noise free resolution is reduced to ~14.75-16bits, see table 2 in datasheet
    #define ADS1115_REG_CONFIG_DR_475SPS   (0x00C0)  // 475 SPS, or every 2.1ms, note that noise free resolution is reduced to ~14.3-15.5bits, see table 2 in datasheet
    #define ADS1115_REG_CONFIG_DR_860SPS   (0x00E0)  // 860 SPS, or every 1.16ms, note that noise free resolution is reduced to ~13.8-15bits, see table 2 in datasheet

/*=========================================================================*/

class ADS1115_lite
{
	protected:
		// Instance-specific properties
		uint8_t		_i2cAddress;
		uint16_t	_gain;
		uint16_t	_mux;
		uint8_t		_rate;

	public:
		ADS1115_lite(uint8_t i2cAddress = ADS1115_DEFAULT_ADDRESS);
		bool	testConnection(); //returns 1 if ADS1115 is properly connected, 0 if not connected.  There is no point in calling any other function is this doesn't return a 1
		
		void	setGain(uint16_t gain); //Sets protected property and immediatly returns
		void	setMux(uint16_t mux); //Sets Sets protected property and immediatly returns
		void	setSampleRate(uint8_t rate); //Sets Sets protected property and immediatly returns: sample rate
		
		void	triggerConversion(void); //Triggers a single conversion with currently configured settings in protected variables.  Immediately returns
		bool	isConversionDone(); //Polls ADS1115 for the conversion done register.  Returns 1 if conversion is finished, 0 if in the middle of conversion.
		int16_t	getConversion(); //Polls ADS1115 for the conversion done register.  Waits until it is finished and returns value.

};

#endif