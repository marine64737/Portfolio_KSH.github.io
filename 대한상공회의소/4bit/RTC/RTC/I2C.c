/*
 * I2C.c
 *
 * Created: 21-04-23 (금) 오전 9:56:28
 *  Author: 조상호
 */ 

#include "I2C.h"
#include <avr/io.h>



void I2C_init()
{
	DDRD |= ( 1<< I2C_SCL ) ; // SCL핀을 출력으로 설정
	DDRD |= ( 1<< I2C_SDA ) ; // SDA핀을 출력으로 설정
	
	TWBR = 32 ; //I2C 클록 주파수 설정 200kHz
}

void I2C_start( void ) 
{
	TWCR = _BV( TWINT ) | _BV( TWSTA ) | _BV(TWEN) ; // TWINT:	IWI Interrupt Flag, TWSTA: TWI Start Condition Bit, TWEN: TWI Enable Bit
	
	while( !(TWCR & ( 1 << TWINT ) ) ) ; // 시작 완료 대기
}

void I2C_transmit( uint8_t data )
{
	TWDR = data ;
	TWCR = _BV( TWINT ) | _BV( TWEA ) | _BV(TWEN) ; // TWEA: TWI Enable Acknowledge Bit -> ACK 펄스 생성 제어
	
	while( !(TWCR & ( 1 << TWINT ) ) ) ; // 전송 완료 대기
}

void I2C_stop( void )
{	
	TWCR = _BV( TWINT ) | _BV( TWSTO ) | _BV(TWEN) ; // TWSTO: TWI Stop Condition Bit
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

