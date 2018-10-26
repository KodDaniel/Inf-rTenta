using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsOchMultiCastsDelegatesInförTenta
{
    class Program
    {
        static void Main(string[] args)
        {
            var viSkickarInEttSaldo = 300;

            var konto = new Bankkonto();
            
            // Notera att du måste upprätta prenumerationen...
            // innan du sätter ett nytt Saldo...
            //Annars händer ingenting.
            konto.OnBalanceChange += Konto_OnBalanceChange;

            // Vi sätter nytt saldo
            konto.Saldo = viSkickarInEttSaldo;
        }
        // Event Reciver
        static void Konto_OnBalanceChange(object sender, BalanceArgs e)
        {
            Console.WriteLine("Saldot ändrat! Nytt saldo: {0} kr",e.Balance);
            Console.ReadLine();
        }
    }

    public class BalanceArgs : EventArgs
    {
        public int Balance;
        public int OldBalance;
    }

    public class Bankkonto
    {
        // EVENT och DELGATE in same
        public event EventHandler<BalanceArgs> OnBalanceChange;

        private int _saldo;
        public int Saldo
        {
            get { return _saldo; }
            set
            {   
                // Vi skapar ett en instans av BalanceArgs,
                // i vilken vi tilldelar den klassens variabler.
                // Sedan skickar vi den till vår Event Reciver...
                // med hjälp av vårt Event OnBalanceChange.
                var args = new BalanceArgs
                {
                    Balance = value,
                    OldBalance = _saldo
                };
                _saldo = value;

                if (OnBalanceChange != null)
                {
                    OnBalanceChange(this,args);
                }
            }
        }
    }
   
}







// a) 14p. Gör en implementation av ett Observer-pattern (Publish-subscribe). Din lösning ska
// innehålla en klass som fungerar som Publisher, objekt kan prenumerera på en viss händelse
// från objekt av denna Publisher-klass. Din lösning ska använda nyckelordet event samt
// innehålla ett testprogram som visar hur en prenumeration görs av händelsen.

// b) 4p. Hur påverkas din kod av att nyckelordet event används gentemot om du inte skulle
// använda nyckelordet i din kod?
//svar: