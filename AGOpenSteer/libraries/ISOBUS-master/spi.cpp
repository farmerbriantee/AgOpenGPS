/*
 * This file is free software; you can redistribute it and/or modify
 * it under the terms of either the GNU General Public License version 3
 * as published by the Free Software Foundation.
 */

#include "my_spi.h"

/* Don't build this file if for the Arduino */
#if ! ARDUINO

#include <avr/io.h>

#define SS_PORT     (PORTB)
#define SS_PIN      (1 << PORTB2)

enum {
    SPI_MODE_0 = 0x0,
    SPI_MODE_1 = 0x1,
    SPI_MODE_2 = 0x2,
    SPI_MODE_3 = 0x3,
};

void assert_ss (void)
{
    SS_PORT &= ~SS_PIN;

    /* Adjust nop count to match SS setup time */
    asm volatile("nop\n\t"::);
}

void deassert_ss (void)
{
    /* Adjust nop count to match SS hold time */
    asm volatile("nop\n\t"::);

    SS_PORT |= SS_PIN;
}

uint8_t spi_transfer (uint8_t byte)
{
    SPDR = byte;
    while (! (SPSR & (1 << SPIF)) );

    return SPDR;
}

void init_spi (void)
{
    deassert_ss();

    DDRB |= (1 << DDB5)    /* SCK output */
          | (1 << DDB3)    /* MOSI output */
          | (1 << DDB2);   /* ~SS output */

    SPSR |= (0 << SPI2X);  /* 2X clock speed */

    SPCR =  (0 << SPIE)    /* Interrupt enable */
         |  (1 << SPE)     /* SPI enable */
         |  (0 << DORD)    /* MSB first */
         |  (1 << MSTR)    /* Master mode */
         |  (SPI_MODE_0 << CPHA)  /* Mode 0 */
         |  (1 << SPR0);   /* Fosc / 4   */
}
#endif

