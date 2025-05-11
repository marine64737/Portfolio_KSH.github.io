/*
 * 0423_01.c
 *
 * Created: 21-04-23 (湲? ?ㅼ쟾 9:03:23
 * Author : 議곗긽??
 */ 

#define F_CPU 16000000L
#include <avr/io.h>
#include "ADC.h"
#include "LCD_4bit.h"
#include "I2C.h"
#include <stdio.h>
#include <util/delay.h>
#include <avr/interrupt.h>




uint16_t btn[16] =  {
	20,		100,	180,	250,
	320,	390,	460,	520,
	580,	650,	710,	760,
	820,	870,	950,	980
} ;

uint8_t date[] = { 00,02,12,06,23,04,21} ;
		
#define YEAR	date[6]
#define MONTH	date[5]
#define DAY		date[4]
#define DOW		date[3]	//Day Of the Week	??????????紐?湲?
#define HOUR	date[2]
#define MIN		date[1]
#define SEC		date[0]


uint8_t i ;	
uint16_t count ;

uint8_t BCD2De( uint8_t bcd)
{
	return ( bcd & 0x0f) + (bcd >> 4) * 10 ;
}

ISR( TIMER0_COMP_vect )
{	
	TCNT0 = 0;
	count ++ ;
	if( count == 500)
	{
		PORTA ^= 0xff;
		I2C_start() ;
		I2C_transmit( I2C_ADDRESS << 1 ) ; //?쎄린紐⑤뱶
		I2C_transmit( 0 ) ;		
		I2C_stop() ;
		
		I2C_start() ;
		I2C_transmit( (I2C_ADDRESS << 1) +1 ) ; //?쎄린紐⑤뱶
		for ( i = 0; i< 6; i++ )
		{
			//date[i] =( I2C_receive_ACK() ) ; 
			date[i] = BCD2De( I2C_receive_ACK() ) ;
		}
		//date[6] =( I2C_receive_NACK() ) ;
		date[6] = BCD2De( I2C_receive_NACK() ) ;
		
		I2C_stop() ;
		count = 0 ;
		
	}
	
}

void init_Timer(void)
{
	TCCR0 |= (1 << CS02 ) | ( 0<< CS01) | ( 0 << CS00 );
	//CTC 紐⑤뱶 ?ㅼ젙
	TCCR0 |= ( 1 << WGM01 ) | ( 0 << WGM00 )  ;
	OCR0 = 250 - 1 ;
	
	TIMSK |= (1 << OCIE0 ) ; // Out Compare Interrupt Enable
}

void init()
{
	
	DDRA = 0xff;
	PORTA = 0xff;
	ADC_init( 0 ) ;
	
	DDRC=0xff; PORTC=0xff;
	DDRF = 0x00;
	PORTF = 0xff ;
	LCD_init() ;
	
	I2C_init();
	
	init_Timer() ;
	
	
}

char* strDOW( uint8_t dow )
{
	
	switch( dow )
	{
		case 0:
		return "SAT" ;
		break;
		case 1:
		return "SUN" ;
		break;
		case 2:
		return "MON" ;
		break;
		case 3:
		return "TUS" ;
		break;
		case 4:
		return "WED" ;
		break;
		case 5:
		return "THUR" ;
		break;
		case 6:
		return "FRI" ;
		break;
		default:
		return "ERR" ;
		break;
	}
} 

int settingMode = 1 ;

void EditTIme(uint8_t locate, int value)
{
	if( value < 0 )	value = 0 ;
	
	date[locate] = value;	
	
	I2C_start() ;
	I2C_transmit( I2C_ADDRESS << 1 ) ; //?곌린紐⑤뱶
	I2C_transmit( 0 ) ;
	for ( i = 0; i< 7; i++ )
	{
		I2C_transmit( D2B(date[i]) ) ;
	}
	I2C_stop() ;
	
	
}

void setTime(uint8_t locate)
{
	
	switch (locate)
	{
		case 0 :
			settingMode *= -1;
			if( settingMode < 0)
			TIMSK &= ~(1 << OCIE0 ) ; // Out Compare Interrupt Enable
			else			
			TIMSK |= (1 << OCIE0 ) ; // Out Compare Interrupt Enable
		break;
		case 2 : EditTIme(0,  (SEC + 1)%60) ; break;
		case 3 : EditTIme(0,  (SEC==0)? 0: SEC - 1 ) ; break;
		
		case 4 : EditTIme(6,  (YEAR + 1)%100) ; break;
		case 5 : EditTIme(6, (YEAR ==0)? 0: YEAR  - 1 ) ; break;
		
		case 6 : EditTIme(1,  (MIN + 1)%60) ; break;
		case 7 : EditTIme(1, (MIN==0)? 0: MIN - 1 ) ; break;
		
		case 8 : EditTIme(5,  (MONTH + 1)%12+1) ; break;
		case 9 : EditTIme(5,  (MONTH==0)? 0: MONTH - 1 ) ; break;
		
		case 10 : EditTIme(2,  (HOUR + 1)%24) ; break;
		case 11: EditTIme(2, (HOUR==0)? 0: HOUR - 1 ) ; break;
		
		case 12 : EditTIme(4,  (DAY + 1)%31+1) ; break;
		case 13 : EditTIme(4, (DAY==0)? 0: DAY - 1 ) ; break;
		
		
		case 15 : EditTIme(3,  (DOW + 1 ) % 7) ; break;
	};
}

void Index_select( uint16_t input )
{
	if( input <btn[0] ){		setTime(0) ;	return ;	}
	else if( input <btn[1] ){	setTime(1) ;	return ;	}
	else if( input <btn[2] ){	setTime(2) ;	return ;	}
	else if( input <btn[3] ){	setTime(3) ;	return ;	}
	else if( input <btn[4] ){	setTime(4) ;	return ;	}
	else if( input <btn[5] ){	setTime(5) ;	return ;	}
	else if( input <btn[6] ){	setTime(6) ;	return ;	}
	else if( input <btn[7] ){	setTime(7) ;	return ;	}
	else if( input <btn[8] ){	setTime(8) ;	return ;	}
	else if( input <btn[9] ){	setTime(9) ;	return ;	}
	else if( input <btn[10] ){	setTime(10) ;	return ;	}
	else if( input <btn[11] ){	setTime(11) ;	return ;	}
	else if( input <btn[12] ){	setTime(12) ;	return ;	}
	else if( input <btn[13] ){	setTime(13) ;	return ;	}
	else if( input <btn[14] ){	setTime(14) ;	return ;	}
	else if( input <btn[15] ){	setTime(15) ;	return ;	}
	else if( input <btn[16] ){	setTime(16) ;	return ;	}


}



int main(void)
{
	
	uint8_t ad_val_l, ad_val_h;
	uint16_t sum = 0;
	char str[20];
	
	
	init() ;
	sei();
	
	LCD_goto_xy(0,0);
	sprintf(str, "%02d/%02d/%02d(%4s)", YEAR, MONTH, DAY, strDOW(DOW) ) ;
	LCD_write_string(str);
	LCD_goto_xy(1,0);
	sprintf(str, "  %2d : %02d : %02d ", HOUR, MIN, SEC) ;
	LCD_write_string(str);
	
	I2C_start() ;
	I2C_transmit( I2C_ADDRESS << 1 ) ; //?곌린紐⑤뱶
	I2C_transmit( 0 ) ;
	for ( i = 0; i< 7; i++ )
	{
		I2C_transmit( D2B(date[i]) ) ;
	}
	I2C_stop() ;
	
    while (1) 
    {
	    ADMUX = 0x00 | 0;
	    
	    ADC_read()	;
	    ad_val_l = ADCL ;
	    ad_val_h = ADCH ;
	    
	    sum = (ad_val_h<<8) | ad_val_l ;
		if(sum < 1010){
			Index_select(sum) ;
			_delay_ms(100) ;
		}
	
		if(settingMode < 0){
			LCD_clear();
			_delay_ms(100) ;
		}
		
	    LCD_goto_xy(0,0);
	    sprintf(str, "%02d/%02d/%02d(%4s)", YEAR, MONTH, DAY, strDOW(DOW)) ;
	    LCD_write_string(str);
	    LCD_goto_xy(1,0);
	    sprintf(str, "  %2d : %02d : %02d ", HOUR, MIN, SEC) ;
	    LCD_write_string(str);
	    _delay_ms(100) ;
    }
}
