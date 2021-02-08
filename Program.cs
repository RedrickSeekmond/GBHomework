using System;
using System.Text;

namespace SecondPractice_Lightweight_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstProductPrice = 120.39;
            var secondProductPrice = 43.11;
            var summary = firstProductPrice + secondProductPrice;
            
            var firstProductTitle = "Protein";
            var secondProductTitle = "Bread";
            var managerName = "O. J. Baker";
            var shopTitle = "OOO \"Shesterochka\"";

            var mergeSymbolsCount = 15;
            var merge = new StringBuilder("");

            for (int i = 0; i < mergeSymbolsCount; i++)
            {
                merge.Append("-");
            }

            Console.WriteLine($"{shopTitle} shop\nProducts:\n{merge}\n");
            Console.WriteLine($"{firstProductTitle}: {firstProductPrice}\n" +
                $"{secondProductTitle}: {secondProductPrice}\n{merge}\n" +
                $"Sum: {summary}\n{merge}\nManager: {managerName}");
        }
    }    
}
