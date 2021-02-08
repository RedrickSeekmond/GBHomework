using System;
using System.IO;

namespace FifthPractice_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random randy = new Random((int)DateTime.Now.Ticks);
                        
            var iterationsCount = randy.Next(5, 30);
            byte[] nums = new byte[iterationsCount];

            Console.WriteLine($"Enter {iterationsCount} nums in (0..255) diapazone:");

            for (int i = 0; i < iterationsCount; i++)
            {
                Console.Write($"Enter the {i+1} number:");
                var num = Console.ReadLine();
                var success = Byte.TryParse(num, out nums[i]);

                if (success)
                    Console.WriteLine($"Successfully converted sting \"{num}\" to byte {nums[i]}");
                else
                    Console.WriteLine($"Can't convert string \"{num}\" to byte format. Incorrect symbols or out of range. Replaced with 0.");
            }

            string fileName = $"C:\\Users\\{Environment.UserName}\\Documents\\OriginalFileNameThatDefinetlyDoesntExistInYourFS.bin";
            File.WriteAllBytes(fileName, nums);

            Console.WriteLine($"Data was written to binary file: {fileName}.\nFile content: ");

            foreach (var item in File.ReadAllBytes(fileName))
            {
                Console.Write(item + " ");
            }            
        }
    }
}
