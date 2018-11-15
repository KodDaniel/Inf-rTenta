using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsRanking
{
    class Program
    {
        public static void RankingReciver(object sender, RankingArgs e)
        {
            Console.WriteLine(e.Spelarnamn + " " + e.Poäng);
        }

        static void Main(string[] args)
        {
          var rankingObject = new Ranking();
          rankingObject.NyttBästaResultat += RankingReciver;
          
        }    

    }  
    // (Klassen Resultat är FÖRDEFINIERAD I TENTAN)
    public class Resultat
    {
        public string Spelarnamn { get; set; }
        public int Poäng { get; set; }
    }


    
    public class RankingArgs : EventArgs
    {
        public string Spelarnamn { get; set; }
        public int Poäng { get; set; }
    }

    public class Ranking
    {
        public event EventHandler<RankingArgs> NyttBästaResultat;

        private List<Resultat> _resultatLista = new List<Resultat>();
        private Resultat _högstaResultat = new Resultat();

        public void NyttBästaResultatEllerInte(Resultat nyttResultat)
        {
            if (nyttResultat.Poäng > _högstaResultat.Poäng)
            {
                _högstaResultat = nyttResultat;

                OnNyttBästaResultat(new RankingArgs
                    {Spelarnamn = _högstaResultat.Spelarnamn,
                     Poäng = _högstaResultat.Poäng});
            }
        }





        protected void OnNyttBästaResultat(RankingArgs args)
        {
            if (NyttBästaResultat != null)
            {
                NyttBästaResultat(this, args);
            }
        }



    }


}





