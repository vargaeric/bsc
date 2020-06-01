using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Jarvis
{
	class Engine
	{
		public static Bitmap b;
		public static Graphics g;
		public static int resx;
		public static int resy;
		public static Random r = new Random();

		public static void InitGraph()
		{
			b = new Bitmap(resx, resy);
			g = Graphics.FromImage(b);
		}

		public static void initPoint()
		{
			for (int i = 0; i < Jarvis.n; i++)
			{
				Point New = new Point(r.Next(r.Next(50, 150), resx - r.Next(50, 150)), r.Next(r.Next(50, 150), resy - r.Next(50, 150)));
				Jarvis.Points.Add(New);
			}
		}

		public static void draw()
		{
			foreach (Point p in Jarvis.Points)
				g.FillEllipse(Brushes.Red, p.X - 3, p.Y - 3, 6, 6);
		}
	}
}
