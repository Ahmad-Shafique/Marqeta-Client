using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarqetaClient
{
    class Program
    {


        static void Main(string[] args)
        {

            WriteToFile.GetInstance().WriteToNewFile(@"Test.txt","Hello World");




            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
