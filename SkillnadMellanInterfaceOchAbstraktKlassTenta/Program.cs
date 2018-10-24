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
        public abstract void Mating(); 
    }

    // Tameable = "Tämjbar", "Möjlig att tämja".
    public interface ITameable
    {
        List<string> Tricks { get; set; }
        void MakeTricks(string trick);
    }

    // A Cat IS A Mammal
    // A Cat CAN be tamed
    public class Cat: Mammal, ITameable
    {
        public List<string> Tricks { get; set; }
        public void MakeTricks(string trick)
        {
            // Making trick from the Trick-list.
        }
        public override void Eating()
        {
            // Eating Cat-food
        }

        public override void Mating()
        {
            // Mating with other cats
        }
    
    }

    // A Whale IS A mammal
    // A Whale CANNOT be tamed.
    public class Whale : Mammal
    {
        public override void Eating()
        {
            // Eating fish
        }

        public override void Mating()
        {
            // Mating with other whales
        }
    }


   

  

}
