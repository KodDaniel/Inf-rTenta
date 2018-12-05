using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EventsOrdinareOOP2TentaFråga
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new CodeRepository("class Car {public string Brand {get;set;} }");

            Console.WriteLine("Init codebase: " + repo.CodeBase);


            // Upprättar prenumeration
            repo.CodeChanging += Repo_CodeChanging;
            repo.CodeChanging += Repo_CodeChanging2;

            try  // Rad 12
            {
                repo.ProposeChange(6, 8, "Bil");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Operation was rejected");
            } // rad 16

            try 
            {
                repo.ProposeChange(26, 30, "Märke");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Operation was rejected");
            }

            try
            {
                repo.ProposeChange(39, 39, "private");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Operation was rejected");

            }

            Console.WriteLine("Current codebase: " + repo.CodeBase);

            Console.ReadLine();

        }

        // EventReciver 1
        static void Repo_CodeChanging(object sender, CodeChangingEventArgs e)
        {
            Console.WriteLine("Checking Rule: no swedish (åäö)");

            if (e.ReplaceStr.Any(x => "å,ä,ö".Contains(x)))
            {
                e.RejectOperation();
            }
        }
        // EventReciver 2
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
            get { return this._isRejected; }
        }

        // Om denna metod anropas innebär det att Operation kommer sättas till rejected. 
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

    class CodeRepository
    {
        public EventHandler<CodeChangingEventArgs> CodeChanging;

        //Förvaras i egenskap med private set, härleder det ur utseendet på program.cs 
        public string CodeBase { get; private set; }

        //Sätt "CodeBase" till ett värde när repot skapas. 
        public CodeRepository(string firstCode)
        {
            CodeBase = firstCode;

        }

        public void ProposeChange(int from, int to, string replacestr)
        {

            //Plocka ut värdet av CodeBase från början fram till dess att den ska ändras
            string firstHalfOfOldCode = CodeBase.Substring(0, from);

            //Plocka ut värdet av CodeBase från det att den ska ändras, t.o.m slutet
            string secondHalfOfOldCode = CodeBase.Substring(to + 1, CodeBase.Length - (to + 1));

            //Sätt ihop den första halvan av det som ska behållas av koden, det nya värdet,
            //och den andra halvan av det som ska behållas.
            string newUpdatedCode = firstHalfOfOldCode + replacestr + secondHalfOfOldCode;

            // Skapar event-objekt och lägger in information som ska skickas till Event recivers
            var eventObject = new CodeChangingEventArgs(from, to, replacestr);
            
            //Trigga eventet "Code Changing"
               OnCodeChanging(eventObject);

            // Om vi nu har att IsOperationRecjted - kasta  InvalidOperationException
            if (eventObject.IsOperationRejected)
            {
                throw new InvalidOperationException();
            }
            else
            {
                //Annnars: Operationen är godkänd och vi sätter det nya värdet
                CodeBase = newUpdatedCode;
            }
                    
        }
        // Event publisher
        protected void OnCodeChanging(CodeChangingEventArgs args)
        {
            if (CodeChanging != null)
            {
                CodeChanging(this, args);
            }
        }
    }
}


