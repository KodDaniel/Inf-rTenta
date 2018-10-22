using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceEqualityReferensLikhetInförTenta
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        //// Operatorn ”==” testar per default referenslikhet (reference equality) genom att
        //// fastställa huruvida två referenser pekar på samma objekt. Om man ändrar
        //// Equals-metoden som ärvs från System.Object bör man också överlagra ==-operatorn
        //// så att den överensstämmer med Equals. Ett exempel på när det lämpligt att
        //// omdefiniera Equals och att överlagra ==-operatorn är när en typ är oföränderlig
        //// (immutable), dvs när en instans data inte kan förändras. Likhet bör då baseras på
        //// värde istället för referens. Två oföränderliga objekt kan nämligen betraktas som
        //// samma objekt så länge de har samma värde.
        //// Antag att A är en oföränderlig typ med de tre medlemmarna Färg, Storlek och Vikt.
        //// Två objekt av typen A skall betraktas som de samma om dessa medlemmar har
        //// samma värde. Antag att Equalsmetoden redan är ändrad i enlighet med detta.
        //// Överlagra nu även ==- operatorn. Fyll i det som saknas i koden nedan:

        //public static bool operator ==(A a, A b)
        //{
        //    // Om båda är null eller båda refererar samma instans
        //    if (System.Object.ReferenceEquals(a, b))
        //    {
        //        //??
        //    }

        //    // Om en är en null men inte båda
        //    if ((object) a == null || (object) b == null)
        //    {
        //        //??
        //    }

        //    // Om medlemmarna är lika
        //    //??
        //}

        //// När vi ändrar operator == måste vi även ändra != 
        //public static bool operator !=(A a, A b)
        //{
        //    ??
        //}
    }
}
