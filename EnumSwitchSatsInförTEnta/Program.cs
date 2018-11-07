using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EnumSwitchSatsInförTEnta
{
    class Program
    {
        // Typ - INTE VARAIBEL. Detta är samma som om vi hade skrivit:
        private List<int> lista; 

        private static WeaponType weaponType

        // Detta är variabeln (som vi också tilldelar)
        public enum WeaponType
        {
            // Our constants 
            Sword,
            Staff,
            Dagger,
            Mace
        }
        static void Main(string[] args)
        {          
            // Notera att det är variabeln weaponType som kollas i Switch-satsen...
            //...och INTE TYPEN WeaponType
            switch (weaponType)
            {
                case WeaponType.Dagger:
                    Console.WriteLine("We have a Dagger");
                    break;

                case WeaponType.Mace:
                    Console.WriteLine("We have a Mace");
                    break;

                case WeaponType.Staff:
                    Console.WriteLine("Wwe have a Staff");
                    break;

                case WeaponType.Sword:
                    Console.WriteLine("We have a sword");
                    break;

                default:
                    Console.WriteLine("We have a UKNOWN weapon.");
                    break;


            }

            Console.ReadLine();

        }
        // An enum is short for "Enumrator".
        // It can be declared within a class or within a namespace - but not within a function. 
        // An enum is a way for us to create a datatype which we can limit ourself to specific things.
        // Like a string is specified to letters...
        //... and a UInt is specified to positive numbers.



    }


}
