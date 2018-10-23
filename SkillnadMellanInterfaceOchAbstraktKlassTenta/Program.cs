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
            // 1. Redogör för skillnaden mellan interface och abstrakta klasser. Ge ett kodexempel då...
           // ...det ens är att föredra framför det andra. Motivera ditt svar.

            // 1 Svar: Ett interface skildrar en "kan-göra"- relation medan en abstrakt klass skildrar...
            // en "är en"-relation.
            // I ett interface anger man endast publika medlemmar och behöver därför
            // ...inte använda några åtkomstoperatorer.
            // Det går inte att implementera interfacemedlemmar.
            // En abstrakt klass kan innehåla implementationer...
            //av till exempel egenskaper och använda sig av åtkomstoperatorer.
            //En abstrakt klass kan också ha en konstruktorer.
            // En klass kan ärva av flera interfaces men endast av en (1) abstrakt klass. 
        }
    }

    interface IAnimal
    {
        // Eftersom denna kod beskriver vad något kan GÖRA så är...
        // är ett interface mer lämpligt än en abstrakt klass.
       
        void MakeNoise();
    }

    abstract class Animal
    {
        // Eftersom denna kod beskriver vad något ÄR, så är...
        //...en abstrakt klass mer lämplig än ett interface.     
        protected Animal()
        {
            
        }
        protected abstract void IsThisAnimal(string typeOfAnimal); 

    }
}
