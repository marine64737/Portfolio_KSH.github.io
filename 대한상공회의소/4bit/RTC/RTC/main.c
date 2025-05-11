/*
 * RTC.c
 *
 * Created: 2021-04-24 오후 6:13:21
 * Author : tkdgh
 */ 

#define F_CPU 16000000L
#include <avr/io.h>
#include <avr/interrupt.h>
#include <util/delay.h>
#include <stdio.h>
#include "ADC.h"
#include "I2C.h"
#include "LCD_4bit.h"


#define YEAR	date[6]
#define MONTH	date[5]
#define DAY		date[4]
#define DOW		date[3]
#define HOUR	date[2]
#define MIN		date[1]
#define SEC		date[0]



uint16_t btn[16] =  {
	20,		100,	180,	250,
	320,	390,	460,	520,
	580,	650,	710,	760,
	820,	870,	950,	980
} ;

uint8_t date[] = {00, 00, 12, 2, 1, 1, 16} ;

uint8_t bcd_to_decimal(uint8_t bcd)
{
	return (bcd >> 4) * 10 + (bcd &  0x0F) ;
}
uint8_t decimal_to_bcd(uint8_t decimal)
{
	return ( ((decimal / 10) << 4) | (decimal % 10) ) ;
}
void init_Timer(void)
{
	
	TCCR0 |= (1 << CS02 ) | ( 0<< CS01) | ( 0 << CS00 ); // 분주비 64
	TCCR0 |= ( 1 << WGM01 ) | ( 0 << WGM00 )  ; // CTC
	OCR0 = 250 - 1 ;
	
	TIMSK |= (1 << OCIE0 ) ; // Out Compare Interrupt Enable
}
ISR(TIMER0_COMP_vect)
{
}
void init()
{
	
	DDRA = 0xFF ;
	PORTA = 0xFF ;
	DDRC = 0xFF ;
	PORTC = 0xFF ;
	DDRF = 0x00 ;
	PORTF = 0xFF ;
	ADC_init( 0 ) ;
	I2C_init() ;
	LCD_init() ;
	init_Timer() ;
}
int main(void)
{
	
	char str[80] ;
	
	
	init() ;
	
	I2C_start() ;
	I2C_transmit(I2C_ADDRESS << 1) ;
	I2C_transmit(0) ;
	_delay_ms(100) ;
	for ( int i = 0 ; i < 7 ; i++ )
	{
		I2C_transmit(decimal_to_bcd(date[i])) ;
	}
	I2C_stop() ;
	
	LCD_goto_xy(0,0) ;
	LCD_write_string("Hello world!") ;
	_delay_ms(1000) ;
	
    while (1) 
    {
		LCD_clear() ;
		LCD_goto_xy(0,0) ;
		sprintf( str , "20%02d.%02d.%02d" , YEAR , MONTH , DAY ) ;
		LCD_write_string(str) ;
		_delay_ms(1000) ;
		LCD_goto_xy(1,0) ;
		sprintf( str , "Time: %02d.%02d.%02d" , HOUR , MIN , SEC ) ;
		LCD_write_string(str) ;
		_delay_ms(1000) ;
		
    }
	
	return 0 ;
}

