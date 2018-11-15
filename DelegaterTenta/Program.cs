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
        public delegate int Addition(int tal1, int tal2);
   

        static void Main(string[] args)
        {

           var enumerableWithNumbers = Enumerable.Range(0, 10);
        
            // Skriver ut på konsolen med Lambda Expression.
            enumerableWithNumbers.ToList().ForEach(x=>Console.WriteLine(x));
            Console.ReadLine();
        }
    }










}


