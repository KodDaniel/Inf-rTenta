using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdaÄrEnPrick 
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instans av publisher
            var rankingObject = new Ranking();

            //Upprättar prenumeration. Eftersom min Event Reciver är statisk räcker det med enbart metodnamnet "NyttBästa" efter += operatorn.
            //OBS: PRENUMERATIONEN MÅSTE ALLTID SÄTTAS UPP FÖRE JAG SÄTTER VARIABLER FÖR ATT TESTKÖRA PROGRAMET;
            rankingObject.NyttBästaResultat += NyttBästa;           
        }

        // Event Reciver: Notera att den är statisk och har signaturen (object sender, RankingArgs args)
        public static void NyttBästa(object sender, RankingArgs args)
        {
            Console.WriteLine("Nytt bästa är {0} och slogs av {1}", args.Poäng, args.Spelarnamn);
            Console.ReadLine();
        }
    }

    // Fördefinierad klasss
    class Resultat
    {
        public string Spelarnamn { get; set; }
        public int Poäng { get; set; }
    }

    // Uppgiften kräver att mitt event ska skicka information om vilken poäng det nya bästa resultat har,
    // och vilken spelare som har gjort det. Vilka egenskaper behövs för det? Jo, de två nedan.
    class RankingArgs : EventArgs
    {
        public string Spelarnamn { get; set; }
        public int Poäng { get; set; }
    }

    class Ranking
    {
        // Jag behöver en lista för att kunna jämföra resultat
        private List<Resultat> _resultatLista = new List<Resultat>();

        // Jag behöver en variabel som håller det nuvarande högsta resultatet.
        // Notera att instansvariabeln ej är en int utan av typen Resultat. Variabeln innehåller alltså både en siffra (poängen) och ett spelarnamn.
        private Resultat _nuvarandeHögsta;

        public event EventHandler<RankingArgs> NyttBästaResultat;

        // Event Publisher: tar ALLTID den typen min Custom-event-klass har, i det här fallet RankningArgs). Enda undantag om jag skickar tomt Event-objekt.
 
        protected void OnNyttBästaResultat(RankingArgs args)
        {
            if (NyttBästaResultat != null)
            {
                // Skickar Event-objektet via mitt Event NyttBästaResultat.
                //Signaturen är alltid (this,args) om jag inte skickar ett TOMT event-objekt. 
                NyttBästaResultat(this, args);
            }
        }

        // Logik för att avgöra om vi har ett nytt bästa resultat.
        // Notera att inparametern är av typen resultat. Det är rimligt då det är ett nytt resultat som skickas in
        public void NyttBästaEllerInte(Resultat nyttResultat)
        {
            // Addar resultat för framtida bruk. Detta behövs egentligen inte för min uppgift, men nödvändigt om vi kör programmet flera gångar
            _resultatLista.Add(nyttResultat);

            // Notera att variablerna nedan är av typen Resultat och att vi behöver specificera att det är poängen vi jämför.
            // Annars tycker kompilatorn att vi försöker jämföra en variabel som innehåller typ ("Daniel", 3) mot ("Niklas",2).
            if (nyttResultat.Poäng > _nuvarandeHögsta.Poäng)
            {
                // Om vi går in här (in if-satsen dvs) betyder det att vi har nytt bästa resultat.
                // Då sätter vi vår instansvariabel - av typen resultat - lika med den nya resultatet som vi fick inskickat i metoden
                _nuvarandeHögsta = nyttResultat;

                // Detta är en anrop till vår Event Publisher. Vi skickar med instansvariabeln _nuvarandeHögsta.
                // Notera att eftersom vi skickar typen RankingArgs så måste vi tilldela de egenskaperna klassen RankingArgs har: Spelarnamn och Poäng. 
                OnNyttBästaResultat(new RankingArgs {Spelarnamn = _nuvarandeHögsta.Spelarnamn, Poäng = _nuvarandeHögsta.Poäng});
            }
        }
    }


}
