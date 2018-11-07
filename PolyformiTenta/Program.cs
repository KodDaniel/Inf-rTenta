using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PolyformiTenta
{
    class Program
    {
        static void Main(string[] args)
        {

            var VD = new VD();

            VD.SkrivUtNamnn("Bill Gates");

            VD.SkrivUtMinimilön();

            Console.ReadLine();
        }
    }  
    abstract class Anställd
    {
        public void SkrivUtNamnn(string namn)
        {
            Console.WriteLine("Den anställde heter {0}",namn);
        }

        public virtual void SkrivUtMinimilön()
        {
            Console.WriteLine("Minimlönen är 3000 kronor per år");
        }     
    }

    class VD: Anställd
    {
        public override void SkrivUtMinimilön()
        {
            Console.WriteLine("En VD kan tjäna hur mycket som helst.");
        }
    }

    





}




