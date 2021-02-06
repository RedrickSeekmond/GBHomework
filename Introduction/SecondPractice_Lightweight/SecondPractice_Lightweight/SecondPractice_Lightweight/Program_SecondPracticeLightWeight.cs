using System;
using System.Collections.Generic;

namespace SecondPractice_Lightweight
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter maximal daily temperature: ");
            var maxTemperature = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter minimal daily temperature: ");
            var minTemperature = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"Average temperature is: {GetAverageTemperature(minTemperature, maxTemperature)}");

            var winterMonthsNums = (1, 2, 12);

            Console.Write("Enter the current month number: ");
            var monthNum = Convert.ToByte(Console.ReadLine());

            Console.Write($"It is {(Months)monthNum} now. ");

            if ((winterMonthsNums.Item1 == monthNum || winterMonthsNums.Item2 == monthNum 
                || winterMonthsNums.Item3 == monthNum) && GetAverageTemperature(minTemperature, maxTemperature) > 0)
                Console.Write("A rainy winter.\n");
            else
                Console.Write("\n");

            if (IsMonthNumEven(monthNum))
                Console.Write($"Your month number ({monthNum}) is even.\n");
            else
                Console.Write($"Your month number ({monthNum}) is odd.\n");
        }

        public static bool IsMonthNumEven(byte monthNum)
        {
            return monthNum % 2 == 0 ? true : false;
        }

        public static double GetAverageTemperature(double minTemperature, double maxTemperature)
        {
            return (maxTemperature + minTemperature) / 2;
        }

        public static double GetAverageTemperature(double[] dailyTemperatures)
        {
            double res = 0;

            foreach (var item in dailyTemperatures)
            {
                res += item;
            }

            return res / dailyTemperatures.Length;
        }
       
    }

    public enum CardPaymentSystems : sbyte
    {
        MasterCard = 1,
        Visa,
        Maestro,
        MIR
    }
    

    public enum Months : byte
    {
        January = 1,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }
}
