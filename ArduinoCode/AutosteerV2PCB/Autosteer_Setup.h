//##########################################################################################################
//### Setup Zone ###########################################################################################
//##########################################################################################################

  #define GPS_Refresh 10                 // Enter the Hz refresh rate, example 5 or 10 or 8 with ublox
                                         // Best is leave it at 10
                                        
  #define Motor_Valve_Driver_Board 1    // 1 =  Steering Motor/valves + Cytron MD30C, MD13A Driver
                                        // 2 =  Steering Motor/valves + IBT 2  Driver
                                
  #define A2D_Convertor_Mode 1          // 0 = No ADS, connect Wheel Angle Sensor (WAS) to Arduino A0
                                            // Really try to use the ADS, it is much much better.
                                        // 1 = ADS1115 Single Input Mode - Connect Signal to A0
                                            // These sensors are DIY installed ones.
                                        // 2 = ADS1115 Differential Mode - Connect Sensor GND to A1, Signal to A0
                                            // These sensors are factory installed and powered by tractor oem wiring.
  
  #define SteerPosZero 512             //adjust linkage as much as possible to read 0 degrees when wheels staight ahead 
                                        // Set to 1660 if using the ADS
                                        // Set to 512 if using the Arduino A0                                      
                               
  #define WAS_Invert 0                  // set to 1 to Change Direction of Wheel Angle Sensor, must be positive turning right 
  
  #define Motor_Direction_Invert 0      // 1 = reverse output direction (Valve & Motor) 0 = Normal

  #define SwitchOrButton 1              // set to 0 to use steer switch as switch
                                        // set to 1 to use steer switch as button
                                        // Button/switch pulls pin low to activate
 
  #define BNO_Installed 0               // set to 1 to enable BNO055 IMU, otherwise set to 0 for none
  
  #define Inclinometer_Installed 0      // set to 0 for none
                                        // set to 1 if DOGS2 Inclinometer is installed and connected to ADS pin A2
                                        // set to 2 if MMA8452 installed GY-45 (1C)
                                        // set to 3 if MMA8452 installed Sparkfun, Adafruit MMA8451 (1D)
                                        // set to 4 if DOGS2 installed and connected to Arduino pin A1
                                                                           
                                        // Depending on board orientation, choose the right Axis for MMA, 
                                        // arrow shaft on MMA points in same direction as axle
  #define UseMMA_X_Axis 1               // Set to 0 to use X axis of MMA
                                        // Set to 1 to use Y axis of MMA

  #define Roll_Invert 0                 // Roll to the right must be positive
                                        // Set to 1 if roll to right shows negative, otherwise set to 0

  #define Relay_Type 0    // set to 0 for No Relays
                          // set to 1 for Section Relays
                          // set to 2 for uTurn Relays
  
  #define EtherNet 0      // 0 = Serial/USB communcation with AOG
                          // 1 = Ethernet comunication with AOG (using a ENC28J60 chip)
                          
  #define CS_Pin 10       // Arduino Nano = 10 depending how CS of Ethernet Controller ENC28J60 is Connected

  #define   MaxSpeed  20     // km/h  above -> steering off
  #define   MinSpeed  1      // km/h  below -> sterring off (minimum = 0.25)


  //##########################################################################################################
  //### End of Setup Zone ####################################################################################
  //##########################################################################################################
