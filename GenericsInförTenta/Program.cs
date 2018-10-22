using System;
using System.Collections.Generic;
using System.Linq;
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
}
