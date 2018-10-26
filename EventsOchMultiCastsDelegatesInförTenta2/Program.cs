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
            // Jag är klienten. Som klient skapar jag ett nytt resultat nedan.
            var nyttResultat = new Resultat { Spelarnamn = "Daniel", Poäng = 33 };

            // Skapar instans av min publisher-klass
            var rankingObj = new Ranking(); 
           
            // Skapar instans av min subscriber-klass
            var rankingSubObj = new RankingSubscriber(); 
            
            // Instance of publisher.event of publisher += instance of subscriber.event handler of subscriber.
            // Upprättar en prenumeration.
            rankingObj.NyttHögstaResultat += rankingSubObj.OnNyttHögstaResultat;
           
            // Anropar min publisher-klass med ett nytt resultat
            rankingObj.NyttResultat(nyttResultat);
        }    

    }  
    // (Klassen Resultat är FÖRDEFINIERAD I TENTAN)
    public class Resultat
    {
        public string Spelarnamn { get; set; }
        public int Poäng { get; set; }
    }

    // Subscriber-Klass
    public class RankingSubscriber
    {
        // Event Reciver
        public void OnNyttHögstaResultat(object soruce, RankingArgs args)
        {
            Console.WriteLine("Det NYA högsta resultatet tillhör {0} med poängen {1}.", args.Spelarnamn,args.Poäng);
            Console.ReadLine(); 
        }

    }

    public class RankingArgs : EventArgs
    {
        public string Spelarnamn { get; set; }
        public int Poäng { get; set; }
    }

    public class Ranking
    {
        // Lista som håller alla resultat
        private List<Resultat> _resultatLista = new List<Resultat>();

        public Ranking()
        {
            // Vi fyller listan med exempelResultat
            _resultatLista.Add(new Resultat { Spelarnamn = "James", Poäng = 32 });
            _resultatLista.Add(new Resultat { Spelarnamn = "Oskar", Poäng = 25 });
            
        }    
        // Instansvariabel som håller det högsta resultatet just nu 
        private Resultat _högstaResultat;

        // EVENT OCH DELEGATE IN SAME
        public event EventHandler<RankingArgs> NyttHögstaResultat;
  
        // Metod som avgör om vi har ett nytt högsta
        public void NyttResultat(Resultat nyttResultat)
        {
            // Sorterar listan med det högsta resultatet först, och detta resultatet...
            // lägger vi sedan i variabeln nuvarandeHögstaResultat
           var nuvarandeHögstaResultat = _resultatLista.OrderByDescending(a => a.Poäng).Select(a => a.Poäng).First();

            // Adderar det nya resultatet till listan.
            _resultatLista.Add(nyttResultat);

            // Undersöker om resultatet är det nya högsta
            if (nyttResultat.Poäng > nuvarandeHögstaResultat)
            {
                // Om så är fallet: tildela det nya resultatet instansvariabeln _högstaResultat
                _högstaResultat = nyttResultat;

                // Kalla på vår Event Publisher där vi skickar med information om nya rekordet 
                // Denna information finns läggs i ett nytt objekt av klassen RankingArgs
                OnNyttBästaResultat(new RankingArgs {Spelarnamn = _högstaResultat.Spelarnamn, Poäng = _högstaResultat.Poäng});
            }
        }

        // Event publisher
        public void OnNyttBästaResultat(RankingArgs args)
        {
            // Om vi har subscribers: Fortsätt in i if-satsen
            if (NyttHögstaResultat != null)
            {
                NyttHögstaResultat(this, args);
            }
        }

    }



}
