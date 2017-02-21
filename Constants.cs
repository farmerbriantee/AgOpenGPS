using System;

namespace AgOpenGPS
{
    public class Constants
    {
        public const byte SET_1 = 1;
        public const byte SET_2 = 2;
        public const byte SET_3 = 4;
        public const byte SET_4 = 8;
        public const byte SET_5 = 16;

        public const byte RESET_1 = 254;
        public const byte RESET_2 = 253;
        public const byte RESET_3 = 251;
        public const byte RESET_4 = 247;
        public const byte RESET_5 = 239;

        public static double InchesToMetres = 0.0254;
        public static double MetresToInches = 39.3701;
        public static double SquareMetreToAcre = 0.00024710499815078974633856493327535;

        public static double PiDoubled = Math.PI * 2; //6.2857142857142857142857142857143;

        public static double PiHalved = Math.PI / 2; // 1.5714285714285714285714285714286;


    }
}
