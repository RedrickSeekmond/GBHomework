using System;
using System.IO;
using System.Collections.Generic;

namespace FifthPractice_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the path of directory to parse: ");
            GetDirsTreeRecursive(Console.ReadLine(), "");
        }

        static void GetDirsTreeRecursive(string rootDirPath, string pathToFile)
        {
            try
            {
                Console.WriteLine(rootDirPath);

                foreach (string f in Directory.GetFiles(rootDirPath))
                {
                    Console.WriteLine(f);
                }

                foreach (string d in Directory.GetDirectories(rootDirPath))
                {
                    GetDirsTreeRecursive(d, pathToFile);
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }        
    }
}
