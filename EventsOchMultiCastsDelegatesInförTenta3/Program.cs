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

        }
    }

    public class ChattArgs : EventArgs
    {
        public string Användare { get; set; }
        public string Meddelande { get; set; }
    }

    public class ChattServer
    {
        public event EventHandler<ChattArgs> NyttMeddelande;

        public void LäggTillNyttMeddelande(string msg, string användare)
        {
            var chattArgs = new ChattArgs { Användare = användare, Meddelande = msg };
            OnNyttMeddelande(chattArgs);
        }

        protected void OnNyttMeddelande(ChattArgs args)
        {
            if (NyttMeddelande != null)
            {
                NyttMeddelande(this, args);
            }
        }

    }

    public class ChattKlient
    {
       

        void ReciverNyttMeddelande(object sender, ChattArgs e)
        {

        }

        public void Visa(string meddelande, string användare)
        {
            Console.WriteLine(användare + ": " + meddelande);
            Console.ReadLine();
        }

        public void Säg(string msg)
        {
        }

    }







}
