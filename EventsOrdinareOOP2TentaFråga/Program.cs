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
            // Tentafråga Events (flera klasser behöver implementeras)
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
        // Ska utlösas INNAN förändringen i kodbasen genomförs.
        public event EventHandler<CodeChangingEventArgs> Codechanging;

        // Anropas när en utvecklare föreslår en ändring i databasen
        public void ProposeChange(int from, int to, string replaceStr)
        {

        }

        protected void OnProposedChange(CodeChangingEventArgs args)
        {
            if (Codechanging != null)
            {
                Codechanging(this, args);
            }
        }
    }
}
