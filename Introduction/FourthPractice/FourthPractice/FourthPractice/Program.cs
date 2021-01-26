using System;
using System.Text;

namespace FourthPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var randy = new Random((int)DateTime.Now.Ticks);

            var names = new string[5]
                {
                    "Alan",
                    "Rick",
                    "Morty",
                    "Derrick",
                    "Abbie"
                };
            var surnames = new string[5]
                {
                    "Johnson",
                    "Brown",
                    "Armstrong",
                    "Carrie",
                    "Cumberbatch"
                };
            var patronymics = new string[5]
                {
                    "Ahr",
                    "Gustav",
                    "Lederrick",
                    "Bernard",
                    "Tommie"
                };

            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine(GetFullName(names[randy.Next(0, 4)],
                    surnames[randy.Next(0, 4)], patronymics[randy.Next(0, 4)]));
            }

            Console.WriteLine("\n\n//Second task\n");
            Console.Write("Enter nums sequence to sum: ");
            Console.WriteLine(GetSum(Console.ReadLine()));

            Console.WriteLine("\n\n//Third task\n");

            var monthNum = 0;
            Console.Write("Enter the month num: ");
            monthNum = Convert.ToInt32(Console.ReadLine());

            while (monthNum < 1 || monthNum > 12)
            {
                Console.WriteLine("Error. Incorrect month num. Try again.");
                Console.Write("Enter the month num: ");
                monthNum = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine(GetCurrentSeason(monthNum));


            Console.WriteLine("\n\nFibonacci task\n");
            Console.Write("Enter the num to calculate fibonacci progression: ");
            Console.WriteLine(GetFibonacciRecursive(Convert.ToInt32(Console.ReadLine())));
        }

        static string GetFullName(string firstName, string lastName, string patronymic)
        {
            return $"{firstName} {patronymic} {lastName}";
        }

        static int GetSum(string nums)
        {
            var sb = new StringBuilder();
            var sum = 0;
            nums += " ";

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != ' ')
                {
                    while (nums[i] != ' ')
                    {
                        sb.Append(nums[i]);
                        i++;
                    }

                    sum += Convert.ToInt32(sb.ToString());
                    sb.Clear();
                }                
            }

            return sum;
        }

        static string GetCurrentSeason(int monthNum)
        {
            if (monthNum == 1 || monthNum == 2 || monthNum == 12)
            {
                return $"It is {Seasons.Winter.ToString()} now";
            }
            else if (monthNum == 3 || monthNum == 4 || monthNum == 5)
            {
                return $"It is {Seasons.Spring.ToString()} now";
            }
            else if (monthNum == 6 || monthNum == 7 || monthNum == 8)
            {
                return $"It is {Seasons.Summer.ToString()} now";
            } 
            else 
            {
                return $"It is {Seasons.Autumn.ToString()} now";
            }
        }

        static int GetFibonacciRecursive(int value)
        {
            if (value == 0)
                return 0;
            else if (value == 1)
                return 1;

            return GetFibonacciRecursive(value - 1) + GetFibonacciRecursive(value - 2);
        }
    }

    public enum Seasons
    {
        Winter,
        Spring, 
        Summer,
        Autumn
    }

    public enum Winter
    {
        January = 1,
        February,
        December = 12
    }

    public enum Spring
    {
        March = 3,
        April,
        May
    }

    public enum Summer
    {
        June = 6,
        July,
        August,
    }

    public enum Autumn
    {
        September = 9,
        October,
        November
    }
}
