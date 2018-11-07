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

            List<Person> lista = new List<Person>
            {
                new Person()
                {
                    Namn = "Daniel Åhlin",
                },
                new Person()
                {
                    Namn = "Oskar Hedman"
                }
            };

        }
    }

    public class Person
    {
        public string Namn { get; set; }
    }
    // Elementen betyder ord, inte bokstäver.
    public static class StaticNonGenericClass
    {
        public static string Reverse <T>(this List<T> items)
        {
            string outPut = "";
            int i;

            foreach (var item in items)
            {
                outPut = item.ToString() + "," + outPut;
            }

            if ((i = outPut.LastIndexOf("."))> 0)
            {
                outPut = outPut.Substring(0, i);
                
            }
            return outPut;
        }
    }
}
