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
           

            var db = new DB();
            var svar = db.Orders.Select(o =>
                new
                {   // o är enbart en instans av klassen order.
                    // or är YTTERLIGARE EN (en annan) instans av klassen order.                   
                    Kund = o.Kund.Namn,
                    Summa = db.Orders.Where(or => or.Kund == o.Kund).Sum(or => or.Produkt.Pris)
                } );


        }
    }
    // Följande klasser är givna:

    public class DB
    {
        public IEnumerable<Produkt> Produkter { get; private set; }
        public IEnumerable<Order> Orders { get; private set; }
        public IEnumerable<Kund> Kunder { get; private set; }
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
    public class Produkt
    {
        public int ProduktId { get; set; }
        public string Namn { get; set; }
        public int Pris { get; set; }
    }
 


   
}
