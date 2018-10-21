using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegaterTenta
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Ge en förklaring till vad en delegat är för något.
            
            // Svar: En delegat är en datatyp som kapslar in metoder av en viss signatur i objekt (delegat-objekt),
            // signaturen för metoderna definieras vid deklarationen av delegattypen. Metoderna som inkapslats...
            // ...kan sedan anropas genom delegatobjektet.

            //2. Deklarera en delegat-typ, deklarera en variabel av delegat-typen samt tilldela denna
            // variabel ett delegatobjekt. Skriv ett testprogram som använder delegatobjektet på ett
            // korrekt sätt.



            #region Svar på fråga 2

            #endregion


            // 3. Du har följande delegat-deklaration:
            Action<int, string> myAction;
            //Tilldela variabeln myAction ett lambdauttryck som uppfyller signaturen.

            #region Svar på fråga 3

            #endregion

            // 4. 3p. Du har följande delegat -deklaration:
                Func<int, int, bool> myFunc;
            // Tilldela variabeln myFunc ett lambdauttryck som uppfyller signaturen.
        }
    }
}

