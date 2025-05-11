
/*
 * 4bitLcd.c
 *
 * Created: 2021-04-21 오전 11:19:14
 * Author : kccistc
 */ 
#define F_CPU 16000000L
#include <avr/io.h>
#include <util/delay.h>
#include <avr/interrupt.h>
#include <stdio.h>
#include "I2C_RTC.h"
#include "LCD.h"
#include "ADC.h"

#define I2C_SCL	PD0
#define I2C_SDA	PD1
#define I2C_ADDRESS	0x68

#define YEAR	date[6]
#define MONTH	date[5]
#define DAY		date[4]
#define DOW		date[3]
#define HOUR	date[2]
#define MIN		date[1]
#define SEC		date[0]

uint8_t bcd_to_decimal(uint8_t bcd)
{
	return (bcd >> 4) * 10 + (bcd &  0x0F) ;
}
uint8_t decimal_to_bcd(uint8_t decimal)
{
	return ( ((decimal / 10) << 4) | (decimal % 10) ) ;
}

void init(void)
{
	InitializeTimer() ;
	DDRA=0xff; PORTA=0xff;
	DDRB |=(1<<PORTB4); //R/C servo
	DDRC=0xff; PORTC=0xff;
	DDRD=0x00; PORTD=0xff;
	DDRF=0xff; PORTF=0xff;
	/*
	EIMSK =0x03;
	EICRA =0x0a;
*/
	//INIT_INT0() ;
	ADC_init(0);
	init_Timer();
	_delay_ms(100);
	// 포트 초기화 
	Port_Init(); 
	_delay_ms(500); 
	// LCD 초기화 
	init_LCD(); 
	I2C_init() ;

}

void motor_control(void)
{
	/*
	for ( int j = 0 ; j < 10 ; j++ )
			{
				for ( int k = 0 ; k < i ; k++ )
				{
					PORTB = 0x10 ;
					_delay_ms(10) ;
				}
				for ( int k = 0 ; k < 10-i ; k++ )
				{
					PORTB = 0x00 ;
					_delay_ms(10) ;
				}
		}
		*/
		/*
		for ( int i = 0 ; i < 2000 ; i++ )
		{
			PORTE = stepforward() ;
			for ( int x = 0 ; x < cnt ; x++ )
			{
				_delay_ms(1) ;
			}
		}
		_delay_ms(1000) ;
		
		for ( int i = 0 ; i < 2000 ; i++ )
		{
			PORTE = stepbackward() ;
			for ( int x = 0 ; x < cnt ; x++ )
			{
				_delay_ms(1) ;
			}
		}
		_delay_ms(1000) ;
		*/
}

int main(void)
{
	int i, j, k ;
	int read;
	int rc_val;
	char data_arr[80] ;
	
	init() ;

	// 출력문자열 
	/*
	LCD_gotoxy(0,0);
	string_out("Real Time Clock!"); 
	_delay_ms(100) ;
	LCD_gotoxy(0,1);
	string_out("Initializing-"); 
	_delay_ms(1000);
	*/

	
	uint8_t date[] = {00, 00, 12, 2, 1, 1, 16} ;

	I2C_start() ;
	I2C_transmit(I2C_ADDRESS << 1) ;
	I2C_transmit(0) ;
	init_LCD() ;
	LCD_gotoxy(0, 0) ;
	string_out("Setting RTC") ;
	_delay_ms(100) ;
	for ( int i = 0 ; i < 7 ; i++ )
	{
		I2C_transmit(decimal_to_bcd(date[i])) ;
		/*LCD_gotoxy(0, 1) ;
		sprintf( data_arr , "%dth byte written", i+1) ;
		string_out( data_arr ) ;
		_delay_ms(500) ;
		*/
	}
	I2C_stop() ;
	init_LCD() ;
	
	I2C_start() ;
	I2C_transmit( I2C_ADDRESS << 1 ) ;
	I2C_transmit(0) ;
	I2C_stop() ;
	
	I2C_start() ;
	I2C_transmit( (I2C_ADDRESS << 1) + 1 ) ;
	
	init_LCD() ;
	
	for ( i = 0 ; i < 6 ; i++ )
	{
		data_arr[i] = bcd_to_decimal(I2C_receive_ACK()) ;
	}
	data_arr[6] = bcd_to_decimal(I2C_receive_NACK()) ;
	
    while (1) 
    {
		/*
		read=read_ADC();
		i=speed;
		rc_val = read ;
		*/
		LCD_gotoxy(0,0);
		sprintf(data_arr,"%d %d %d" , YEAR , MONTH , DAY );
		string_out(data_arr);
		_delay_ms(100) ;
		LCD_gotoxy(1,0);
		sprintf(data_arr,"%d %d %d" , HOUR , MIN , SEC);
		string_out(data_arr);
		//OCR1A =(rc_val);
 		_delay_ms(100);
		 I2C_stop() ;
		
	}
	
	return 0 ;
}