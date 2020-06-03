using System;

namespace AbstractPoints
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractPoint.PointRepresentation polar = AbstractPoint.PointRepresentation.Polar;
            Point point1 = new Point(polar, -12, (2 * Math.PI / 3));

            Console.WriteLine($"point1 coordinates (x, y) - [r, A] : {point1}.\n");

            Point point2 = new Point(polar, 6, Math.PI / 3);

            Console.WriteLine($"point2 coordinates (x, y) - [r, A] : {point2}.\n");

            point2.Rotate(Math.PI / 3);

            Console.WriteLine($"point2 rotated by 45 degrees: {point2}.\n");

            AbstractPoint.PointRepresentation rectangular = AbstractPoint.PointRepresentation.Rectangular;
            Point point3 = new Point(rectangular, 34, 12);

            Console.WriteLine($"point3 coordinates (x, y) - [r, A] : {point3}.\n");

            point3.Move(12, 44);

            Console.WriteLine($"point3 moved by x += 12 and y += 44 position: {point3}.");
        }
    }
}
