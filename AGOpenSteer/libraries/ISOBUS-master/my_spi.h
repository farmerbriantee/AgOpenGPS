/*
 * This file is free software; you can redistribute it and/or modify
 * it under the terms of either the GNU General Public License version 3
 * as published by the Free Software Foundation.
 */

#ifndef __SPI_H__
#define __SPI_H__

/* Remove this line if building outside the Arduino environment */
#include <Arduino.h>

#include <stdint.h>

#if ARDUINO
#include <SPI.h>
#endif


#if ARDUINO
const int slaveSelectPin = 10;

/** Assert the slave select signal */
static inline void assert_ss (void)
{
    digitalWrite (slaveSelectPin, LOW);
}

/** Deassert the slave select signal */
static inline void deassert_ss (void)
{
    digitalWrite (slaveSelectPin, HIGH);
}

/**
 * Initiate an SPI transfer.
 * @param byte - byte to send
 * @return - the byte received
 */
static uint8_t spi_transfer (uint8_t byte)
{
    return SPI.transfer (byte);
}

#else

/** Initialize the SPI */
void init_spi (void);

/** Assert the slave select signal */
void assert_ss (void);

/** Deassert the slave select signal */
void deassert_ss (void);

/**
 * Initiate an SPI transfer.
 * @param byte - byte to send
 * @return     - the byte received
 */
uint8_t spi_transfer (uint8_t byte);

#endif

/** Convenience function for sending a byte and ignoring the receive value */
static inline void spi_send (uint8_t byte)
{
    spi_transfer (byte);
}

/** Convenience function for receiving a byte and ignoring the send value */
static inline uint8_t spi_receive (void)
{
    return spi_transfer (0);
}

#endif
