/*
 * Timer.c
 *
 * Created: 2021-04-24 오후 1:04:05
 *  Author: tkdgh
 */ 
#include <avr/io.h>

void init_Timer(void)
{
	TCCR1A |= (1<<WGM11);
	TCCR1B |=(1<<WGM12)|(1<<WGM13);
	TCCR1A  |=(1<<COM1A1);
	TCCR1B |=(1<<CS11);
	ICR1=39999;
}

void InitializeTimer(void)
{
	TCCR1A |= (1<<WGM11) ;
	TCCR1B |= (1<<WGM12) | (1<<WGM13) ;
	
	TCCR1A |= (1<<COM1A1) ;
	
	TCCR1B |= (1<<CS11) ;
	
	ICR1 = 39999 ;
}