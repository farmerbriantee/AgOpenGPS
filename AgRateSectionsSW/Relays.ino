   void SetRelays(void)
 {
    if (SectSprayONHIGH) {
      //if Sections should be ON on HIGH signal
      if (bitRead(RelayOUT,0)) bitSet(PORTD, 4); //Digital Pin 4
      else bitClear(PORTD, 4); 
      if (bitRead(RelayOUT,1)) bitSet(PORTD, 5); //Digital Pin 5
      else bitClear(PORTD, 5); 
      if (bitRead(RelayOUT,2)) bitSet(PORTD, 6); //Digital Pin 6
      else bitClear(PORTD, 6); 
      if (bitRead(RelayOUT,3)) bitSet(PORTD, 7); //Digital Pin 7
      else bitClear(PORTD, 7); 
      if (bitRead(RelayOUT,4)) bitSet(PORTB, 0); //Digital Pin 8
      else bitClear(PORTB, 0); 
      if (bitRead(RelayOUT,5)) bitSet(PORTB, 1); //Digital Pin 9
      else bitClear(PORTB, 1); 
      if (bitRead(RelayOUT,6)) bitSet(PORTB, 2); //Digital Pin 10
      else bitClear(PORTB, 2); 
    }
    else {
      //if Sections should be ON on LOW signal
      if (bitRead(RelayOUT,0)) bitClear(PORTD, 4); //Digital Pin 4
      else bitSet(PORTD, 4); 
      if (bitRead(RelayOUT,1)) bitClear(PORTD, 5); //Digital Pin 5
      else bitSet(PORTD, 5); 
      if (bitRead(RelayOUT,2)) bitClear(PORTD, 6); //Digital Pin 6
      else bitSet(PORTD, 6); 
      if (bitRead(RelayOUT,3)) bitClear(PORTD, 7); //Digital Pin 7
      else bitSet(PORTD, 7); 
      if (bitRead(RelayOUT,4)) bitClear(PORTB, 0); //Digital Pin 8
      else bitSet(PORTB, 0); 
      if (bitRead(RelayOUT,5)) bitClear(PORTB, 1); //Digital Pin 9
      else bitSet(PORTB, 1); 
      if (bitRead(RelayOUT,6)) bitClear(PORTB, 2); //Digital Pin 10
      else bitSet(PORTB, 2); 
    }  
 
  }
