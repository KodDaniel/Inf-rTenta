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
            var instansAvServer = new ChattServer();

            var instansAvChattKlient = new ChattKlient(instansAvServer, "Daniel");

            instansAvChattKlient.Säg("Detta är ett chattmeddelande");
        }
    }

    public class NyttMeddelandeEventArgs : EventArgs
    {
        public string Text { get; set; }
        public string Användare { get; set; }

        public NyttMeddelandeEventArgs(string text, string användare)
        {
            this.Text = text;
            this.Användare = användare;
        }
    }
        // Publisher-klass
        public class ChattServer
        {
            // EVENT och DELGATE in same
            public event EventHandler<NyttMeddelandeEventArgs> NyttMeddelande;
            
            public void LäggTillNyttMeddelande(string msg, string användare)
            {
                // Om vi varken har ett tomt msg eller en tom användare: 
                // Gå in i If-satsen
                if (!string.IsNullOrEmpty(msg) && !string.IsNullOrEmpty(användare))
                {
                    // Spara meddelandet och användaren i en instans av...
                    // NyttMeddelandeEventArgs
                    var e = new NyttMeddelandeEventArgs(msg,användare);
                   
                    //Skickar denna instans till min Event publisher
                    OnNyttMeddelande(e);
                }
                
            }

            // Event Publisher: tar emot objekt med information deklarerad ovan
            protected virtual void OnNyttMeddelande(NyttMeddelandeEventArgs e)
            {
                // Om vi har subscribers gå in i if-sats
                if (NyttMeddelande != null)
                {
                    //  Skicka Event till Subscribers
                    NyttMeddelande(this, e);
                }
            }
        }

    // Subscriber-Klass
    public class ChattKlient
    {
        // Raden nedan är en instans av min publisher
        ChattServer Server;
        string Användare;
        
        public ChattKlient(ChattServer server, string användare)
        {
            this.Server = server;
            this.Användare = användare;

            // Upprättar prenumeration 
            Server.NyttMeddelande+=OnNyttMeddelande;
            
        }

        // Event reciver
        void OnNyttMeddelande(object sender, NyttMeddelandeEventArgs args)
        {
            // Anropar metoden visa som har som uppgift att visa på konsol
            Visa(args.Text, args.Användare);
        }

        // Visar upp msg för användaren
        public void Visa(string meddelande, string användare)
        {
            Console.WriteLine(användare + ": " + meddelande);
            Console.ReadLine();
        }

        //  Vi ANTAR att denna metod anropas när användaren...
        // skriver ett msg.
        public void Säg(string meddelande)
        {
            Server.LäggTillNyttMeddelande(meddelande, Användare);
        }
    }

      


       

   
}
