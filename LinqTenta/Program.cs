using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqInförTenta
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

            //#region Svar a

            //var svar = lista.Where(tal => tal % 2 == 0 && tal > 255 && tal < 625);
            //svar.ToList().ForEach(x => Console.WriteLine(x));
            //Console.ReadLine();

            //#endregion

            //#region Svar b
            ////b) Skapa en samling av anonyma-objekt med egenskaperna X och Y där X-egenskapen ska
            //// vara värdet på varje tal i listan och Y-egenskapen ska ha värdet av X-egenskapen upphöjt till 2.
            //// Skriv ut denna samling på konsolen. Använd: Console.WriteLine(string text).

            //var svar2 = lista.Select(tal => new {x = tal, y = tal * tal});
            //svar2.ToList().ForEach(x=> Console.WriteLine(x));
            //Console.ReadLine();

            //#endregion

            List<Person> personer = new List<Person>
            {
                new Person {Namn = "Niklas", Personnummer = 1943},
                new Person {Namn = "James", Personnummer = 1931},
                new Person {Namn = "Daniel", Personnummer = 1993},
                new Person {Namn = "Fredrik", Personnummer = 1973},

            };

            List<Bil> bilar = new List<Bil>
            {
                new Bil {Märke = "Volvo", Årsmodell = 1993, ÄgarePersonnummer = 1993},
                new Bil {Märke = "SAAB", Årsmodell = 2010, ÄgarePersonnummer = 1973},
                new Bil {Märke = "Audi", Årsmodell = 1985, ÄgarePersonnummer = 1943},
                new Bil {Märke = "BMW", Årsmodell = 1990, ÄgarePersonnummer = 1984},
                new Bil {Märke = "Audi", Årsmodell = 1985, ÄgarePersonnummer = 1932}

            };

            // Klasserna Bil och Person ska användas för fråga c och d och är givna nedan:
            // Även två listor med personer och bilar finns (OBS SE PROGRAM-klass OVAN) (listorna innehåller ett antal person- och bil-objekt):

            //  c) Sortera alla bilar i listan bilar efter Märke i bokstavsordning och sedan en inbördes..
            // ...sortering på fallande årsmodell (d.v.s. nyaste bilen först). Tilldela den sorterade listan till en
            // ...variabel med namnet svar.


            #region Svar c

            var svar3 = bilar.OrderBy(a => a.Märke).ThenByDescending(a => a.Årsmodell);
            svar3.ToList().ForEach(x=>Console.WriteLine("{0} " + " {1}" + " {2}",x.Märke, x.ÄgarePersonnummer, x.Årsmodell));
            Console.ReadLine();
            #endregion

            // d) Skapa en lista av anonyma-objekt med egenskaperna Ägare och Bil där Ägare-egenskapen...
            // ska vara ett Person-objekt och Bil-egenskapen ska vara det bil-objekt som personen äger.
            // Tilldela samlingen av anonyma-objekt till en variabel med namnet svar.

            #region Svar d

            var svar = personer.Join(
                bilar,
                person => person.Personnummer,
                bil => bil.ÄgarePersonnummer,
                (p, b) => new {ägare = p, bil = b });

            svar.ToList().ForEach(x => Console.WriteLine("{0} " + "{1}", x.bil.Märke, x.ägare.Namn));
            Console.ReadLine(); 


            #endregion
        }
    }
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

 
}
