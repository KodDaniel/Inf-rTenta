using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgenExceptionClassInförTenta
{
    class Program
    {
        static void Main(string[] args)
        {
          
            var konto = new Bankkonto();
            try
            {
                konto.Saldo = 100;
                double summa = -500;
                konto.TaUtPengar(summa);
                Console.WriteLine("Uttag: " + summa);
            }
            catch (ÖvertrasseringsException)
            {
                Console.WriteLine("Negativ summa");
            }

            Console.ReadLine();
        }
    }
    public class Bankkonto
    {
        public double Saldo { get; set; }

        public void TaUtPengar(double summa)
        {

            if (this.Saldo + (summa) < 0)
            {
                throw new ÖvertrasseringsException("Negativ summa");
            }         
                // summan dras av saldot
                this.Saldo -= summa;
             // Kod för att returnera summan...
        }
         

    }
    public class ÖvertrasseringsException : Exception
    {
        public ÖvertrasseringsException()
        {
            
        }

        public ÖvertrasseringsException(string message)
        {
            
        }

        public ÖvertrasseringsException(string message, Exception innerException)
        {
            
        }

    }

}
