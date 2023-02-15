using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LUTGenerator {
    public static class Data {
        public const int  PRECISION       = 16;
        public const long ONE             = 1 << PRECISION;

        public const int SIN_VALUE_COUNT     = 0xffffff;
        public const int SIN_COS_VALUE_COUNT = 0xffffff;
        public const int TAN_VALUE_COUNT     = 0xffffff;
        public const int ACOS_VALUE_COUNT    = 0xffffff;
        public const int ASIN_VALUE_COUNT    = 0xffffff;

        public static readonly List<int> SIN_LUT    = new List<int>(SIN_VALUE_COUNT + 1);
        public static readonly List<int> SIN_COS_LUT = new List<int>(SIN_COS_VALUE_COUNT * 2 + 2);
        public static readonly List<int> TAN_LUT    = new List<int>(TAN_VALUE_COUNT + 1);
        public static readonly List<int> ACOS_LUT   = new List<int>(ACOS_VALUE_COUNT + 2);
        public static readonly List<int> ASIN_LUT   = new List<int>(ASIN_VALUE_COUNT + 2);

        public static void CalcSin()
        {
            Parallel.For(0, SIN_COS_VALUE_COUNT, i =>
            {
                var angle = 2 * Math.PI * i / SIN_COS_VALUE_COUNT;

                var sinValue   = Math.Sin(angle);
                var movedSin   = sinValue * ONE;
                var roundedSin = movedSin > 0 ? movedSin + 0.5f : movedSin - 0.5f;
                SIN_LUT.Add((int) roundedSin);
            });
            SIN_LUT.Add(SIN_LUT[0]);
        }
        
        public static void CalcSinCos()
        {
            Parallel.For(0, SIN_COS_VALUE_COUNT, i =>
            {
                var angle = 2 * Math.PI * i / SIN_COS_VALUE_COUNT;

                var sinValue   = Math.Sin(angle);
                var movedSin   = sinValue * ONE;
                var roundedSin = movedSin > 0 ? movedSin + 0.5f : movedSin - 0.5f;
                SIN_COS_LUT.Add((int) roundedSin);

                var cosValue   = Math.Cos(angle);
                var movedCos   = cosValue * ONE;
                var roundedCos = movedCos > 0 ? movedCos + 0.5f : movedCos - 0.5f;
                SIN_COS_LUT.Add((int) roundedCos);
            });
            SIN_COS_LUT.Add(SIN_COS_LUT[0]);
            SIN_COS_LUT.Add(SIN_COS_LUT[1]);
        }
        
        public static void CalcTan()
        {
            Parallel.For(0, TAN_VALUE_COUNT, i =>
            {
                var angle = 2 * Math.PI * i / TAN_VALUE_COUNT;

                var value   = Math.Tan(angle);
                var moved   = value * ONE;
                var rounded = moved > 0 ? moved + 0.5f : moved - 0.5f;
                TAN_LUT.Add((int) rounded);
            });
            TAN_LUT.Add(TAN_LUT[0]);
        }
        
        public static void CalcAcos()
        {
            Parallel.For(0, ACOS_VALUE_COUNT, i =>
            {
                var angle = 2f * i / ACOS_VALUE_COUNT;
                angle -= 1;

                if (i == ACOS_VALUE_COUNT - 1)
                    angle = 1;

                var value   = Math.Acos(angle);
                var moved   = value * ONE;
                var rounded = moved > 0 ? moved + 0.5f : moved - 0.5f;
                ACOS_LUT.Add((int) rounded);
            });
            //Special handling for value of 1, as graph is not symmetric
            ACOS_LUT.Add(ACOS_LUT[ACOS_VALUE_COUNT - 1]);
            ACOS_LUT.Add(ACOS_LUT[ACOS_VALUE_COUNT - 1]);
        }
        
        public static void CalcAsin()
        {
            Parallel.For(0, ASIN_VALUE_COUNT, i =>
            {
                var angle = 2f * i / ASIN_VALUE_COUNT;
                angle -= 1;

                if (i == ASIN_VALUE_COUNT - 1)
                    angle = 1;

                var value   = Math.Asin(angle);
                var moved   = value * ONE;
                var rounded = moved > 0 ? moved + 0.5f : moved - 0.5f;
                ASIN_LUT.Add((int) rounded);
            });
            //Special handling for value of 1, as graph is not symmetric
            ASIN_LUT.Add(ASIN_LUT[ASIN_VALUE_COUNT - 1]);
            ASIN_LUT.Add(ASIN_LUT[ASIN_VALUE_COUNT - 1]);
        }
    }
}