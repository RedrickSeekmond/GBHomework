using System;
using System.IO;

namespace FifthPractice_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var startupTime = DateTime.Now.ToLocalTime().TimeOfDay.ToString() + ":program started.";

            string fileName = $"C:\\Users\\{Environment.UserName}\\Documents\\OriginalFileNameThat" +
                $"ContainsProgramStartUpTimeAndDefinetlyDoesntExistInYourFS.txt";

            File.AppendAllText(fileName, $"{startupTime}\n");

            Console.WriteLine("Current startup time appended.");
        }
    }
}
