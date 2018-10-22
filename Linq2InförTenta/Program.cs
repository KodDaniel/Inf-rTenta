using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Linq2InförTenta
{
    class Program
    {
        // Betrakta koden nedan och notera att vissa variabler saknar tilldelning.
        
        //Besvara frågorna nedan med användande av Standard Query Operators och
        //lambdauttryck:
        
        //a) 1p.Tilldela variabeln ‘passing’ ett LINQ-uttryck som filtrerar fram de godkända
        //betygen från ‘gradeList’. Ett betyg är godkänt om det är åtminstone 2.5.
        
        //b) 2p.Tilldela variabeln ‘passingNamesOrdered’ ett LINQ-uttryck så att namnen för de
        //godkända betygen från variabeln ‘passing’ ordnas i alfabetisk ordning.Variabeln
        //‘passingNamesOrdered’ skall endast innehålla namn, icke betyg.
        
        // c) 3p.Tilldela variabeln ‘top3OrderedByName’ ett LINQ-uttryck för att finna de högsta
        //tre betygen bland alla element i alfabetisk ordning.Mer exakt, de namn som skall
        //visas med Console.WriteLine är i denna ordning: Agneta, Alf, Elin.
        
        //d) 4p.Ändra efter Console-raden i for-each loopen så att den inte enbart skriver ut
        // namnet på den som erhållit betyget, utan även bokstavsbetyget som matchar
        // poängbetyget.Nyttja skalan som ges i variabeln ‘letterPoints’. Mer exakt, output skall
        //bli: Agneta B, Alf A, Elin A.
        
        // e) Det är möjligt att kedja vissa LINQ-metoder så att de följer på varandra, t ex//Where().Select().Where().
        //Vad är förutsättningen för att en sådan kedjning skall vara möjlig.
  
        // f) Det är även möjligt att skriva nya LINQ-metoder genom att använda ‘extension
        //methods’. Skriv en ny ‘extension method’ med eget valt syfte och som är kedjbar med
        // existerande metoder som Where(), Select(), OrderBy()

        public class GradeEntry { public double Grade; public string Name; }
        public class PointToLetter { public double Point; public string Letter; }

        static void Main(string[] args)
        {

            List<GradeEntry> gradelList = new List<GradeEntry>()
            {
                new GradeEntry() {Grade = 1.2, Name = "Dagny"},
                new GradeEntry() {Grade = 3.8, Name = "Alf"},
                new GradeEntry() {Grade = 2.4, Name = "Kalle"},
                new GradeEntry() {Grade = 3.4, Name = "Agneta"},
                new GradeEntry() {Grade = 3.9, Name = "Elin"},
                new GradeEntry() {Grade = 3.1, Name = "Catrine"}
            };

            List<PointToLetter> letterPoints = new List<PointToLetter>()
            {
                new PointToLetter() {Letter = "A", Point = 3.5},
                new PointToLetter() {Letter = "B", Point = 2.5},
                new PointToLetter() {Letter = "C", Point = 1.5},
                new PointToLetter() {Letter = "D", Point = 0.5},
                new PointToLetter() {Letter = "F", Point = 0.0}
            };

            var passing = "Placeholder";
            var passingNamesOrdered = "Placeholder";
            var top3OrderedByName = "Placeholder";

            foreach (var n in top3OrderedByName)
            {
                Console.WriteLine(/*n.Name*/);
            }

            Console.ReadKey();
        }
    }

   


}
