using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsChattServer
{
    class Program
    {
        static void Main(string[] args)
        {
            // När jag skapar ett Server-objekt så aktiveras prenumerationen.
            // Kom ihåg varför: du upprättar prenumerationen i den klassens konstruktor
            var chattServer = new Chattserver();
            var chattKlient = new Chattklient(chattServer, "Daniel");
            // Metoden säg är första stationen sett utifrån GUI
            chattKlient.Säg("Hur är läget?");
            Console.ReadLine();

        }
    }

    public class ChattArgs : EventArgs
    {
        public string Användare { get; set; }
        public string Meddelande { get; set; }


    }

    public class Chattserver
    {
        public event EventHandler<ChattArgs> NyttMeddelande;


        public void LäggTillNyttMeddelande(string msg, string användare)
        {
            var chattArgsObj = new ChattArgs { Meddelande = msg, Användare = användare };
            OnNyttMeddelande(chattArgsObj);
        }




        protected void OnNyttMeddelande(ChattArgs args)
        {
            if (NyttMeddelande != null)
            {
                NyttMeddelande(this, args);
            }
        }
    }

    public class Chattklient
    {
        private Chattserver Server;
        private string Användare;

        public Chattklient(Chattserver server, string användare)
        {
            // Instansierar
            this.Server = server;
            this.Användare = användare;

            // Upprättar prenumeration
            Server.NyttMeddelande += ReceiverNyttMeddelande;

        }

        public void ReceiverNyttMeddelande(object sender, ChattArgs args)
        {
            Visa(args.Användare, args.Meddelande);
        }


        // Uppgiften säger att denna metod skall: "Visa upp ett nytt meddelande för användaren"
        void Visa(string msg, string användare)
        {
            Console.WriteLine(användare + ": " + msg);
        }

        // Uppgiften säger att denna metod skall: "Anropas när en användare skriv ett nytt meddelande i GUI (program.cs)
        public void Säg(string msg)
        {
            Server.LäggTillNyttMeddelande(Användare, msg);
        }
    }





}
