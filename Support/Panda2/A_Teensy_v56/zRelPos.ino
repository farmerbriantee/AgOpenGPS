
void relPosDecode() {

  int carrSoln;
  bool gnssFixOk, diffSoln, relPosValid; //, isMoving, refPosMiss, refObsMiss;
  //bool refPosHeadingValid, relPosNormalized;

  heading  =  (long)ackPacket[24 + 6] ;
  heading += (long)ackPacket[25 + 6] << 8;
  heading += (long)ackPacket[26 + 6] << 16 ;
  heading += (long)ackPacket[27 + 6] << 24 ;
  heading = heading / 10000;

  heading = heading + headingCorrection;
  if (heading >= 3600) heading -= 3600;
  if (heading < 0) heading += 3600;
  heading = heading / 10;

  baseline  =  (long)ackPacket[20 + 6] ;
  baseline += (long)ackPacket[21 + 6] << 8;
  baseline += (long)ackPacket[22 + 6] << 16 ;
  baseline += (long)ackPacket[23 + 6] << 24 ;
  baseline = baseline / 100;
  baseline2 = (long)ackPacket[35 + 6];
  baseline2 =   baseline2 / 10000;
  baseline = baseline + baseline2;

  relPosD  =  (long)ackPacket[16 + 6] ;
  relPosD += (long)ackPacket[17 + 6] << 8;
  relPosD += (long)ackPacket[18 + 6] << 16 ;
  relPosD += (long)ackPacket[19 + 6] << 24 ;
  relPosD = relPosD / 100;
  relPosDH = (long)ackPacket[34 + 6];
  relPosDH = relPosDH / 100000;
  relPosD = relPosD + relPosDH;

  uint32_t flags = ackPacket[60 + 6];

  //  Serial.println(flags, BIN);

  gnssFixOk = flags & (1 << 0);
  diffSoln = flags & (1 << 1);
  relPosValid = flags & (1 << 2);
  carrSoln = (flags & (0b11 << 3)) >> 3;
  //isMoving = flags & (1 << 5);
  //refPosMiss = flags & (1 << 6);
  //refObsMiss = flags & (1 << 7);
  //refPosHeadingValid = flags & (1 << 8);
  //relPosNormalized = flags & (1 << 9);

  if (gnssFixOk && diffSoln && relPosValid)
  {
    //Serial.println("Alles OK! ");
  }
  else
  {
    // Serial.println("Fehler! ");
    return;
  }

  double p = sqrt(baseline * baseline - relPosD * relPosD);

  if (carrSoln == 2) {
    // roll = (atan2(relPosD, baseline)) * 180 / 3.141592653589793238;
    rollDualRaw = (atan(relPosD / p)) * 180 / 3.141592653589793238;
    rollDualRaw *= -1;
    //rollDual = rollDualRaw * 0.5 + rollDual * 0.5;
    rollDual = rollDualRaw;
  }
  else rollDual = rollDual * 0.9;

  imuReader();

  if (carrSoln == 2) 
  {
    isDualNewRelPos = true;
    //Serial.println("Dual Ready1");
  }
}
