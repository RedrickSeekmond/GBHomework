using System;

namespace FirstPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your name: ");

            var username = Console.ReadLine();

            var date = DateTime.Now.ToShortDateString();

            Console.WriteLine($"Hello, {username}! Today is {date}. Or should I call you {Environment.UserName}? :D");

            Console.ReadLine();
        }
    }
}
