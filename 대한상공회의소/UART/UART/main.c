/*
 * uC.c
 *
 * Created: 2021-04-13 오후 4:16:11
 * Author : kccistc
 */ 

#define F_CPU 16000000UL
#include <avr/io.h>
#include <util/delay.h>
#include <stdio.h>
#include <string.h>
#include <avr/interrupt.h>

void Putch(char data)
{
	while(!(UCSR1A & 0x20)); //송신완료 flag 비트가 1되면 정지
	UDR1=data;
}

char Getch(void)
{
	while(!(UCSR1A & 0x80)); //수신완료 flag 비트가 1되면 정지
	return UDR1; //UART0번 사용
}
/*
void UART0_init(void) ;
void UART0_transmit(char data) ;
unsigned char UART0_receive(void) ;
*/
	
void UART0_init(void)
{
	UBRR0H = 0x00 ;
	UBRR0L = 207 ;
	
	UCSR0A |= _BV(U2X0) ;
	UCSR0C |= 0x06 ;
	UCSR0B |= _BV(RXEN0) ;
	UCSR0B |= _BV(TXEN0) ;			
}
void UART1_init(void)
{
	UBRR1H = 0x00 ;
	UBRR1L = 207 ;
	UCSR1A=0x00; //flag 레지스터를 사용하지 않음
	UCSR1B=0x18; //수신 enable, 송신 enable, 전송비트 8bit
	UCSR1C=0x06; //비동기식 통신
	UBRR1H=0;
	UBRR1L=103;
}

void UART0_transmit(char data)
{
	while( !(UCSR0A & (1 << UDRE0)) ) ;
	UDR0 = data ;
}

unsigned char UART0_receive(void)
{
	while( !(UCSR0A & ( 1 << RXC0 )) ) ;
	return UDR0 ;
}

void UART1_transmit(char data)
{
	while( !(UCSR1A & (1 << UDRE1)) ) ;
	UDR1 = data ;
}

unsigned char UART1_receive(void)
{
	while( !(UCSR1A & ( 1 << RXC1 )) ) ;
	return UDR1 ;
}
void UART0_print_string(char *str)
{
	for ( int i = 0 ; str[i] ; i++ )
	{
		UART0_transmit(str[i]) ;
	}
}
FILE OUTPUT \
= FDEV_SETUP_STREAM(UART0_transmit, NULL, _FDEV_SETUP_WRITE) ;
FILE INPUT \
= FDEV_SETUP_STREAM(NULL, UART0_receive, _FDEV_SETUP_READ) ;

int count = 0 ;
int main(void)
{
	UART1_init() ;
	stdout = &OUTPUT ;
	stdin = &INPUT ;
	char ch ;
	
	
	
	/*unsigned int count = 0 ;
    while (1) 
    {
		printf( "%d\n\r" , count++ ) ;
		_delay_ms(1000) ;
    }
	*/
	/*char str[100] = "Test String" ;
	
	printf("** Data Type...\n\r") ;
	printf("Integer : %d\n\r" , 128 ) ;
	printf("Float : %f\n\r" , 3.14 ) ;
	printf("String : %s\n\r" , str ) ;
	printf("Character : %c\n\r" , 'A' ) ;
	*/
	while(1) 
	{
		if (Getch()) count = Getch() - 48 ;
		count++ ;
		printf("%d" , count ) ;
		/*
		if ( ch == 's' || ch == 'S' )
		{
			PORTA = 0x55 ;
			_delay_ms( 500 ) ; printf( "Mode S" ) ;
		}
		if ( ch == 'e' || ch == 'E' )
		{
			PORTA = 0xF0 ; printf( "Mode E" ) ;
			_delay_ms( 500 ) ;
		}
		else printf( "Enter Wrong Mode \n\r" ) ;
		*/
		/*
		switch (ch)
		{
			case 's':
			case 'S':
			{PORTA = 0x55 ;
			_delay_ms( 500 ) ; printf( "Mode S" ) ;
			break ;}
			
			case 'e':
			case 'E':
			{PORTA = 0xF0 ; printf( "Mode E" ) ;
			_delay_ms( 500 ) ;
			break ;}
			
			case 'f':
			case 'F':
			{PORTA = 0x0F ; printf( "Mode F" ) ;
				_delay_ms( 500 ) ;
			break ;}
			
			case 'g':
			case 'G':
			{PORTA = 0xAA ; printf( "Mode G" ) ;
				_delay_ms( 500 ) ;
			break ;}
			
			default:
			{
				PORTA = 0x00 ;
				printf( "Enter Wrong Mode \n\r" ) ;
			break;}
		}
		*/
		}
	
	return 0 ;
}