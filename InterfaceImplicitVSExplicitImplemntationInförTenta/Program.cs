using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceImplicitVSExplicitImplemntationInförTenta
{
    class Program
    {
        static void Main(string[] args)
        {
            // Nedan ges kod för ett interface IRitbar samt en klass Fyrkant som implementerar detsamma. 
            // 1. Vad innebär explicit respektive implicit implementation av interface? (1 poäng).
            // 2. Skriv kod för klassen Fyrkant som nyttjar explicit implementation. Illustrera vad det innebär (2 poäng).
            //3. Ange åtminstone en riktlinje för att välja implicit eller explicit implementation. (1 poäng).

            // 1 Svar: Implicit implementation innebär att metoderna är implementerade som vilka andra metoder som helst. Vid en...
            //implicit implementation kan metoderna anropas på ett vanligt sätt genom syntaxen 'Instans.Metodnamn'. 
            // Om ett interface implementeras explicit så implementeras alla interfacemedlemmar med prefixet...
            //för det aktuella interfacet (i detta fall prefixet 'IRitbar'). Vid en explicit implementation är...
            //medlemmarna direkt associerade med interfacetypen och operatorerna virtual, override och public...
            // är inte tillåtna för att de alltid antas av kompilatorn. Metoderna är inte åtkomstbara direkt...
            // genom syntaxen 'Instans.Metodnamn' utan instansen måste typomvandlas till interfacetypen först.

            //var fyrkant = new Fyrkant(new Point(50, 75), new Size(20, 40));
            //fyrkant.Rita(new Graphics());

            var fyrkant = new Fyrkant();
            IRitbar ritbar = fyrkant as IRitbar;
            ritbar.Rita(new Graphics());
        }

        public interface IRitbar
        {
            Point Position { get; }
            Size Storlek { get; }
            void Rita(Graphics g);
        }

        public class Fyrkant : IRitbar
        {
            Point IRitbar.Position { get; }
            Size IRitbar.Storlek { get; }


            void IRitbar.Rita(Graphics g)
            {
                g.DrawRectangle(
                    new Pen(new SolidBrush(Color.Black)),
                    new Rectangle(((IRitbar) this).Position, ((IRitbar) this).Storlek));
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
}
