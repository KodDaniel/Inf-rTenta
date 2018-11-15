using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodInförTenta
{
    class Program
    {
        static void Main(string[] args)
        {
            // Förklara vad en ”extension method” är för något. Skriv kod för att lägga en sådan
            // metod till den fördefinierade klassen List. Metoden skall returnera elementen i
            // omvänd ordning i form av en sträng.

         

        }
    }

  
    // Elementen betyder ord, inte bokstäver.
    public static class StaticNonGenericClass
    {
        public static List<int> ListOfNumbers = new List<int> {1,2,3,4,5};
        public static List<string> ListOfStrings = new List<string> {"Hej", "Vad", "Händer?"};

        public static List<T> ReverseList <T>(this List<T> listToReverse)
        {
            listToReverse.Reverse();
            return listToReverse;
        }
    }
}
