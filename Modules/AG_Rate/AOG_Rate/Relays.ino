   void SetRelays(void)
 {  // Yes digitalWrite is slower, but much easier for the beginners 
    if (bitRead(relayLo,0)) digitalWrite(RELAY1_PIN , ON); else digitalWrite(RELAY1_PIN , OFF);
    if (bitRead(relayLo,1)) digitalWrite(RELAY2_PIN , ON); else digitalWrite(RELAY2_PIN , OFF);
    if (bitRead(relayLo,2)) digitalWrite(RELAY3_PIN , ON); else digitalWrite(RELAY3_PIN , OFF);
    if (bitRead(relayLo,3)) digitalWrite(RELAY4_PIN , ON); else digitalWrite(RELAY4_PIN , OFF);
    if (bitRead(relayLo,4)) digitalWrite(RELAY5_PIN , ON); else digitalWrite(RELAY5_PIN , OFF);
    if (bitRead(relayLo,5)) digitalWrite(RELAY6_PIN , ON); else digitalWrite(RELAY6_PIN , OFF);
    if (bitRead(relayLo,6)) digitalWrite(RELAY7_PIN , ON); else digitalWrite(RELAY7_PIN , OFF);
    if (bitRead(relayLo,7)) digitalWrite(RELAY8_PIN , ON); else digitalWrite(RELAY8_PIN , OFF);
    if (bitRead(relayHi,0)) digitalWrite(RELAY9_PIN , ON); else digitalWrite(RELAY9_PIN , OFF);
    if (bitRead(relayHi,1)) digitalWrite(RELAY10_PIN , ON); else digitalWrite(RELAY10_PIN , OFF);
 #if (!EtherNet) 
    if (bitRead(relayHi,2)) digitalWrite(RELAY11_PIN , ON); else digitalWrite(RELAY11_PIN , OFF);
    if (bitRead(relayHi,3)) digitalWrite(RELAY12_PIN , ON); else digitalWrite(RELAY12_PIN , OFF);
 #endif
 }
