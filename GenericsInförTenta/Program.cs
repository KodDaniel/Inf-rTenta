using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GenericsInförTenta
{
    class Program
    {
        static void Main(string[] args)
        {
            // Skriv en generisk klass med namnet Påse, klassen ska ha följande funktionalitet:
            
            // a) LäggTill – Tar som argument ett objekt av den typ som hanteras i Påsen och lägger till
            // objektet till påsens andra objekt. Add returnerar inget.
            
            // b) TaBort – Tar som argument ett objekt av den typ som hanteras i påsen och tar bort detta
            // objekt från påsen. Remove returnerar inget men ifall objektet inte finns bland påsens objekt
            // så ska ett IngetSådantObjektFinnsException kastas.
            
            // c) Innehåller – Tar som argument ett objekt av den typ som hanteras i påsen och returnerar
            // true om objektet finns i påsen, annars false.
           
            // d) HämtaAlla – Tar inget argument och returnerar en IEnumerable av objekt som hanteras i påsen.
        }
    }

    public class Påse<T>
    {
        private List<T> _saker = new List<T>();

        public void LäggTillSak(T sak)
        {
            _saker.Add(sak);
        }

        public void TaBort(T sak)
        {
            if (!Innehåller(sak))
            {
                throw new IngetSådantObjektFinnsException();
            }
            _saker.Remove(sak);
        }

        public bool Innehåller(T sak)
        {
            return _saker.Contains(sak);
        }

        public IEnumerable<T> AllaSaker()
        {
            return _saker.AsReadOnly();
        }
    }

    public class IngetSådantObjektFinnsException : Exception
    {
        public IngetSådantObjektFinnsException() :base()
        {
            
        }

        public IngetSådantObjektFinnsException(string message) : base (message)
        {
            
        }

        public IngetSådantObjektFinnsException(string message, Exception innerException)
        :base(message,innerException)
        {
            
        }
    }
}
