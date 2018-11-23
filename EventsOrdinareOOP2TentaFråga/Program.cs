using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsOrdinareOOP2TentaFråga
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new CodeRepository(
             "class Car {public string Brand {get;set;} }"                 
                );

       
        
            // Upprättar prenumeration
            repo.Codechanging += Repo_CodeChanging;
            repo.Codechanging += Repo_CodeChanging2;

        }

        // EventReciver 1; Denna metod prenumerar på mitt CodeChanging-Event och kommer därmed...
        //...alltid anropas. Men om if-satsen inte är true så jag ju bara gå rakt igenom metoden utan åtgärd.
        static void Repo_CodeChanging(object sender, CodeChangingEventArgs e)
        {
            Console.WriteLine("Checking Rule: no swedish (åäö)");

            if (e.ReplaceStr.Any(x => "å,ä,ö".Contains(x)))
            {
                e.RejectOperation();
            }
        }
        // EventReciver 2: Denna metod prenumerar på mitt CodeChanging-Event och kommer därmed...
        //...alltid anropas. Men om if-satsen inte är true så jag ju bara gå rakt igenom metoden utan åtgärd.
        static void Repo_CodeChanging2(object sender, CodeChangingEventArgs e)
        {
            Console.WriteLine("Checking Rule. locked code base from char 6 to 8");
            int lockedFrom = 6;
            int lockedTo = 8;

            if (e.From >= lockedFrom && e.From <= lockedTo || e.To >= lockedFrom && e.To <= lockedTo)
            {
                e.RejectOperation();
            }

        }
    }

    class RejectableEventArgs : EventArgs
    {
        private bool _isRejected = false;
         
        public bool IsOperationRejected
        {
            get
            {
                return this._isRejected;
            }
        }

       // Om denna metod anropas innebär det att Operation är rejected. 
        public void RejectOperation()
        {
            this._isRejected = true;
        }
    }

    class CodeChangingEventArgs : RejectableEventArgs
    {
        public int From { get; private set; }
        public int To { get; private set; }
        public string ReplaceStr { get; private set; }

        public CodeChangingEventArgs(int from, int to, string replaceStr)
        {
            this.From = from;
            this.To = to;
            this.ReplaceStr = replaceStr;
        }
    }

    class CodeRepo
    {

        //Koden kan förvaras i en privat sträng
        private string _code;

        //Sätt "code" till ett värde när repot skapas. 
        public CodeRepo(string firstCode)
        {
            _code = firstCode;

            
        }

        public void ProposeChange(int from, int to, string replacestr)
        {

            //Plocka ut värdet av code från början fram till dess att den ska ändras
            string firstHalfOfOldCode = _code.Substring(0, from);

            //Plocka ut värdet av code från det att den ska ändras, t.o.m slutet
            string secondHalfOfOldCode = _code.Substring(to, _code.Length);

            //Sätt ihop den första halvan av det som ska behållas av koden, det nya värdet, och den andra halvan av det som ska behållas
            string newCode = firstHalfOfOldCode + replacestr + secondHalfOfOldCode;

            //Trigga eventet "Code Changing"

            //Sätt det nya värdet
            _code = newCode;
        }
    }
}


