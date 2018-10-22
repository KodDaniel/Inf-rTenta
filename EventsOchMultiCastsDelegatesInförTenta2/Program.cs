using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsOchMultiCastsDelegatesInförTenta2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Tilldela variablerna func samt action lambdauttryck med korrekt signatur.


            Func<int, int, bool> myFunc;
            Action<int, int, bool> myAction;
        }

        // Skriv en klass Ranking som kommer att fungera som ett rankingsystem. Låt
        // Rankingklassen hantera objekt av typen Resultat som är given nedan. När ett nytt
        // resultat läggs till rankingen så utlöses eventet NyttBästaResultat om det nya
        // resultatet är det bästa resultatet. Låt de som prenumererar på eventet få information
        // om vilken spelare som gjort resultatet samt dennes resultat. Skriv ett kort
        // testprogram som prenumererar på eventet. 

       // (Klassen Resultat är fördefinierad i tentan)
        public class Resultat
        {
            public string Spelarnamn { get; set; }
            public int Poäng { get; set; }
        }


    }
}
