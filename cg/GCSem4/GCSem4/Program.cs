using System;

namespace GCSem4
{
    class Program
    {
        static void Main(string[] args)
        {
			//Problema 1
			Console.WriteLine("1. Dati doua puncte (x, y) (din care se va determina ecuatia dreptei):");

			Console.Write("Ax=");
			int Ax = int.Parse(Console.ReadLine());

			Console.Write("Ay=");
			int Ay = int.Parse(Console.ReadLine());

			Console.Write("Bx=");
			int Bx = int.Parse(Console.ReadLine());

			Console.Write("By=");
			int By = int.Parse(Console.ReadLine());

			Console.WriteLine("(y" + (-Ay) + ")/" + (By - Ay) + "=(x" + (-Ax) + ")/" + (Bx - Ax));

			//Problema 2
			Console.WriteLine("2. Dati un puncte si o dreapta (din care se va determina distanta de la punct la dreapta):");

			Console.WriteLine("Punctul A:");
			Console.Write("Ax=");
			int x = int.Parse(Console.ReadLine());
			Console.Write("Ay=");
			int y = int.Parse(Console.ReadLine());

			Console.WriteLine("Dreapta d:");
			Console.Write("a=");
			int a = int.Parse(Console.ReadLine());
			Console.Write("b=");
			int b = int.Parse(Console.ReadLine());
			Console.Write("c=");
			int c = int.Parse(Console.ReadLine());

			Console.WriteLine("Punctul A(" + x + "," + y + ")");
			Console.WriteLine("Dreapta d=" + a + "x+" + b + "y+" + c);
			Console.WriteLine("Distanta de la A la d este:" + Math.Abs(a * x + b * y + c) / Math.Sqrt(a * a + b * b));

			//Problema 3
			Console.WriteLine("Dati trei puncte (x,y) (din care se va determina aria triunghiului):");

			Console.Write("Ax=");
			Ax = int.Parse(Console.ReadLine());
			Console.Write("Ay=");
			Ay = int.Parse(Console.ReadLine());

			Console.Write("Bx=");
			Bx = int.Parse(Console.ReadLine());
			Console.Write("By=");
			By = int.Parse(Console.ReadLine());

			Console.Write("Cx=");
			int Cx = int.Parse(Console.ReadLine());
			Console.Write("Cy=");
			int Cy = int.Parse(Console.ReadLine());

			Console.WriteLine("A(" + Ax + "," + Ay + ")");
			Console.WriteLine("B(" + Bx + "," + By + ")");
			Console.WriteLine("C(" + Cx + "," + Cy + ")");
			Console.WriteLine("Aria este:" + Math.Abs(Ax * By + Bx * Cy + Ay * Cx - Cx * By - Bx * Cy - Ay * Cx) / 2);
		}
    }
}
