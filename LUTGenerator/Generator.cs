using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace LUTGenerator
{
    internal class Generator
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("LUT Generator");
            Console.WriteLine("=============");

            Parallel.Invoke(
                CalcSin,
                CalcSinCos,
                CalcTan,
                CalcAcos,
                CalcAsin
            );
            Console.WriteLine("=============");
            Console.WriteLine("LUT Generation Complete");
        }

        static void CalcSin()
        {
            Console.WriteLine("Sin Calc Start");
            Data.CalcSin();
            Writer.Write(Data.SIN_LUT, "SinLut", "Sin");
            Console.WriteLine("Sin Calc End");
        }

        static void CalcSinCos()
        {
            Console.WriteLine("Sin Cos Calc Start");
            Data.CalcSinCos();
            Writer.Write(Data.SIN_COS_LUT, "SinCosLut", "Sin");
            Console.WriteLine("Sin Cos Calc End");
        }

        static void CalcTan()
        {
            Console.WriteLine("Tan Calc Start");
            Data.CalcTan();
            Writer.Write(Data.TAN_LUT, "TanLut", "Sin");
            Console.WriteLine("Tan Calc End");
        }

        static void CalcAcos()
        {
            Console.WriteLine("Acos Calc Start");
            Data.CalcAcos();
            Writer.Write(Data.ACOS_LUT, "AcosLut", "Sin");
            Console.WriteLine("Acos Calc End");
        }

        static void CalcAsin()
        {
            Console.WriteLine("Asin Calc Start");
            Data.CalcAsin();
            Writer.Write(Data.ASIN_LUT, "AsinLut", "Sin");
            Console.WriteLine("Asin Calc End");
        }
    }
}