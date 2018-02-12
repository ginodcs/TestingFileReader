using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileReader;

namespace TestingFileREader
{
    class Program
    {
        static void Main(string[] args)
        {
            IFileManager reader =  new FileManager();  

            bool exit = false;
            string typeFile = string.Empty;
            bool isEncrypt = false;
            bool useRole = false;
            Roles role = Roles.Viewer;
            string roleText = string.Empty;
            string pathFile = string.Empty;

            while (!exit)
            {
                Console.WriteLine("Enter Type file (TXT, XML or JSON):");
                typeFile = Console.ReadLine();

                Console.WriteLine("Do you want to use encryption? (YES or NO):");
                isEncrypt = Console.ReadLine()=="YES" ? true : false;

                Console.WriteLine("Do you want to use role security? (YES or NO):");
                useRole = Console.ReadLine() == "YES" ? true : false;

                if(useRole)
                {
                    Console.WriteLine("What is your role ? (Admin, Writer, Reader, Owner, ...):");
                    roleText = Console.ReadLine();
                    Enum.TryParse(roleText, out role);            
                }

                Console.WriteLine("Enter the path of file:");
                pathFile = Console.ReadLine();

                while(!File.Exists(pathFile))
                {
                    Console.WriteLine("The file doesn't exist. Please, enter the path of file:");
                    pathFile = Console.ReadLine();
                }

                Console.WriteLine("****************************** START FILE **********************************************");

                Console.WriteLine(reader.ReadFile(pathFile, typeFile, encrypt: isEncrypt, role: role));

                Console.WriteLine("****************************** END FILE **********************************************");

                Console.WriteLine("Do you want to exit? (YES or NO):");
                exit = Console.ReadLine() == "YES" ? true : false;
            }
        }
    }
}
