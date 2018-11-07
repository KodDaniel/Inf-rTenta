﻿using System;
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
            var fyrkant = new Fyrkant(new Point(23,23),new Size(2,1));
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
           public Point Position { get; private set; }
           public Size Storlek { get; private set; }

            public Fyrkant(Point position, Size storlek)
            {
                this.Position = position;
                this.Storlek = storlek;
            }

            void IRitbar.Rita(Graphics g)
            {
               g.DrawRectangle(new Pen(new SolidBrush(Color.Black)), 
                   new Rectangle(Position,Storlek));             
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
