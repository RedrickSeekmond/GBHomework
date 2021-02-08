using System;
using System.Text;

namespace ThirdPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var randy = new Random((int)DateTime.Now.Ticks);

            StartFirstTask(randy);

            StartSecondTask(randy);

            StartThirdTask(randy);

            StartShipWarsTask(randy);
        }

        static void StartFirstTask(Random randy)
        {
            Console.WriteLine("//First task\n");

            var rows = randy.Next(4, 10);
            var columns = rows;

            var matrix = new int[rows, columns];

            Console.WriteLine("Your matrix:");

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = randy.Next(-30, 30);

                    Console.Write($"  {matrix[i, j]}  ");
                }

                Console.WriteLine("\n");
            }

            Console.WriteLine("Main diagonal: ");

            for (int i = 0; i < rows; i++)
            {
                Console.Write($" {matrix[i, i]} ");
            }

            Console.WriteLine("\nSide diagonal: ");

            for (int i = 0; i < rows; i++)
            {
                Console.Write($" {matrix[i, matrix.GetLength(1) - i - 1]} ");
            }
        }

        static void StartSecondTask(Random randy)
        {
            Console.WriteLine("\n\n//Second task\n");

            var matrix = new string[5, 2];

            var names = new string[5]
            {
                "Jack",
                "Connor",
                "Liam",
                "John",
                "Harry"
            };

            Console.WriteLine("Your phonebook: ");

            for (int i = 0; i < 5; i++)
            {
                matrix[i, 0] = names[i];
                matrix[i, 1] = GetPhoneNum(randy);

                for (int j = 0; j < 2; j++)
                {
                    Console.Write($"{ matrix[i, j]} ");
                }

                Console.WriteLine();
            }
        }

        static string GetPhoneNum(Random randy)
        {
            StringBuilder sb = new StringBuilder("+79");

            for (int i = 0; i < 9; i++)
            {
                sb.Append(randy.Next(0, 9).ToString());
            }

            return sb.ToString();
        }

        static void StartThirdTask(Random randy)
        {
            Console.WriteLine("\n\n\n//Third task\n");

            Console.Write("Enter a word or sentence: ");
            var sb = new StringBuilder(Console.ReadLine());

            for (int i = sb.Length - 1; i >= 0; i--)
            {
                Console.Write(sb[i]);
            }
        }


        static void StartShipWarsTask(Random randy)
        {
            Console.WriteLine("\n\nShipWarsTask\n");

            var battlefield = new string[10, 10];

            for (int i = 0; i < battlefield.GetLength(0); i++)
            {
                for (int j = 0; j < battlefield.GetLength(1); j++)
                {
                    battlefield[i, j] = "O";
                }
            }

            battlefield[0, 1] = "X";
            battlefield[7, 8] = "X";
            battlefield[2, 8] = "X";
            battlefield[7, 3] = "X";

            for (int i = 5; i < 7; i++)
            {
                battlefield[8, i] = "X";
            }

            for (int i = 1; i < 3; i++)
            {
                battlefield[5, i] = "X";
            }

            for (int i = 4; i < 6; i++)
            {
                battlefield[6, i] = "X";
            }

            for (int i = 3; i < 6; i++)
            {
                battlefield[2, i] = "X";
            }

            for (int i = 7; i < 10; i++)
            {
                battlefield[4, i] = "X";
            }

            for (int i = 0; i < 4; i++)
            {
                battlefield[9, i] = "X";
            }

            for (int i = 0; i < battlefield.GetLength(0); i++)
            {
                for (int j = 0; j < battlefield.GetLength(1); j++)
                {
                    Console.Write($"{battlefield[i, j]}");
                }
                Console.WriteLine();
            }
        }        
    }
}
