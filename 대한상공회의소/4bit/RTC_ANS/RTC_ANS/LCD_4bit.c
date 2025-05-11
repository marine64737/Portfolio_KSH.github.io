/*
 * LCD.cpp
 *
 * Created: 21-04-13 (화) 오후 3:49:37
 *  Author: 조상호
 */ 
#include "LCD_4bit.h"


uint8_t MODE = 4;

void LCD_pulse_enable( void )
{
	if( MODE == 8){
		PORT_CONTROL |=( 1<< E_pin ) ;
		_delay_ms( 1 );
		PORT_CONTROL &= ~(1 << E_pin ) ;
		_delay_ms( 1 );		
	}
	else
	{
		PORT_CONTROL |= 0x04;
		PORT_CONTROL &= ~0x04;
		_delay_ms( 2 );
	}
	
}

void ToggleEpinOfLCD(void)
{
	ENABLE;
	_delay_us(100);
	DISABLE;
	_delay_us(100);
}

void LCD_write_data ( uint8_t data )
{

		LCD_PORT = (data & 0xF0) | 0x01;
		ENABLE; //E = 1
		DISABLE; //E = 0
		LCD_PORT = ((data << 4) & 0xF0) | 0x01;
		ENABLE; //E = 1
		DISABLE; //E = 0
		_delay_ms(1);

}

void LCD_write_command( uint8_t command )
{
	LCD_PORT = command & 0xF0;
	ENABLE; //E = 1
	DISABLE; //E = 0
	//하위 4BIT 출력
	LCD_PORT = (command << 4) & 0xF0;
	ENABLE; //E = 1
	DISABLE; //E = 0
	_delay_ms(1);
	
}

void LCD_clear( void )
{
	LCD_write_command( COMMAND_CLEAR_DISPLAY ) ;
	_delay_ms( 2 );
}
// LCD초기화
void LCD_init(void)
{
	
	
	_delay_ms(40);
	LCD_PORT &= 0x0F;
	LCD_PORT |= 0x30;
	ToggleEpinOfLCD();
	// 펄스
	_delay_ms(6);
	LCD_PORT &= 0x0F;
	LCD_PORT |= 0x30;
	ToggleEpinOfLCD();
	// 펄스
	_delay_us(300);
	LCD_PORT &= 0x0F;
	LCD_PORT |= 0x30;
	ToggleEpinOfLCD();
	// 펄스
	_delay_ms(2);
	LCD_PORT &= 0x0F;
	LCD_PORT |= 0x20;
	ToggleEpinOfLCD();
	// 펄스
	_delay_ms(2);
	LCD_write_command(0x28);
	LCD_write_command(0x0C);
	LCD_write_command(0x01);
	LCD_write_command(0x06);
}


void LCD_write_string( char *string )
{
	uint8_t i ;
	for( i = 0 ; string[i]!='\0' ; i ++ )
	{
		LCD_write_data( string [i] ) ;
	}
	
}

void LCD_goto_xy( uint8_t row, uint8_t col )
{
	col %= 16 ;
	row %= 2 ;
	
	uint8_t address = ( 0x40 * row	)  + col ;
	uint8_t command = 0x80 + address;
	LCD_write_command( command ) ;
	
}


