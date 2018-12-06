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
        // Deklarerar en delegattyp
        public delegate void PrintHandler(string text);


        static void Main(string[] args)
        {

            // Tilldening av första variabel: Skriver ut "Modo är inte bra"
            PrintHandler printHandler = text => Console.WriteLine(text);
            // Vi gör delegaten till multicast genom att tilldela ytterligare metod. Ger utskriften:
            // "Du skrev alltså: Modo är inte bra"
            printHandler += text => Console.WriteLine("Du skrev: alltså " + text);          
            // Anropar vår multicast delegate
            printHandler("Modo är inte bra");
            Console.ReadLine();


        }

      
    }










}


