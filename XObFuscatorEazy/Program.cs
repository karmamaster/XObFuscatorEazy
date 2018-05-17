using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XObFuscatorEazy
{
    class Program
    {
        static string obFolder = AppDomain.CurrentDomain.BaseDirectory + @"\obTarget";
        static string outputFolder = AppDomain.CurrentDomain.BaseDirectory + @"\obfuscated";
        static string XFuscatorLib = AppDomain.CurrentDomain.BaseDirectory + @"XFuscatorLib\XFuscator.lua";
        static string lua = AppDomain.CurrentDomain.BaseDirectory + @"XFuscatorLib\lua53.exe";
        static string workingDir = AppDomain.CurrentDomain.BaseDirectory + @"XFuscatorLib";

        static void Main(string[] args)
        {
            Console.WriteLine("**************** EZ LUA X OBFUSCATOR - KRAKEN HEAD - THANKS TO efrederickson *****************");
            Console.WriteLine("1. Start Obfuscate");
            Console.WriteLine("2. Exit");
            Console.Write("Choose: ");
            Console.Out.Flush();
            var input = Console.ReadLine();
            if (input == "1")
            {
                string[] files = getFileFromFolder(obFolder);
                foreach (string file in files)
                {
                    Console.WriteLine();
                    Console.WriteLine("****************** Starting to ob ******************************");
                    Console.WriteLine("Obfurscating: " + Path.GetFileName(file));
                    Console.WriteLine();

                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    Console.WriteLine("running cmd: " + string.Format("/C N: && {2} {0} {1} -nostep2 -noloadstring -fluff -uglify", XFuscatorLib, file, lua));
                    startInfo.Arguments = string.Format("/C {4} && cd {3} && {2} {0} {1} -nostep2 -noloadstring -fluff -uglify && mv {5} {6}", XFuscatorLib, file, lua, workingDir, Path.GetPathRoot(file).Replace("\\", ""),
                        string.Format("{0}\\{1}[kteam].lua", obFolder, Path.GetFileNameWithoutExtension(file)), string.Format("{0}\\{1}[kteam].lua", outputFolder, Path.GetFileNameWithoutExtension(file)));
                    process.StartInfo = startInfo;
                    process.Start();
                    //File.Move(string.Format("{0}\\{1}[kteam].lua", obFolder, Path.GetFileNameWithoutExtension(file)), string.Format("{0}\\{1}[kteam].lua", outputFolder, Path.GetFileNameWithoutExtension(file)));
                }
                Console.WriteLine();
                Console.WriteLine("********************* OB Completed ********************************");
                Console.ReadLine();
            }
            else if (input == "2")
            {
                Environment.Exit(0);
            }
        }

        private static string[] getFileFromFolder(string path)
        {
            string[] array2 = Directory.GetFiles(path, "*.lua");

            // Display all files.
            if (array2.Count() == 0)
            {
                Console.WriteLine("--- Do not have any lua file to ob ---");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("--- File list obfuscate: ---");
                foreach (string name in array2)
                {
                    Console.WriteLine(name);
                }
            }
            

            return array2;

        }

    }
}
