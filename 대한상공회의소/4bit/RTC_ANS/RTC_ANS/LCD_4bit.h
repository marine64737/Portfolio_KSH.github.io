/*
 * lcd.h
 *
 * Created: 21-04-13 (화) 오후 3:50:21
 *  Author: 조상호
 */ 
		  			   
#include <avr/io.h>
#include <util/delay.h>

#ifndef LCD_H_
#define LCD_H_
	   
#define COMMAND_CLEAR_DISPLAY 0X01
#define COMMAND_8_BIT_MODE 0X38
#define COMMAND_4_BIT_MODE 0X28
	   
#define COMMAND_DISPLAY_ON_OFF_BIT 2
#define COMMAND_CURSOR_ON_OFF_BIT 1
#define COMMAND_BLINK_ON_OFF_BIT 0


#define RS 0
#define RW 1
#define E_pin 2
#define DDR_DATA    DDRC
#define DDR_CONTROL DDRC
#define PORT_CONTROL    PORTC
#define PORT_DATA	PORTC
#define LCD_PORT_DIR DDRC
#define LCD_PORT PORTC
#define ENABLE PORTC |= 0x04
#define DISABLE PORTC &= ~0x04


void ToggleEpinOfLCD(void);


extern uint8_t MODE;

void LCD_init( void ) ;
void LCD_pulse_enable( void ) ;
void LCD_write_data ( uint8_t data ) ;
void LCD_write_command( uint8_t command ) ;
void LCD_clear( void ) ;
void LCD_write_string( char *string ) ;
void LCD_goto_xy( uint8_t row, uint8_t col );




#endif /* LCD_H_ */