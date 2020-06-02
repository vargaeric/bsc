using System;

namespace _2DForms
{
    public class Square : IForm2D
    {
        public int SideLength { get; set; }
        public string Name { get; }

        public Square()
        {
            SideLength = 0;
        }

        public Square(int SideLength, string Name)
        {
            this.SideLength = SideLength;
            this.Name = Name;
        }

        public double Area()
            => Math.Pow(SideLength, 2);

        public double Perimeter()
            => 4 * SideLength;

        public override string ToString()
            => $"This is a square instance named {Name} with a {SideLength} side length!";
    }
}
