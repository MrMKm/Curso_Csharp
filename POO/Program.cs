using System;

namespace POO
{
    class Polygon
    {
        public decimal Base { get; set; }
        public decimal Height { get; set; }

        public virtual decimal GetArea()
        {
            return Base * Height;
        }
    }

    class Square : Polygon
    {
        public Square(decimal Base)
        {
            this.Base = Base;
        }
    }

    class Rectangle : Polygon
    {
        public Rectangle(decimal Base, decimal Height)
        {
            this.Base = Base;
            this.Height = Height;
        }
    }

    class Triangle : Polygon
    {
        public Triangle(decimal Base, decimal Height)
        {
            this.Base = Base;
            this.Height = Height;
        }

        public override decimal GetArea()
        {
            return Base * Height / 2m;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
