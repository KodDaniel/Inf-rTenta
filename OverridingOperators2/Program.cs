using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OverridingOperators2
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new A();
            var b = new  A();
            Console.WriteLine(a == b);
            Console.WriteLine(a.Equals(b));
            Console.WriteLine(ReferenceEquals(a,b));
            Console.ReadLine();
        }
    }

    public class A
    {
        public string Färg { get; }

        public string Storlek { get; }

        public string Vikt { get; }

        // Troligen nödvändigt med tom konstruktor för att kunna skapa en instans av klassen A i klassen Program
        public A()
        {          
        }

        public A(string färg, string storlek, string vikt)
        {
            this.Färg = "Röd";
            this.Storlek = "Medium";
            this.Vikt = "40 kg";
        }

        public override bool Equals(object obj)
        {
            // Om det inskickade objektet är null är objektet inte lika och vi returnerar false.
            if (obj is null)
            {
                return false;
            }
            // Om det inskickade objektet inte är av typen A eller en typ av en klass som ärver av A...
            // ...kan vi inte göra en jämförelse. Därför returnerar vi false.
            if (!(obj is A))
            {
                return false;
            }
            return
                // Lägg märke till Casting för att få tilgång till properties Färg, Storlek och Vikt
                this.Färg == ((A)obj).Färg &&
                this.Storlek == ((A)obj).Storlek &&
                this.Vikt == ((A)obj).Vikt;
        }

        public static bool operator ==(A a, A b)
        {
            // Om båda är null eller refererar samma instans returnera TRUE
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            // Om en är null men inte båda returnera FALSE
            if ((object)a == null || (object)b == null)
            {
                return false;
            }

            //Anropar vår overridade Equals-metod.
            // Svaret kommer bli TRUE om objekten är lika annars FALSE
            return a.Equals(b);
        }
        // När vi ändrar == måste vi även ändra !=
        public static bool operator !=(A a, A b)
        {
            return !(a == b);
        }

     

    }
}
