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
        // 1. Betrakta koden nedan och notera att vissa variabler saknar tilldelning
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
