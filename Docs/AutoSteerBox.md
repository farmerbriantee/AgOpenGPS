If you follow this documentation you will end up with a box like this:
TODO: Update pictures

![Box 1](Box1.png) ![Box 2](Box2.png)

## AutoSteer box content

| Part                                 | Types                                        | Comments                                                                                  |
|--------------------------------------|----------------------------------------------|-------------------------------------------------------------------------------------------|
| 3D printed holder For F9P            |                                              | Link? Alternative ?                                                                       |
| Micro controller                     | Arduino nano v3                              |                                                                                           |
| IMU                                  | CMPS14, BNO08x                               | Mind the 3,3v vs 5v?? CMPS14 is external?                                                 |
| H-Bridge to drive motor or valve     | Cytron MD13S                                 | Modded?                                                                                   |
| 5v relais for valve                  |                                              | One which can be mounted on the MD30S                                                     |
| Steer switch                         |                                              |                                                                                           |
| Implement switch?                    |                                              |                                                                                           |
| PCB                                  | Kaupoi v4                                    | Needs mod? Also use Original PCBv2?                                                       |
| 12-24v step up converter             |                                              | only for 24v motor                                                                        |
| 9P Circulair connector               | Weipu SP1312 / S 9                           | And Mating part number?                                                                   |
| 4P Circulair power connector         | PartNumber?? And Mating part number?         | May need 5 for valve because of on/of valve. Or put on different connector                |
| Power switch                         | PartNumber??                                 |                                                                                           |
| 2x USB Connector                     | PartNumber??                                 | adafruit 936 or 937? Put USB Hub in the box and use one USB Cable                         |
| Sma extension cord                   | PartNumber??                                 |                                                                                           |
| External led                         | PartNumber??                                 |                                                                                           |
| Aluminum box 100x150                 | Hammond 1455N1602                                 |                                                                                           |
| Suction cup like Benoits  for mount? | PartNumber??                                 | Maybe I like flaps with holes                                                             |



## Power connector pinout

| Pin | Connection |
|-----|------------|
| 01  | GND In     |
| 02  | 12v In     |
| 03  | 24v + / PWM Left  / Danfoss Reference  | 
| 04  | 24v - / PWM Right / Danfoss PWM Signal |
| 05  | Shutoff valve on/off. But where to put its GND  |


## Aux connector pinout

| Pin | Connection |
|-----|------------|
| 01  | WAS +      |
| 02  | WAS SIGNAL |
| 03  | WAS GND (-)|
| 04  | IMP        |
| 05  | IMP GND    |
| 06  | STEER      |
| 07  | STEER GND  |
| 08  | REMOTE     |
| 09  | REMOTE GND |