//--------------------------------------------------------------
//  EEPROM Data Handling 7. Maerz 2021
//--------------------------------------------------------------
#define EEPROM_SIZE 1024 //7. Maerz 2021: 2x 376 needed
#define EE_ident1 0xED  // Marker Byte 0 + 1
byte EE_ident2 = vers_nr;


//--------------------------------------------------------------
//  Restore EEprom Data
//--------------------------------------------------------------
void restoreEEprom() {
	Serial.println("read values from EEPROM");
	byte ECheck = EEprom_empty_check();
	if (ECheck == 1 || EEPROM_clear) { //first start?
		EEprom_write_all();     //write default data
		Serial.println("EEPROM write all");
	}
	if (ECheck == 2) { //data available
		EEprom_read_all();
		Serial.println("EEPROM read all");
	}
	if (Set.debugmode) { EEprom_show_memory(); }
}

//--------------------------------------------------------------
byte EEprom_empty_check() {
	if (!EEPROM.begin(EEPROM_SIZE))
	{
		Serial.println("init EEPROM failed"); delay(1000);
		return 0;
	}

	if ((EEPROM.read(0) != EE_ident1) || (EEPROM.read(1) != EE_ident2))
	{
		Serial.println("no valid EEPROM data");
		return 1;  // 1 = is empty
	}
	if ((EEPROM.read(0) == EE_ident1) && (EEPROM.read(1) == EE_ident2))
	{
		if (Set.debugmode) {
			Serial.println("valid EEPROM data found");
		}
		return 2;     // data available
	}
}
//-------------------------------------------------------------------------------------------------

void EEprom_write_all() {
	int leng = sizeof(Set);
	byte tempbyt = EEprom_empty_check();
	if ((tempbyt == 0) || (tempbyt == 1) || (EEPROM_clear)) {
		//EEPROM.put((4 + sizeof(Set)), Set); 
		Serial.print("rewriting EEPROM + write 2. set at #"); Serial.println(4 + leng);
		//write 2. time with defaults to be able to reload them  
		for (int n = 0; n < leng; n++) {
			EEPROM.write(n + 4 + leng, ((unsigned char*)(&Set))[n]);
			delay(2);
		}
		//EEPROM.put(4 + leng, Set);
		delay(50);
		EEPROM.commit();
		delay(50);
		EEPROM.write(0, EE_ident1);	delay(2);
		EEPROM.write(1, EE_ident2); delay(2);
	}
	for (int n = 0; n < leng; n++) {
		EEPROM.write(n + 3, ((unsigned char*)(&Set))[n]);
		delay(2);
	}
	//EEPROM.put(3, Set);
	delay(50);
	EEPROM.commit();
	delay(50);
}
//--------------------------------------------------------------
void EEprom_read_all() {
	int leng =  sizeof(Set);
	Serial.print(leng);
	Serial.println(" Bytes reading from EEPROM ");
	for (int n = 0; n < leng; n++) {
		((unsigned char*)(&Set))[n] = EEPROM.read(n + 3);
	}
	//	EEPROM.get(3, Set);

}
//--------------------------------------------------------------
void EEprom_read_default() {
	int leng = sizeof(Set);
	for (int n = 0; n < leng; n++) {
		((unsigned char*)(&Set))[n] = EEPROM.read(n + 4 + leng);
	}
	//EEPROM.get(4 + sizeof(Set), Set);
	Serial.print("load default value from EEPROM at #"); Serial.println(4 + sizeof(Set));
}

//--------------------------------------------------------------

void EEprom_block_restart() {
	if (EEPROM.read(2) == 0) {//prevents from restarting, when webpage is reloaded. Is set to 0, when other ACTION than restart is called
		EEPROM.write(2, 1);
		delay(2);
		EEPROM.commit();
		delay(50);
	}
}

//--------------------------------------------------------------

void EEprom_unblock_restart() {
	if (EEPROM.read(2) != 0) {
		EEPROM.write(2, 0); // reset Restart blocker
		delay(2);
		EEPROM.commit();
		delay(50);
	}
}

//--------------------------------------------------------------

void EEprom_show_memory() {
	byte c2 = 0, data_;
	Serial.print(EEPROM_SIZE, 1);
	Serial.println(" bytes read from Flash. Values are:");
	for (int i = 0; i < EEPROM_SIZE; i++)
	{
		data_ = byte(EEPROM.read(i));
		if (data_ < 0x10) Serial.print("0");
		Serial.print(data_, HEX);
		if (c2 == 15) {
			Serial.print(" ");
		}
		else if (c2 >= 31) {
			Serial.println(); //NL
			c2 = -1;
		}
		else Serial.print(" ");
		c2++;
	}
}
