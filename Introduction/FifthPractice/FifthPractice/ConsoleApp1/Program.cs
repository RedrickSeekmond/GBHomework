using System;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter data to put it into the file: ");
            StringBuilder sb = new StringBuilder(Console.ReadLine());

            if (sb.Length == 0)
                Console.WriteLine("Input is empty.");
            else
            {
                string fileName = $"C:\\Users\\{Environment.UserName}\\Documents\\OriginalFileNameThatDefinetlyDoesntExistInYourFS.txt";
                File.WriteAllText(fileName, sb.ToString());

                Console.Write($"Data recorded to file: {fileName}.\nFile content: {File.ReadAllText(fileName)}");                
            }
        }
    }
}
