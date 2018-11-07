using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temp3
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Djur<T>
    {

        // Denna lista kommer bara kunna hanteras inom den här klassen.
        // Om jag är bekväm med det så kan jag instansiera direkt som jag gör här
        private List<T> ListInstantiatedHere = new List<T>();

        // Denna lista instansieras genom en konstruktor.
        // Genom att göra den gör jag den tillgänglig för andra klasser...
        //...vilket ofta är önskvärt
        public List<T> ListWhichBelongsToConstructor { get; set; }

        public Djur()
        {
            ListWhichBelongsToConstructor = new List<T>();
        }

        public IEnumerable<T> HämtaLista()
        {
            return ListWhichBelongsToConstructor.AsReadOnly();
        }
    }
}
