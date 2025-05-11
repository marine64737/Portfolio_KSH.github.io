/*
 * ADC.c
 *
 * Created: 21-04-15 (목) 오후 3:16:15
 *  Author: 조상호
 */ 

#include "ADC.h"

void ADC_init( unsigned char channel)
{
	ADMUX |= (1 << REFS0) ; //외부 AVCC 핀 입력 기준
	
	ADCSRA |= 0x07 ; // 분주율 1024 => 0000 0111 ADPS2 = 1 , ADPS! = 1 , ADPS0 = 1
	ADCSRA |= ( 1 << ADEN ) ; // ADC Enable : ADC 활성화
	ADCSRA |= ( 1 << ADFR ) ; // 단일변환모드 or V 프리러닝모드 
	
	ADMUX = ((ADMUX & 0xe0) | channel ) ; // 채널 선택
	
	ADCSRA |= ( 1 << ADSC ) ; // AD 변환 시작
}

int ADC_read( void )
{
	
	while( !(ADCSRA & (1 << ADIF ) ) ) ; // ADC Interrupt Flag: ADC 변환이 종료되면 1 반환 -> 반환 종료 대기
	return ADC; // 10비트 값을 반환
}