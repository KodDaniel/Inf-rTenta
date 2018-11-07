using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsBankkonto
{
    class Program
    {
        static void Main(string[] args)
        {

            var konto = new Bankkonto();

            //OBS: PRENUMERATIONEN MÅSTE ALLTID SÄTTAS UPP FÖRE JAG SÄTTER VARIABLER FÖR ATT TESTKÖRA PROGRAMET (TYP konto.saldo = 300);
            // Notera att du måste upprätta prenumerationen innan du sätter ett nytt Saldo -  annars händer ingenting.
            konto.BalanceChange += KontoBalanceChange;

            // Testkör programet.
            konto.Saldo = 309;
         
        }
        // Event Reciver: notera metodsignaturen (object sender, BalanceArgs e)
        // Notera också att metoden är statisk. På så sätt kan enbart skriva metodnamnet där jag upprättar prenumerationen ( se rad 17)
        static void KontoBalanceChange(object sender, BalanceArgs e)
        {
            Console.WriteLine("Saldot ändrat! Nytt saldo: {0} kr", e.NewBalance);
            Console.ReadLine();
        }
    }
    public class BalanceArgs : EventArgs
    {
        // Vilken information behöver vi för att avgöra om saldot ändras? Jo, de två nedan.
        public int NewBalance { get; set; }
        public int OldBalance { get; set; }
    }

    public class Bankkonto
    {
        // EVENT och DELGATE in same
        public event EventHandler<BalanceArgs> BalanceChange;

        private int _saldo;
        public int Saldo
        {
            get { return _saldo; }
            set
            {
                // Skapar objekt att skicka med eventet
                var args = new BalanceArgs
                {
                    // lägger till det nya värdet på saldot I EVENT-OBJEKTET (ej i klassen, det gör jag några rader ned)
                    NewBalance = value,
                    // Lägger till det gamla saldot till EVENT-OBJEKTET.
                    OldBalance = _saldo
                };
                // Här ändrar vi i Bankontoklassen. Alla rader ovan har enbart satt värden i själva eventet-objektet
                _saldo = value;
                
                // Anropar vår Even Publisher med den informationen vi vill skicka med eventet
                OnBalanceChange(args);
            }
        }


        // Event Publisher: tar ALLTID den typen min Custom-event-klass har, i det här fallet BalancegArgs). Enda undantag om jag skickar tomt Event-objekt.
        protected void OnBalanceChange(BalanceArgs args)
        {
            if (BalanceChange != null)
            {
                // Om vi har det: skicka event-objektet
                //Signaturen är alltid (this,args) om jag inte skickar ett TOMT event-objekt. 
                BalanceChange(this, args);
            }
        }
    }

}
