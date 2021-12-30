We use the Kaupoi 4.1 PCB for the diagrams, but it can be used for any current PCB, you just have to look at the names of the connections on the PCB. The only difference is that the Kaupoi 4.1 has a slot for the Adafruit BNO085 and a slot for the CMPS14.

Later you will find diagrams to connect any BNO08x that is not from Adafruit. The difference between the BNOs is that Adafruit uses a voltage regulator, and you can supply it from 3V to 5V, and the other BNOs need 3V.  

Although the best way to connect the IMU (BNO or CMPS) to the system is 
through an IMU module, because the IMU data goes directly to AGIO and the 
PCB does not have to process it, and also why you can put the IMU anywhere away from interference, which in the case of CMPS14 can be annoying.

No one should expect anything more then slow filtering and eventual sidehill 
correction when using the IMU on the autosteer board. It’s the worst possible place to put it.

We have two ways to connect all the necessary devices, USB or ethernet 
(UDP). The main difference between the two systems is the USB system uses a HUB and the UDP system uses an Ethernet Switch. Each system also requires the use of different connecting cables.

### Advantages and disadvantages of each system
#### USB pros
- Easy to use, plug in and go
- The tablets we use have at least one USB port
- No need for additional configuration

#### USB cons
- The environment of a tractor is not suitable for USB connection
- Cables often cause failures

![USB System](001-USBSystem.png)

### UDP pros:
- Most reliable system

#### UDP cons:
- You need to configure the network
- Not all tablets have a LAN port, sometimes we have to use a USB-LAN adapter

![UDP System](002-UDPSystem.png)

## 1.- Complete basic system with 12V motor

![Complete Sytem 12V](010-CompleteSytem12V.png)

## 2.- Complete basic system with 24V motor

![Complete Sytem 24V](020-CompleteSytem24V.png)

## 3.- BNO Chinese or Sparkfun (Remember these IMU need 3V)

![BNO Chinese Sparkfun](030-BNOChineseSparkfun.png)

## 4.- Connect a BNO or CMPS to old PCB (like V2)
Remove BNO055 and MMA8452, use pins of MMA to connect BNO or CMPS (3.3V, SDA, SCL 
and GND)

![MMA To Connect BNO or CMPS](040-MMAToConnectBNOorCMPS.png)

## 5.- IMU Module USB

BNO085 Adafruit
![BNO to NANO](050-BNOtoNANO.png)
Remember if you use a Chinese or Sparkfun version connect VCC to 3.3V

CMPS14
![CMPS14 to NANO](055-CMPS14toNANO.png)

## 6.- IMU module UDP

![IMU Module UDP](060-IMUModuleUDP.png)

## 7.- IMU with IC2 extender PCA9615

![IMU With Extender PCA9615](070-IMUWithExtenderPCA9615.png)
Remember if you use a Chinese or Sparkfun version connect VCC to 3.3V

## 8.- Motor wiring to prevent feed back Cytron
When we have the system on, even if the autosteering is not active, the Cytron sends power to the motor, making it difficult to manually actuate the steering. To avoid this problem there are two solutions:

![BackFeed Cytron And Current Sensor](080-BackFeedCytronAndCurrentSensor.png)

You can use a relay to break the circuit between the motor and Cytron, triggered by PWM2. That way there is no braking and no voltage coming back to the Cytron. A 5v Relay module is used, some users report that after a short time the relay stops working due to vibrations and the poor quality of the relay.


The second solution does not require additional wiring, just a bit of skill to carry out the modification.

![Cytron Feed Back Mod](085-CytronFeedBackMod.png)

## 9.- Current sensor
Another extra for the system, it uses a hall sensor (ACS712 20A or 30A) to measure the amperage that the motor is receiving, and from AOG we can set a limit so that it disconnects the motor, so that when we take the steering wheel with our hand disconnect the autosteering.

![Sensor Current](090-SensorCurrent.png)

## 10.- Encoder
An encoder is a sensing device that provides a response, you can use this information to send a command for a particular function. They use different types of technologies to create a signal, including: mechanical, magnetic, optical, and resistance. For example, in optical sensing, the 
encoder provides information based on the interruption of light. We can use an encoder to disable autosteering.

![Sensor Encoder](100-SensorEncoder.png)

## 11.- Electrohydraulic valves

![Electro-HydraulicWithoutRelay](110-Electro-HydraulicWithoutRelay.png)

![Electro-Hydraulic](115-Electro-Hydraulic.png)

## 12.- Danfoss PVE valves

![Danfoss Without Relay](120-DanfossWithoutRelay.png)