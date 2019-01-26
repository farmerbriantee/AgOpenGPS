//pwm variables
int pwmDriveLeft = 0, pwmDisplayLeft = 0, driveLeft = 0;
float pValueLeft = 0, iValueLeft = 0, dValueLeft = 0;
byte minPWMValueLeft = 0;

//PID variables
float KoLeft = 1.0f;  //overall gain
float KpLeft = 1.0f;  //proportional gain
float KiLeft = 0.0f;//integral gain
float KdLeft = 0.0f;  //derivative gain

//integral values - **** change as required *****
int maxIntErrLeft = 200; //anti windup max
int maxIntegralValueLeft = 20; //max PWM value for integral PID component

//error values
float lastErrorLeft = 0, lastLastErrorLeft = 0, integrated_errorLeft = 0, dErrorLeft = 0;

//zero crossing for integrator
byte currentSignLeft = 0, prevSignLeft = 0;

//pwm variables
int pwmDriveRight = 0, pwmDisplayRight = 0, driveRight = 0;
float pValueRight = 0, iValueRight = 0, dValueRight = 0;
byte minPWMValueRight = 0;

//PID variables
float KoRight = 1.0f;  //overall gain
float KpRight = 1.0f;  //proportional gain
float KiRight = 0.0f;//integral gain
float KdRight = 0.0f;  //derivative gain

//integral values - **** change as required *****
int maxIntErrRight = 200; //anti windup max
int maxIntegralValueRight = 20; //max PWM value for integral PID component

//error values
float lastErrorRight = 0, lastLastErrorRight = 0, integrated_errorRight = 0, dErrorRight = 0;

//zero crossing for integrator
byte currentSignRight = 0, prevSignRight = 0;

//Kalman variables Left
float rateKLeft = 0;
float PcLeft = 0.0;
float GLeft = 0.0;
float PLeft = 1.0;
float XpLeft = 0.0;
float ZpLeft = 0.0;
float XeRateLeft = 0; //the filtered flowrate
const float varRateLeft = 100; // variance, smaller, more filtering
const float varProcessLeft = 10;

//Kalman variables Right
float rateKRight = 0;
float PcRight = 0.0;
float GRight = 0.0;
float PRight = 1.0;
float XpRight = 0.0;
float ZpRight = 0.0;
float XeRateRight = 0; //the filtered flowrate
const float varRateRight = 100; // variance, smaller, more filtering
const float varProcessRight = 10;

//program flow
bool isDataFound = false, isSettingFound = false;
int header = 0, tempHeader = 0;

//bit 0 is section 0
byte relayHi = 0, relayLo = 0;
byte uTurn = 0;

float groundSpeed = 0; //speed from AgOpenGPS is multiplied by 4

float rateSetPointLeft = 0.0;
float rateSetPointRight = 0.0;

float countsThisLoopLeft = 0;
float countsThisLoopRight = 0;

float rateErrorLeft = 0; //for PID
float rateErrorRight = 0; //for PID

//Actual Applied rates
int rateAppliedLPMLeft = 0;
int rateAppliedLPMRight = 0;

//used to calculate delivered volume
unsigned long accumulatedCountsLeft = 0;
unsigned long accumulatedCountsRight = 0;

float pulseAverageLeft = 0;
float pulseAverageRight = 0;

float flowmeterCalFactorLeft = 500;
float flowmeterCalFactorRight = 500;
