using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverridingOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            // Två OLIKA bil-objekt med med SAMMA värden
            var bil1 = new Bil { Ägare = "Daniel", Märke = "Audi", ÅrsModell = 1999 };
            var bil2 = bil1;

            // Båda kommer returnera FALSE.
            // Detta är inte bra. Om två bilar har samma värden...
            // vill vi ha värdet TRUE
            Console.WriteLine(bil1 == bil2);
            Console.WriteLine(bil1.Equals(bil2));
            Console.WriteLine(ReferenceEquals(bil1, bil2));

            Console.ReadLine();
        }
    }
    public class Bil
    {
        public string Ägare { get; set; }
        public string Märke { get; set; }
        public int ÅrsModell { get; set; }

        public override bool Equals(object obj)
        {
            // Om det inskickade objektet är null är objektet inte lika och vi returnerar false.
            if (obj is null)
            {
                return false;
            }
            // Om det inskickade objektet inte är av typen Bil eller en typ av en klass som ärver av Bil...
            // ...kan vi inte göra en jämförelse. Därför returnerar vi false.
            if (!(obj is Bil))
            {
                return false;
            }
            return
                // Lägg märke till Casting för att få tilgång till properties Ägare, Märke och ÅrsModell
                this.Ägare == ((Bil)obj).Ägare &&
                this.Märke == ((Bil)obj).Märke &&
                this.ÅrsModell == ((Bil)obj).ÅrsModell;
        }

        public static bool operator ==(Bil a, Bil b)
        {
            // Om båda är null eller refererar samma instans returnera TRUE
            if (ReferenceEquals(a, b))
            {
                return true;
            }
           
            // Om en är null men inte båda returnera FALSE
            if((object)a ==null || (object)b==null)
            {
                return false;
            }
            
            //Anropar vår overridade Equals-metod.
            // Svaret kommer bli TRUE om objekten är lika annars FALSE
            return a.Equals(b);
        }
        // När vi ändrar == måste vi även ändra !=
        public static bool operator !=(Bil a, Bil b)
        {
            return !(a == b);
        }

    }
}


