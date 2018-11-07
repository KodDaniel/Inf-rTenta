using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tEMP
{
    class Program
    {
        static void Main(string[] args)
        {
            var sc = new SampleClass();

            IControl cont = sc as IControl;
            ISurface surf = sc as ISurface;

            cont.Paint();
            surf.Paint();
        }
    }

    interface IControl
    {
        void Paint();
    }

    interface ISurface
    {
        void Paint();
    }

    public class SampleClass : IControl, ISurface
    {
        void IControl.Paint()
        {
            Console.WriteLine("IControl-method in SampleClass");
        }

        void ISurface.Paint()
        {
            Console.WriteLine("ISurface-method in SampleClass");
        }
    }
}
