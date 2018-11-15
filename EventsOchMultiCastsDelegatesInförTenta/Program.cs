using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsBankkonto
{
    class Program
    {

        static void ReciverSaldoChange(object sender, SaldoArgs e)
        {
            Console.WriteLine(e.NewSaldo);

        }

        static void Main(string[] args)
        {
            var konto = new BankKonto();
            konto.SaldoChange += ReciverSaldoChange;

            //Om vi vill testköra
            konto.Saldo = 300;
            Console.ReadLine();
        }
    }

    public class SaldoArgs : EventArgs
    {
        public double OldSaldo { get; set; }
        public double NewSaldo { get; set; }
    }

    public class BankKonto
    {
        public event EventHandler<SaldoArgs> SaldoChange;
        private double _saldo;

        public double Saldo
        {
            get { return _saldo; }
            set
            {
                var saldoArgs = new SaldoArgs
                {
                    OldSaldo = _saldo,
                    NewSaldo = value
                };

                _saldo = value;
                OnSaldoChange(saldoArgs);


            }
        }

        protected void OnSaldoChange(SaldoArgs args)
        {
            if (SaldoChange != null)
            {
                SaldoChange(this, args);
            }
        }

    }

}
