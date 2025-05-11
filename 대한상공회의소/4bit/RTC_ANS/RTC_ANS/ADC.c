/*
 * ADC.c
 *
 * Created: 21-04-15 (목) 오후 3:16:15
 *  Author: 조상호
 */ 

#include "ADC.h"

void ADC_init( unsigned char channel)
{
	ADMUX |= (1 << REFS0) ;
	
	ADCSRA |= 0x07 ;
	ADCSRA |= ( 1 << ADEN ) ;
	ADCSRA |= ( 1 << ADFR ) ;
	
	ADMUX = ((ADMUX & 0xE0) | channel ) ;
	
	ADCSRA |= ( 1 << ADSC ) ;
	
}

int ADC_read( void )
{
	
	while( !(ADCSRA & (1 << ADIF ) ) ) ;
	return ADC;
	
}