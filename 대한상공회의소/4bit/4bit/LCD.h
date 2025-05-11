/*
 * LCD.h
 *
 * Created: 2021-04-23 오후 2:22:29
 *  Author: kccistc
 */ 


#ifndef LCD_H_
#define LCD_H_

#include <avr/io.h>
#define LCD_PORT_DIR DDRC
#define LCD_PORT PORTC
#define ENABLE PORTC |= 0x04
#define DISABLE PORTC &= ~0x04

void ToggleEpinOfLCD(void) ;
void instruction_out(unsigned char b) ;
void char_out(unsigned char b) ;
void string_out(char *str) ;
void Port_Init(void) ;
void init_LCD(void) ;
void LCD_gotoxy(uint8_t row, uint8_t col) ;

#endif /* LCD_H_ */