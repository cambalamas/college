void interrupt()
{
 INTCON.INT0IF = 0;
 if(PORTB.B1 == 1) PORTB.B1 = 0;
 else PORTB.B1 = 1;
}

void main()
{
      TRISB.B0= 0x01;
      TRISB.B1= 0;
      PORTB.B1= 0;

      INTCON2 = 0;
      INTCON.INT0IF = 0;
      INTCON.INT0IE = 0x01;
      INTCON.GIE = 0x01;

      while(1)
      {
       asm nop;
      }

}