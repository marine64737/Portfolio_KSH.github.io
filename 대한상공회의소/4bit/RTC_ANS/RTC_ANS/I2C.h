/*
 * I2C.h
 *
 * Created: 21-04-23 (금) 오전 9:56:39
 *  Author: 조상호
 */ 


#ifndef I2C_H_
#define I2C_H_

#include <avr/io.h>
#include <avr/sfr_defs.h>

#define I2C_SCL	PD0
#define I2C_SDA	PD1
#define I2C_ADDRESS	0x68



#define D2B(data)	( ( (data / 10) << 4) | ( data % 10 ) )



void I2C_init() ;
void I2C_start( void ) ;
void I2C_transmit( uint8_t data ) ;
void I2C_stop( void ) ;
uint8_t I2C_receive_ACK(void) ;
uint8_t I2C_receive_NACK(void) ;


#endif /* I2C_H_ */