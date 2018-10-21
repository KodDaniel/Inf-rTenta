using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTenta
{
    class Program
    {
        static void Main(string[] args)
        {
            // Följande kod är utgångspunkt för frågorna a och b:

            // En samling av tal mellan 0 och 1000
            var lista = Enumerable.Range(0, 1000);

            // a) Sortera ut alla jämna tal som är större än 255 och mindre än 625 och skriv ut alla dessa
            // tal på konsolen. Använd: Console.WriteLine(string text).

            #region Svar a

            #endregion

            //b) Skapa en samling av anonyma-objekt med egenskaperna X och Y där X-egenskapen ska
            // vara värdet på varje tal i listan och Y-egenskapen ska ha värdet av X-egenskapen upphöjt till 2.
            // Skriv ut denna samling på konsolen. Använd: Console.WriteLine(string text).

            #region Svar b

            #endregion

            List<Person> personer;
            List<Bil> bilar;
        }
    }

    // Klasserna Bil och Person ska användas för fråga c och d och är givna nedan:
    // Även två listor med personer och bilar finns (OBS SE PROGRAM-klass OVAN) (listorna innehåller ett antal person- och bil-objekt):

    //  c) Sortera alla bilar i listan bilar efter Märke i bokstavsordning och sedan en inbördes..
    // ...sortering på fallande årsmodell (d.v.s. nyaste bilen först). Tilldela den sorterade listan till en
    // ...variabel med namnet svar.


    #region Svar c

    #endregion

    public class Bil
    {
        public string Märke { get; set; }
        public int Årsmodell { get; set; }
        public long ÄgarePersonnummer { get; set; }
    }
    public class Person
    {
        public string Namn { get; set; }
        public long Personnummer { get; set; }
    }

    // d) Skapa en lista av anonyma-objekt med egenskaperna Ägare och Bil där Ägare-egenskapen...
    // ska vara ett Person-objekt och Bil-egenskapen ska vara det bil-objekt som personen äger.
    // Tilldela samlingen av anonyma-objekt till en variabel med namnet svar.

    #region Svar d

    #endregion
}
