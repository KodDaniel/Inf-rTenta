using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InförTenta
{
    class Program
    {
        static void Main(string[] args)
        {
            // Nedan ges kod för ett interface IRitbar samt en klass Fyrkant som implementerar detsamma. 
            // 1. Vad innebär explicit respektive implicit implementation av interface? (1 poäng).
            // 2. Skriv kod för klassen Fyrkant som nyttjar explicit implementation. Illustrera vad det innebär (2 poäng).
            //3. Ange åtminstone en riktlinje för att välja implicit eller explicit implementation. (1 poäng).
            //4. Illustrera hur polyformi kan erhållas med hjälp av interface (2 poäng).
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

        public Fyrkant(Point position, Size storlek)
        {
            this.Storlek = storlek;
            this.Position = position;
        }

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

    }

    public class Size
    {

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

    public class Rectangle
    {
        public Point Position { get; private set; }
        public Size Storlek { get; private set; }

        public Rectangle(Point position, Size storlek)
        {      
            this.Storlek = storlek;
            this.Position = position;        
        }
    }
  
}
