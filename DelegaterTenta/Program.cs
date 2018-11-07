using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DelegaterTenta
{
    class Program
    {
        public delegate void PrintHandler(string text);

        static void Main(string[] args)
        {
            PrintHandler printHandler = text => Console.WriteLine(text);
            printHandler += text => Console.WriteLine("Du skrev: " + text);

            printHandler("Modo är inte bra");
            Console.ReadLine();
        }
      








    }
}


