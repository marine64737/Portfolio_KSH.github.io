/*
 * I2C.c
 *
 * Created: 21-04-23 (금) 오전 9:56:28
 *  Author: 조상호
 */ 

#include "I2C.h"


void I2C_init()
{
	DDRD |= ( 1<< I2C_SCL ) ;
	DDRD |= ( 1<< I2C_SDA ) ;
	
	TWBR = 32 ;
}

void I2C_start( void ) 
{
	TWCR = _BV( TWINT ) | _BV( TWSTA ) | _BV(TWEN) ;
	
	while( !(TWCR & ( 1 << TWINT ) ) ) ;
	
}

void I2C_transmit( uint8_t data )
{
	TWDR = data ;
	TWCR = _BV( TWINT ) | _BV( TWEA ) | _BV(TWEN) ;
	
	while( !(TWCR & ( 1 << TWINT ) ) ) ;
}

void I2C_stop( void )
{	
	TWCR = _BV( TWINT ) | _BV( TWSTO ) | _BV(TWEN) ;
}

uint8_t I2C_receive_ACK(void)
{
	TWCR = _BV( TWINT ) | _BV( TWEA ) | _BV(TWEN) ;
	
	while( !(TWCR & ( 1 << TWINT ) ) ) ;
	return TWDR ;
	
}
uint8_t I2C_receive_NACK(void)
{
	TWCR = _BV( TWINT ) |  _BV(TWEN) ;
	
	while( !(TWCR & ( 1 << TWINT ) ) ) ;
	return TWDR ;
	
}

