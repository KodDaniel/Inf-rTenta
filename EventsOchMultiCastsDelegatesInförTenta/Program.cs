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
            var konto = new Bankkonto();
            //konto.OnBalanceChange += new BalanceChangeOnHandler(Konto_OnBalanceChange);
            konto.OnBalanceChange += Konto_OnBalanceChange;
        }
        static void Konto_OnBalanceChange(object sender, BalanceArgs e)
        {
            Console.WriteLine("Saldot ändrat! Nytt saldo: {0} kr",e.Balance);
        }
    }

  
    //public delegate void BalanceChangeOnHandler(object obj, BalanceArgs balanceArgs);


    public class Bankkonto
    {
        //public event BalanceChangeOnHandler OnBalanceChange;

        public event EventHandler<BalanceArgs> OnBalanceChange;


        private int _saldo;
        public int Saldo
        {
            get { return _saldo; }
            set
            {       
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
    public class BalanceArgs : EventArgs
    {
        public int Balance;
        public int OldBalance;
    }
}











// a) 14p. Gör en implementation av ett Observer-pattern (Publish-subscribe). Din lösning ska
// innehålla en klass som fungerar som Publisher, objekt kan prenumerera på en viss händelse
// från objekt av denna Publisher-klass. Din lösning ska använda nyckelordet event samt
// innehålla ett testprogram som visar hur en prenumeration görs av händelsen.

// b) 4p. Hur påverkas din kod av att nyckelordet event används gentemot om du inte skulle
// använda nyckelordet i din kod?
//svar: