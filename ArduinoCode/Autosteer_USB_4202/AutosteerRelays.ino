
/*//High-Active Relays
#define ON  1
#define OFF 0

//Low -Active Relays
//#define ON  0
//#define OFF 1


void SetRelays(void)
 {  // Yes digitalWrite is slower, but much easier for the beginners 
#if defined (RELAY1_PIN)
    if (bitRead(relay,0)) digitalWrite(RELAY1_PIN , ON); else digitalWrite(RELAY1_PIN , OFF);
#endif
#if defined (RELAY2_PIN)
    if (bitRead(relay,1)) digitalWrite(RELAY2_PIN , ON); else digitalWrite(RELAY2_PIN , OFF);
#endif
#if defined (RELAY3_PIN)
    if (bitRead(relay,2)) digitalWrite(RELAY3_PIN , ON); else digitalWrite(RELAY3_PIN , OFF);
#endif
#if defined (RELAY4_PIN)
    if (bitRead(relay,3)) digitalWrite(RELAY4_PIN , ON); else digitalWrite(RELAY4_PIN , OFF);
#endif
#if defined (RELAY5_PIN)
    if (bitRead(relay,4)) digitalWrite(RELAY5_PIN , ON); else digitalWrite(RELAY5_PIN , OFF);
#endif
#if defined (RELAY6_PIN)
    if (bitRead(relay,5)) digitalWrite(RELAY6_PIN , ON); else digitalWrite(RELAY6_PIN , OFF);
#endif    
#if defined (RELAY7_PIN)
    if (bitRead(relay,6)) digitalWrite(RELAY7_PIN , ON); else digitalWrite(RELAY7_PIN , OFF);
#endif
#if defined (RELAY8_PIN)
    if (bitRead(relay,7)) digitalWrite(RELAY8_PIN , ON); else digitalWrite(RELAY8_PIN , OFF);
#endif
  }

void SetuTurnRelays(void)
 {
#if defined (RELAY1_PIN)
    if (bitRead(uTurn,0)) digitalWrite(RELAY1_PIN , ON); else digitalWrite(RELAY1_PIN , OFF);
#endif
#if defined (RELAY2_PIN)
    if (bitRead(uTurn,1)) digitalWrite(RELAY2_PIN , ON); else digitalWrite(RELAY2_PIN , OFF);
#endif
#if defined (RELAY3_PIN)
    if (bitRead(uTurn,2)) digitalWrite(RELAY3_PIN , ON); else digitalWrite(RELAY3_PIN , OFF);
#endif
#if defined (RELAY4_PIN)
    if (bitRead(uTurn,3)) digitalWrite(RELAY4_PIN , ON); else digitalWrite(RELAY4_PIN , OFF);
#endif
#if defined (RELAY5_PIN)
    if (bitRead(uTurn,4)) digitalWrite(RELAY5_PIN , ON); else digitalWrite(RELAY5_PIN , OFF); 
#endif
#if defined (RELAY6_PIN)
    if (bitRead(uTurn,5)) digitalWrite(RELAY6_PIN , ON); else digitalWrite(RELAY6_PIN , OFF);
#endif
#if defined (RELAY7_PIN)
    if (bitRead(uTurn,6)) digitalWrite(RELAY7_PIN , ON); else digitalWrite(RELAY7_PIN , OFF);
#endif
#if defined (RELAY8_PIN)
    if (bitRead(uTurn,7)) digitalWrite(RELAY8_PIN , ON); else digitalWrite(RELAY8_PIN , OFF);
#endif
} 
*/
