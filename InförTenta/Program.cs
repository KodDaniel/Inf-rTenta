using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace InförTenta
{
    class Program
    {
        static void Main(string[] args)
        {
            // Nedan ges kod för ett interface IRitbar samt en klass Fyrkant som implementerar detsamma. 
            //1. Illustrera med hjälp av koden nedan hur polyformi kan erhållas...
            //med hjälp av interface (2 poäng).

            // Både klasserna Fyrkant och Rectangle implementerar IRitbar
            var fyrkant = new Fyrkant();
            var rektangel = new Rectangle();

            var listaMedRitbaraObjekt = new List<IRitbar>() {fyrkant, rektangel};

            foreach (IRitbar item in listaMedRitbaraObjekt)
            {
                if(item is Fyrkant)
                {
                    Console.WriteLine("Detta är en fyrkant");
                }

                if (item is Rectangle)
                {
                    Console.WriteLine("Detta är en rektangel.");
                }
            }
        }
    }

    public interface IRitbar
    {
        Point Position { get; }
        Size Storlek { get; }
        void Rita(Graphics g);
    }

    public class Fyrkant : IRitbar
    {
       public Point Position { get; private set; }
       public Size Storlek { get; private set; }

        //public Fyrkant(Point position, Size storlek)
        //{
        //    this.Storlek = storlek;
        //    this.Position = position;
        //}

        public void Rita(Graphics g)
        {
            g.DrawRectangle(
                new Pen(new SolidBrush(Color.Black)),
                new Rectangle(Position, Storlek));
        }
    }

    // Allt nedan är stödklasser för att få lärarens kod att ej få röda streck
    public class Graphics
    {
        public void DrawRectangle(Pen p, Rectangle r)
        {
            
        }
    }

        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Point(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }

        public class Size
        {
            public int Length { get; set; }
            public int Height { get; set; }

            public Size(int length, int height)
            {
                this.Height = height;
                this.Length = length;
            }
        }

        public class Pen
    {
        public Pen(SolidBrush brush)
        {
            
        }
     
    }

    public class SolidBrush
    {
        
        public SolidBrush(string black)
        {
            Color.Black = black; 
        }
    }

    public static class Color
    {
        public static string Black { get; set; }

    }

    public class Rectangle:IRitbar
    {
        public Point Position { get; private set; }
        public Size Storlek { get; private set; }
        public void Rita(Graphics g)
        {
            throw new NotImplementedException();
        }

        //public Rectangle(Point position, Size storlek)
        //{      
        //    this.Storlek = storlek;
        //    this.Position = position;        
        //}
    }
  
}
