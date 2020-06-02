using System;

namespace _2DForms
{
    public class Circle : IForm2D
    {
        public int Radius { get; set; }
        public string Name { get; }

        public Circle()
        {
            Radius = 0;
        }

        public Circle(int Radius, string Name)
        {
            this.Radius = Radius;
            this.Name = Name;
        }

        public double Area()
            => Math.PI * Math.Pow(Radius, 2);

        public double Perimeter()
            => 2 * Math.PI * Radius;

        public override string ToString()
            => $"This is a circle instance named {Name} with a {Radius} radius!";
    }
}
