using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _29._01home
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the path to view its contents:");
            string path = Console.ReadLine();

            
            if (Directory.Exists(path))
            {
                
                Console.WriteLine($"\nContents of {path}:");
                string[] directories = Directory.GetDirectories(path);
                string[] files = Directory.GetFiles(path);

                Console.WriteLine("Directories:");
                foreach (string directory in directories)
                {
                    Console.WriteLine(Path.GetFileName(directory));
                }

                Console.WriteLine("\nFiles:");
                foreach (string file in files)
                {
                    Console.WriteLine(Path.GetFileName(file));
                }
            }
            else
            {
                Console.WriteLine("The specified path does not exist.");
            }
        }
    }
}
