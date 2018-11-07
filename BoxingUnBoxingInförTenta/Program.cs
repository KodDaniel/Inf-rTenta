using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxingUnBoxingInförTenta
{
    class Program
    {
        static void Main(string[] args)
        {

            // Svar: Boxing uppkommer när en värdetyp ska omvandlas till en referenstyp (typen object). 
            //När en värdetypen ska omvandlas...
            //...skapas ett nytt objekt som sparar en referens på stacken och värdetypens...
            //...värde på heapen. Detta gör att det blir extra lagring och värdet på heapen...
            //...blir föremål för Garbage Collection. Unboxing är då vi skapar en...
            //..ny värdetyp från ett objekt. Slutsats: Så långt det går ska man undvika...
            //...unboxing och boxing genom att exempelvis använda generiska listor.

            ArrayList myArrayList = new ArrayList(); // ArrayList tar BARA in objekt.
            myArrayList.Add(3); // Boxing sker: 3:an konverteras till ett objekt.
            myArrayList.Add(4); // Boxing igen.
            int value = (int) myArrayList[0]; // Unboxing sker.

            List<int> myList = new List<int>(); // Ingen boxing eftersom den
                                                // generiska listan behåller...
                                                //... värdetypen som den är.
            myList.Add(3);
            myList.Add(4);
            int valueTwo = myList[0]; // Ingen unboxing krävs.
        }
        
    }
}
