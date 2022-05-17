void EthernetStart()
{
#ifdef ARDUINO_TEENSY41
  // Set send_Data_Via to 1 to use Ethernet.
  send_Data_Via = 1;
  
  // start the Ethernet connection:
  Serial.println("Initializing ethernet with static IP address");

  // try to congifure using IP:
  Ethernet.begin(mac,0);          // Start Ethernet with IP 0.0.0.0

  // Check for Ethernet hardware present
  if (Ethernet.hardwareStatus() == EthernetNoHardware) 
  {
    Serial.println("Ethernet shield was not found. GPS via USB only.");
    send_Data_Via = 0;

    return;
  }

  if (Ethernet.linkStatus() == LinkOFF) 
  {
    Serial.println("Ethernet cable is not connected - Who cares we will start ethernet anyway.");
  }

  Ethernet.setLocalIP(Eth_myip);  // Change IP address to IP set by user
  Serial.println("\r\nEthernet status OK");
  Serial.print("IP set Manually: ");
  Serial.println(Ethernet.localIP());

  // Send data through UDP not USB
  send_Data_Via = 1;
  Ethernet_running = true;
  
  // Get local address and generate destination IP
  for (byte n = 0; n < 3; n++)
  {
    Eth_myip[n] = Ethernet.localIP()[n];
    Eth_ipDestination[n] = Ethernet.localIP()[n];
  }

  Eth_ipDestination[3] = 255;

  // Ethernet_running = true;
  Serial.print("\r\nEthernet IP of module: "); Serial.println(Ethernet.localIP());
  Serial.print("Ethernet sending to IP: "); Serial.println(Eth_ipDestination);
  Serial.print("All data sending to port: "); Serial.println(portDestination);

  // init UPD Port sending to AOG
  if (Eth_udpPAOGI.begin(portMy))
  {
    Serial.print("Ethernet GPS UDP sending from port: ");
    Serial.println(portMy);
  }

  // init UPD Port getting NTRIP from AOG
  if (Eth_udpNtrip.begin(AOGNtripPort)) // AOGNtripPort
  {
    Serial.print("Ethernet NTRIP UDP listening to port: ");
    Serial.println(AOGNtripPort);
  }

  // init UPD Port getting AutoSteer data from AOG
  if (Eth_udpAutoSteer.begin(AOGAutoSteerPort)) // AOGAutoSteerPortipPort
  {
    Serial.print("Ethernet AutoSteer UDP listening to & send from port: ");
    Serial.println(AOGAutoSteerPort);
  }
 #endif
}
