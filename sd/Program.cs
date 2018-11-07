using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sd
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new DB();

            var svar = db.Orders.Select(o =>
                new
                {
                    Kund = o.Kund.Namn,
                    Summa = db.Orders.Where(or => or.Kund == o.Kund).Sum(or => or.Produkt.Pris)
                });
        }
    }

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
        public IEnumerable<Produkt> Produkter { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<Kund> Kunder { get; set; }
    }
}
