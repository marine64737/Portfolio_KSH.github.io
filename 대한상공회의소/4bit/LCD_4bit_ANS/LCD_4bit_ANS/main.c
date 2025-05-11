
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

#define LCD_PORT_DIR DDRC 
#define LCD_PORT PORTC  
#define ENABLE PORTC |= 0x04  
#define DISABLE PORTC &= ~0x04  

ISR(INT0_vect) 
{ 
	PORTA=0xaa; 
} 
ISR(INT1_vect) 
{ 
	PORTA=0x55; 
} 
void ToggleEpinOfLCD(void)  
{ 
	ENABLE; 
	 _delay_us(100);  
	DISABLE;  
	_delay_us(100);  
}  
//명령어 쓰기 함수  
void instruction_out(unsigned char b)  
{ // 상위 4BIT 출력  
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
{ /*
	col %=16;
	row %=2;
	uint8_t address=(0x40 *row)+col;
	uint8_t command =0x80+address;

	instruction_out(command);
*/
	if(col==0) instruction_out(0x80);
	else instruction_out(0xc0);
}
void ADC_init(unsigned char channel)
{
	ADMUX =(1<<REFS0);
	ADCSRA |=0x07;
	ADCSRA |=(1<<ADEN);
	ADCSRA |= (1<<ADFR);
	ADMUX=((ADMUX & 0xE0)|channel);
	ADCSRA |= (1<<ADSC);
}
int read_ADC(void)
{
	while(!(ADCSRA & (1<<ADIF)));
	return ADC;
}
void init_Timer(void)
{
	TCCR1A |= (1<<WGM11);
	TCCR1B |=(1<<WGM12)|(1<<WGM13);
	TCCR1A  |=(1<<COM1A1);
	TCCR1B |=(1<<CS11);
	ICR1=39999;
}
int main(void)
{
	int read;
	int rc_val;
	char data[80];

	DDRA=0xff; PORTA=0xff;
	DDRB |=(1<<PORTB5); //R/C servo
	DDRC=0xff; PORTC=0xff;
	DDRD=0x00; PORTD=0xff;
	DDRF=0xff; PORTF=0xff;

	EIMSK =0x03;
	EICRA =0x0a;

	ADC_init(0);
	init_Timer();
	_delay_ms(100); 
	// 포트 초기화  
	Port_Init();  
	_delay_ms(500);  
	// LCD 초기화  
	init_LCD();  
	// 출력문자열  
	LCD_gotoxy(0,0); 
	string_out("LCD Test Mode!");  
	LCD_gotoxy(0,1); 
	string_out("Now Init--"); 
	_delay_ms(1000);

    sei();
    while (1) 
    {
     read=read_ADC();
     rc_val=(int)read+1000;
     OCR1A =(rc_val);
     LCD_gotoxy(0,1);
     sprintf(data,"AD Val=%5d",rc_val);
     string_out(data);
     _delay_ms(10); 
    }
}

