/*
 * I2C_RTC.h
 *
 * Created: 2021-04-23 오후 12:16:54
 *  Author: kccistc
 */ 


#ifndef I2C_RTC_H_
#define I2C_RTC_H_

#define I2C_SCL PORTE0
#define I2C_SDA PORTE1

#include <avr/io.h>

void I2C_init(void) ;
void I2C_start(void) ;
void I2C_transmit(uint8_t data) ;
uint8_t I2C_receive_NACK(void) ;
uint8_t I2C_receive_ACK(void) ;
void I2C_stop(void) ;



#endif /* I2C_RTC_H_ */