/**
 * @file mcp2515.cpp
 * MCP2515 driver.  This file is straight C code, and can be renamed to .c
 * to use it in a C project.  It is named .cpp so that it will be built by
 * the Arduino build system.
 */
#include "mcp2515.h"
#include "mcp2515_regs.h"
#include "my_spi.h"


/** For each increment of the BRP, our time quanta goes up this many
  * nanoseconds (for our 16MHz crystal) */
#define TIME_QUANTUM_STEP            125

/** The minimum bit width in time quanta (1, 1, 1, 2) */
#define QUANTUM_WIDTH_MIN           5

/** The maximum bit width in time quanta (1, 8, 8, 8) */
#define QUANTUM_WIDTH_MAX           25

/** The highest possible BRP value */
#define BRP_MAX               63

/** The SYNC_JUMP_WIDTH is always 1 time quantum */
#define SYNC_JUMP_WIDTH 1


/* SPI Commands */
enum {
    MCP2515_CMD_RESET       = 0xC0,
    MCP2515_CMD_READ        = 0x03,
    MCP2515_CMD_WRITE       = 0x02,
    MCP2515_CMD_RTS         = 0x80,
    MCP2515_CMD_READ_STATUS = 0xA0,
    MCP2515_CMD_BIT_MODIFY  = 0x05,
};

void mcp2515_read_regs (uint8_t addr, uint8_t* buf, uint8_t n)
{
    int i;

    assert_ss();
    spi_send(MCP2515_CMD_READ);
    spi_send(addr);
    for (i=0; i<n; i++)
        buf[i] = spi_receive();
    deassert_ss();
}

void mcp2515_write_regs (uint8_t addr, const uint8_t* buf, uint8_t n)
{
    int i;

    assert_ss();
    spi_send(MCP2515_CMD_WRITE);
    spi_send(addr);
    for (i=0; i<n; i++)
        spi_send(buf[i]);
    deassert_ss();
}

static void mcp2515_write_reg (uint8_t addr, uint8_t buf)
{
    assert_ss();
    spi_send(MCP2515_CMD_WRITE);
    spi_send(addr);
    spi_send(buf);
    deassert_ss();
}

static void mcp2515_bit_modify (uint8_t addr, uint8_t mask, uint8_t bits)
{
    assert_ss();
    spi_send(MCP2515_CMD_BIT_MODIFY);
    spi_send(addr);
    spi_send(mask);
    spi_send(bits);
    deassert_ss();
}

/**
 * Find the best prescalar and bit width in time quanta for the given bit
 * period.  This algorithm favors lower prescalars and therefore higher
 * frequencies and more time quanta per bit.
 * @param bit_period - Length of bit period in nanoseconds
 * @param bit_width  - Pointer to the location to store the bit width
 * return - The best prescalar
 */
static uint8_t calc_brp (uint32_t bit_period, uint8_t *bit_width)
{
    uint32_t total_steps;
    uint16_t brp_min;
    uint16_t brp_max;
    uint8_t error;
    uint8_t best_width;
    uint8_t best_brp;
    uint8_t best_error = BRP_MAX;
    uint8_t i;

    /* Calculate the minimum BRP that can meet this rate */
    brp_min = bit_period / (QUANTUM_WIDTH_MAX * TIME_QUANTUM_STEP);
    /* Calculate the maximum BRP that can meet this rate */
    brp_max = bit_period / (QUANTUM_WIDTH_MIN * TIME_QUANTUM_STEP);

    /* Don't check outside the valid range */
    if (brp_min > BRP_MAX)
        brp_min = BRP_MAX;
    if (brp_max > BRP_MAX)
        brp_max = BRP_MAX;

    total_steps = bit_period / TIME_QUANTUM_STEP;

    for (i = brp_min; i <= brp_max; i++) {
        error = total_steps % (i + 1);

        /* If the number of quanta that make the correct bit rate at this
         * prescalar is an integer, this is an exact match. */
        if (error == 0) {
            best_brp = i;
            best_width = total_steps / (i + 1);
            break;
        }

        /* If rounding up, the error is the difference between the divisor
         * and the remainder */
        if ((i + 1) - error < error) {
            error = (i + 1) - error;
        }

        /* Store the settings at this BRP if they are the best yet */
        if (error < best_error) {
            best_error = error;
            best_width = (total_steps + ((i + 1) >> 1))/ (i + 1);
            best_brp = i;
        }
    }

    /* Return the best match */
    *bit_width = best_width;
    return best_brp;
}


void mcp2515_init (uint32_t bit_period)
{
    uint8_t brp;
    uint8_t bit_width;
    uint8_t prop_seg;
    uint8_t phase_1_seg;
    uint8_t phase_2_seg;

    /* Calculate BRP and bit width */
    brp = calc_brp (bit_period, &bit_width);

    if (bit_width < QUANTUM_WIDTH_MIN)
        bit_width = QUANTUM_WIDTH_MIN;

    /* Calculate segment widths based on bit width.  This algorithm keeps
     * the segments as even as possible, favoring phase2, then phase1
     * to be bigger. */
    phase_2_seg = (bit_width + 1) / 3;
    bit_width -= phase_2_seg;

    phase_1_seg = bit_width >> 1;

    prop_seg = bit_width - phase_1_seg - 1;

    /* Set registers */
    mcp2515_write_reg (CNF1,
            (brp << BRP) |
            ((SYNC_JUMP_WIDTH - 1) << SJW) );

    mcp2515_write_reg (CNF2,
            ((prop_seg - 1) << PRSEG) |
            ((phase_1_seg - 1) << PHSEG1) |
            (0 << SAM) |  /* Sample once */
            (1 << BTLMODE) );  /* Phase 2 set by CNF3 */

    mcp2515_write_reg (CNF3,
            ((phase_2_seg - 1) << PHSEG2) |
            (0 << WAKFIL) );

    mcp2515_write_reg (REG(RX, 0, CTRL),
            (0x0 << RXM) |
            (0 << BUKT) );
}


/*
 * Set the operating mode of the MCP2515
 */
void mcp2515_set_mode (uint8_t mode)
{
    mcp2515_bit_modify (CANCTRL, REQOP_MASK, mode << REQOP);
}

/*
 * Reads a message from the receive buffer and marks it as read.
 */
uint8_t mcp2515_get_msg (uint8_t rx_buf, uint32_t *id,
                    uint8_t *data, uint8_t *len)
{
    uint8_t buf[5];
    uint8_t extended;

    mcp2515_read_regs (REG(RX, rx_buf, SIDH), buf, 5);
    *len = buf[4] & 0x0f;
    if (*len > 8)
        *len = 8;
    mcp2515_read_regs (REG(RX, rx_buf, D0), data, *len);

   extended = buf[1] & (1 << IDE);

    if (extended) {
        *id = ((uint32_t)(buf[0]) << 21) |
              ((uint32_t)(buf[1] & 0xE0) << 13) |
              ((uint32_t)(buf[1] & 0x03) << 16) |
              ((uint32_t)(buf[2]) << 8) |
              ((uint32_t)(buf[3]) << 0);
    } else {
        *id = ((uint32_t)buf[0] << 3) |
              ((uint32_t)buf[1] >> 5);
    }

    mcp2515_bit_modify (CANINTF, 1 << (RX0IF + rx_buf), 0);

    return extended;
}

/*
 * Loads a message into the transmit buffer
 */
void mcp2515_set_msg (uint8_t tx_buf, uint32_t id, const uint8_t *data,
                    uint8_t len, uint8_t extended)
{
    uint8_t buf[5];

    if (extended) {
        buf[0] = (uint8_t)(id >> 21);
        buf[1] = (uint8_t)(((id >> 13) & 0xE0) |
                (1 << EXIDE) |
                ((id >> 16) & 0x03));
        buf[2] = (uint8_t)(id >> 8);
        buf[3] = (uint8_t)(id);
    } else {
        buf[0] = (uint8_t)(id >> 3);
        buf[1] = (uint8_t)(id << 5);
    }

    if (len > 8)
        len = 8;

    buf[4] = len << DLC0;

    mcp2515_write_regs (REG(TX, tx_buf, SIDH), buf, 5);
    mcp2515_write_regs (REG(TX, tx_buf, D0), data, len);
}

/*
 * Requests transmission of the loaded message
 */
void mcp2515_request_tx (uint8_t tx_buf)
{
    mcp2515_bit_modify (REG(TX, tx_buf, CTRL), 1 << TXREQ, 1 << TXREQ);
}

/*
 * Returns non-zero if a message has been received
 */
uint8_t mcp2515_msg_received (void)
{
    uint8_t byte;

    mcp2515_read_regs (CANINTF, &byte, 1);

    return (byte & ((1 << RX1IF) | (1 << RX0IF)));
}

/* 
 * Returns non-zero if the message has been sent
 */
uint8_t mcp2515_msg_sent (void)
{
    uint8_t byte;

    mcp2515_read_regs (REG(TX, 0, CTRL), &byte, 1);

    return (!(byte & (1 << TXREQ)));
}

void mcp2515_set_rx_mask (uint8_t mask_num, uint32_t mask, uint8_t extended)
{
    uint8_t reg;
    uint8_t buf[4];

    if (mask_num == 0)
        reg = RXM0SIDH;
    else
        reg = RXM1SIDH;

    if (extended) {
        buf[0] = (uint8_t)(mask >> 21);
        buf[1] = (uint8_t)(((mask >> 13) & 0xE0)
                         | ((mask >> 16) & 0x03));
        buf[2] = (uint8_t)(mask >> 8);
        buf[3] = (uint8_t)(mask >> 0);
    } else {
        buf[0] = (uint8_t)(mask >> 3);
        buf[1] = (uint8_t)(mask << 5);
        buf[2] = 0;
        buf[3] = 0;
    }

    mcp2515_write_regs (reg, buf, 4);
}

void mcp2515_set_rx_filter (uint8_t filter_num, uint32_t filter, uint8_t extended)
{
    uint8_t reg;
    uint8_t buf[4];

    /* Calculate correct register */
    reg = filter_num * 4;
    if (reg >= 12)
        reg += 4;

    if (extended) {
        buf[0] = (uint8_t)(filter >> 21);
        buf[1] = (uint8_t)(((filter >> 13) & 0xE0)
                         | ((filter >> 16) & 0x03)
                         | (1 << EXIDE));
        buf[2] = (uint8_t)(filter >> 8);
        buf[3] = (uint8_t)(filter >> 0);
    } else {
        buf[0] = (uint8_t)(filter >> 3);
        buf[1] = (uint8_t)(filter << 5);
        buf[2] = 0;
        buf[3] = 0;
    }

    mcp2515_write_regs (reg, buf, 4);
}
