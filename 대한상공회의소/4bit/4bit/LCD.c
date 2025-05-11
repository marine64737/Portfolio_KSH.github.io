/*
 * LCD.c
 *
 * Created: 2021-04-23 오후 2:21:08
 *  Author: kccistc
 */ 
#include <stdio.h>
#include <util/delay.h>
#include "LCD.h"

void ToggleEpinOfLCD(void)
{
	ENABLE;
	_delay_us(100);
	DISABLE;
	_delay_us(100);
}
//명령어 쓰기 함수
void instruction_out(unsigned char b)
{
	// 상위 4BIT 출력
	LCD_PORT = b & 0xF0;
	ENABLE; //E = 1
	DISABLE; //E = 0
	//하위 4BIT 출력
	LCD_PORT = (b << 4) & 0xF0;
	ENABLE; //E = 1
	DISABLE; //E = 0
	_delay_ms(30);
}
//LCD에 한문자 출력 함수
void char_out(unsigned char b)
{
	LCD_PORT = (b & 0xF0) | 0x01;
	ENABLE; //E = 1
	DISABLE; //E = 0
	LCD_PORT = ((b << 4) & 0xF0) | 0x01;
	ENABLE; //E = 1
	DISABLE; //E = 0
	_delay_ms(30);
}
//문자열 출력 함수
void string_out(char *str)
{
	unsigned int i = 0;
	//NULL 문자를 만날 때 까지 캐릭터 출력
	do{
		char_out(str[i]);
	} while(str[++i]!='\0');
}
// PORT 초기화
void Port_Init(void)
{
	//PORTC 출력
	LCD_PORT_DIR = 0xFF;
	//초기 값
	LCD_PORT = 0x00;
}
// LCD초기화
void init_LCD(void)
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
	instruction_out(0x28);
	instruction_out(0x0C);
	instruction_out(0x01);
	instruction_out(0x06);
}
void LCD_gotoxy(uint8_t row, uint8_t col)
{
	
	col %=16;
	row %=2;
	uint8_t address=(0x40 *row)+col;
	uint8_t command =0x80+address;
	
	instruction_out(command);

/*
	if(col==0) instruction_out(0x80);
	else instruction_out(0xc0);
	*/
}