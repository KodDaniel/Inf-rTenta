using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillnadMellanInterfaceOchAbstraktKlassTenta
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public abstract class Mammal
    {
        public abstract void Eating();
    }

    // Tameable = "Tämjbar", "Möjlig att tämja".
    public interface ITameable
    {
        List<string> Tricks { get; set; }
        void MakeTricks(string trick);
    }

    // A Cat IS A Mammal: ABSTRACT
    // A Cat CAN be tamed: INTERFACE
    public class Cat: Mammal, ITameable
    {
        public List<string> Tricks { get; set; }
        public void MakeTricks(string trick)
        {
            // Making trick from the Trick-list.
        }
        // Overriding method from Abstract Class
        public override void Eating()
        {
            Console.WriteLine("*Eating fish*");
        }

    }

    
    }


   

  

}
