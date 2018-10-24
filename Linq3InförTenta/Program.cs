using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq3InförTenta
{
    class Program
    {
        static void Main(string[] args)
        {
            //Besvara frågorna nedan med användande av Standard Query Operators och  lambdauttryck:

            //Lös nedanstående problem med hjälp av LINQ’s Standard Query Operators.

            //a) 2p.Hämta den första produkten som kostar mer än 700 kr.

            //b) 3p.Skapa en lista med namnen på alla kunder som är yngre än 30 år.

            //c) 3p.Beräkna medelåldern för alla kunder.

            //d) 3p.Hämta alla Kund-objekt som har lagt en order för produkten med id 345, sortera
            //listan på kundernas namn i bokstavsordning.

            //e) 4p.Skapa en lista av anonyma-objekt med egenskaperna Kund som är ett
            //Kund-objekt och egenskapen Summa som är den totala summan av som kunden lagt order för.

            //a)
            var db= new DB();
            var answerOnA = db.Produkter.First(a => a.Pris > 700);

            //b) 
            var answerOnB = db.Kunder.Where(a => a.Ålder < 30).Select(k => k.Namn).ToList();
           
            //c) 
            var answerOnC = db.Kunder.Average(a => a.Ålder);

            // d)
            var answerOnD = db.Orders.Where(a => a.Produkt.ProduktId == 345).Select(o => o.Kund).OrderBy(a => a.Namn);

            //e) DENNA FÖRSTÅR DU EJ
            var answerOnE = db.Orders.Select(o =>
                new
                {
                    namn = o.Kund.Namn,
                    summa = db.Orders.Where(or=>or.Kund == o.Kund).
                        Sum(or=>or.Produkt.Pris)

                });

                 


        } 
    }
    // Följande klasser är givna:


    public class Produkt
    {
        public int ProduktId { get; set; }
        public string Namn { get; set; }
        public int Pris { get; set; }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public Produkt Produkt { get; set; }
        public Kund Kund { get; set; }
    }

    public class Kund
    {
        public int KundId { get; set; }
        public string Namn { get; set; }
        public int Ålder { get; set; }
    }

    public class DB
    {
        public IEnumerable<Produkt> Produkter { get; private set; }
        public IEnumerable<Order> Orders { get; private set; }
        public IEnumerable<Kund> Kunder { get; private set; }

    }
}
