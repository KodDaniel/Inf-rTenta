using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsOchMultiCastsDelegatesInförTenta3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Du skall nu skriva en event-driven chatt-applikation. För att lösa frågan skall du
            // implementera klasserna ChattServer och ChattKlient enligt nedanstående
            // specifikationer. Relationerna mellan klasserna är sådana att flera klienter är kopplade
            // till en server. ChattServer-klassen skall ha en metod som anropas från en klient när
            // ett nytt meddelande skall skickas ut, metoden skall ha följande signatur:​ ​’void
            // LäggTillMeddelande(string msg, string användare)’.​
            
            // ​Klassen skall även ha ett event med namnet ’NyttMeddelande’ som utlöses när ett nytt meddelande har skickats till
            // servern. När eventeten utlöses skall det förmedla information om det nya meddelande
            // samt vilken användare som skrivit det till de som lyssnar på eventet. Eventet skall
            // deklareras av den fördefinerade delegattypen ’EventHandler’.
            // ChattKlient-klassen​ ​skall ha två metoder med följande signaturer: ​’void Säg(string
            // msg)’, ’void Visa(string msg, string användare)’​.​ Visa-metoden skall visa upp ett nytt
            // meddelandet för användaren och är given nedan. Säg-metoden måste du
            // implementera själv men du kan anta att den blir anropad när en användare skriver ett
            // nytt meddelande i GUI:et.
        }
       

    }
}
