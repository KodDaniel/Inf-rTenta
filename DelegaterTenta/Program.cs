using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DelegaterTenta
{
    class Program
    {

        static void Main(string[] args)
        {
            // 4 svar) myFunc kan kapsla in metoder som tar...
            // ...två (2) parametrar (int och int) och...
            // ...som returnerar ett boolskt värde.
            // True om x är större än y.
            Func<int, int, bool> myFunc = (x, y) => x > y;
        }

    }










}


