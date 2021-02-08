using System;
using System.Diagnostics;
using System.Text;

namespace SixthPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            
            InitTaskManager();
        }

        static void InitTaskManager()
        {
            var man = "\n\n\"kill -n <process name>\": kills the process with name <process name>\n" +
                "\"kill -i <process id>\": kills the process with id <process id> \n-h: help\n-s: show processes\n\"Ctrl+C=quit\"\n\n";

            Console.WriteLine(man);

            do
            {
                var input = Console.ReadLine().Split(" ");

                if (input[0] == "kill")
                {
                    switch (input[1])
                    {
                        case "-i":
                            {
                                int id = int.MinValue;
                                int.TryParse(input[2], out id);

                                var process = Process.GetProcessById(id);

                                if (process != null)
                                {
                                    process.Kill();
                                    Console.WriteLine($"Process {input[2]} successfully killed");
                                }
                                else
                                {
                                    Console.WriteLine("There is no process with this id.");
                                }
                                break;
                            };

                        case "-n":
                            {
                                var processes = Process.GetProcessesByName(input[2]);

                                if (processes.Length > 0)
                                {
                                    foreach (var proc in processes)
                                    {
                                        proc.Kill();
                                    }

                                    Console.WriteLine($"Processes \"{input[2]}\" successfully killed");
                                }
                                else
                                {
                                    Console.WriteLine("There is no processes with this name.");
                                }
                                break;
                            };
                        default:
                            {
                                Console.WriteLine($"Unknown command.{man}");
                                break;
                            }
                    }
                }
                else if (input[0] == "-h")
                {
                    Console.WriteLine(man);
                }
                else if (input[0] == "-s")
                {
                    var processes = Process.GetProcesses();
                    var spaceBetweenColumns = GetSpaceBetweenColumns(GetLongestProcessId(processes));

                    CreateConsoleHeader(spaceBetweenColumns);
                    FillProcessesTable(processes, spaceBetweenColumns);
                }
                else
                {
                    Console.WriteLine($"Unknown command.{man}");
                }

            } while (true);//user will invoke exit event on pressing ctrl+c if he wants to. (вроде комментарии исключительно на английском обычно тоже пишут, если я праильно помню)    
            
        }

        static void CreateConsoleHeader(string spaceBetweenColumns)
        {
            Console.Write($"Process ID{spaceBetweenColumns}");

            Console.Write($"Process name{spaceBetweenColumns}\n\n");
        }

        
        static string GetSpaceBetweenColumns(int maxProcessIdLength)
        {
            if (maxProcessIdLength <= 0)
                return "";

            var sb = new StringBuilder();

            for (int i = 0; i < maxProcessIdLength; i++)
            {
                sb.Append($" ");
            }

            return sb.ToString();
        }

        static void FillProcessesTable(Process[] processes, string spaceBetweenColumns)
        {
            foreach (var process in processes)
            {
                var additionalAlingment = GetAdditionalAlingment(spaceBetweenColumns.Length, process.Id.ToString().Length);
                Console.Write($"{process.Id}{spaceBetweenColumns}{additionalAlingment}{process.ProcessName}\n");
            }
        }

        static int GetLongestProcessId(Process[] processes)
        {
            if (processes.Length <= 0)
                return 0;

            var maxProcessIdLength = processes[0].Id.ToString().Length;

            for (int i = 1; i < processes.Length; i++)
            {
                if (processes[i].Id.ToString().Length > maxProcessIdLength)
                    maxProcessIdLength = processes[i].Id.ToString().Length;
            }

            return maxProcessIdLength;
        }

        static string GetAdditionalAlingment(int maxProcessIdLength, int currentProcessIdLength)
        {
            if (maxProcessIdLength <= 0 || currentProcessIdLength <= 0)
                return "";

            var sb = new StringBuilder();

            for (int i = 0; i < maxProcessIdLength - currentProcessIdLength; i++)
            {
                sb.Append($" ");
            }

            return sb.ToString();
        }
    }
}
