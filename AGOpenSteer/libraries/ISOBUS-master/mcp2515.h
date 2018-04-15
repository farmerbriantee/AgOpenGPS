#ifndef __MCP2515_H__
#define __MCP2515_H__

/**
 * @file mcp2515.h
 * MCP2515 driver header.
 */

#include <stdint.h>

/* Operation Modes */
#define MCP2515_MODE_NORMAL         0x00
#define MCP2515_MODE_SLEEP          0x01
#define MCP2515_MODE_LOOPBACK       0x02
#define MCP2515_MODE_LISTEN_ONLY    0x03
#define MCP2515_MODE_CONFIG         0x04

/**
 * CAN bus speeds.  These are the bit-times for common frequencies.
 */
enum {
    MCP2515_SPEED_500000 = 2000,
    MCP2515_SPEED_250000 = 4000,
    MCP2515_SPEED_125000 = 8000,
    MCP2515_SPEED_100000 = 10000,
    MCP2515_SPEED_62500  = 16000,
    MCP2515_SPEED_50000  = 20000,
    MCP2515_SPEED_31250  = 32000,
    MCP2515_SPEED_25000  = 40000,
    MCP2515_SPEED_20000  = 50000,
    MCP2515_SPEED_15625  = 64000
};

/**
 * Initialize the MCP2515.
 * @param bit_period - The length of the desired bit period.  The closest
 *                     possible approximation will be made.  Commonly used
 *                     frequencies are specified in the MCP2515_SPEED enums.
 */
void mcp2515_init (uint32_t bit_period);

/**
 * Read registers from the MCP2515.
 * @param addr - Address to begin reading from.
 * @param buf  - Buffer to store register values in.  Must have space for
 *               at least n bytes.
 * @param n    - Number of bytes to read.
 */
void mcp2515_read_regs (uint8_t addr, uint8_t* buf, uint8_t n);

/**
 * Write values to registers in the MCP2515.
 * @param addr - Address to begin writing to.
 * @param buf  - Buffer containing the values to write.
 * @param n    - Number of register to write.
 */
void mcp2515_write_regs (uint8_t addr, const uint8_t* buf, uint8_t n);

/**
 * Set the operation mode of the MCP2515.
 * @param mode - one of the MCP2515_MODE values defined above.
 */
void mcp2515_set_mode (uint8_t mode);

/**
 * Reads a CAN message received by the MCP2515.
 * @param rx_buf - Receive buffer to read from.
 * @param id     - Pointer to the location to store the CAN message ID.
 * @param data   - Buffer to store the message data in; must have space for at
 *                 least n bytes.
 * @param len    - Pointer to the location to store the length of the received
 *                 message in.
 * @return 0 if the message has a standard message ID, nonzero otherwise.
 */
uint8_t mcp2515_get_msg (uint8_t rx_buf, uint32_t *id,
                                        uint8_t *data, uint8_t *len);

/**
 * Loads a CAN message into a transmit buffer of the MCP2515.
 * @param tx_buf - Transmit buffer to write to.
 * @param id     - Message ID to send.
 * @param data   - Buffer containing the message data.
 * @param len    - Number of bytes in the message data.
 */
void mcp2515_set_msg (uint8_t tx_buf, uint32_t id, const uint8_t *data,
                                        uint8_t len, uint8_t extended);

/**
 * Convenience function for setting standard CAN messages.
 * @see mcp2515_set_msg.
 */
static inline void mcp2515_set_msg_std (uint8_t tx_buf, uint32_t id,
                                        const uint8_t *data, uint8_t len)
{
    mcp2515_set_msg (tx_buf, id, data, len, 0);
}

/**
 * Convenience function for setting extended CAN messages.
 * @see mcp2515_set_msg.
 */
static inline void mcp2515_set_msg_ext (uint8_t tx_buf, uint32_t id,
                                        const uint8_t *data, uint8_t len)
{
    mcp2515_set_msg (tx_buf, id, data, len, 1);
}

/**
 * Reqest transmission of a message
 * @param tx_buf - The number of the TX buffer to be transmitted.
 */
void mcp2515_request_tx (uint8_t tx_buf);

/**
 * Check to see if a message has been received
 * @return Zero if no message has been received.  If a message is available
 *         in receive buffer 0, bit 0 will be set, and if a message is
 *         available in receive buffer 1, bit 1 will be set.
 */
uint8_t mcp2515_msg_received (void);

/**
 * Check to see if a message has been sent
 * @return Zero if the message has not been sent, nonzero otherwise.
 */
uint8_t mcp2515_msg_sent (void);

/**
 * Set a receive mask on the MCP2515.  See MCP2515 documentation for details.
 * @param mask_num  - The number of the mask to be set.
 * @param mask      - The mask value to be set.
 * @param extended  - Nonzero if the mask applies to extended CAN IDs, zero for
 *                    standard.  This must match the corresponding filter.
 */
void mcp2515_set_rx_mask (uint8_t mask_num, uint32_t mask, uint8_t extended);

/**
 * Set a receive filter on the MCP2515.  See MCP2515 documentation for details.
 * @param mask_num  - The number of the filter to be set.
 * @param mask      - The filter value to be set.
 * @param extended  - Nonzero if the filter applies to extended CAN IDs, zero for
 *                    standard.  This must match the corresponding mask.
 */
void mcp2515_set_rx_filter (uint8_t filter_num, uint32_t filter, uint8_t extended);

#endif


