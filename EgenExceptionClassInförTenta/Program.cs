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
            // Nu är det dags att skriva kod. Vanligtvis kommer det en uppgift om att göra en egen
            // exceptionklass.

            // Skriv en klass ÖvertrasseringsException som uppfyller riktlinjerna för vilka
            // konstruktorer som bör vara med i egendefinierade exceptions. Skriv sedan någon
            // metod i klassen Bankkonto som kastar ett övertrasseringsexception.
            // Exemplifiera även med kod där ett övertrasseringsexception fångas.

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
