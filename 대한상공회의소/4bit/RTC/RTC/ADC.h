/*
 * ADC.h
 *
 * Created: 21-04-15 (목) 오후 3:16:29
 *  Author: 조상호
 */ 


#ifndef ADC_H_
#define ADC_H_

#include <avr/io.h>

void ADC_init( unsigned char channel ) ;
int ADC_read( void ) ;




#endif /* ADC_H_ */