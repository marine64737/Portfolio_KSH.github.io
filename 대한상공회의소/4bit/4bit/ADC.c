/*
 * ADC.c
 *
 * Created: 2021-04-24 오후 1:02:43
 *  Author: tkdgh
 */ 

#include <avr/io.h>
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