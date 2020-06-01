using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Problema_3
{
    public partial class Form1 : Form
    {
        static Bitmap draw = new Bitmap(550, 550);
        static Graphics g = Graphics.FromImage(draw);
        static SolidBrush b = new SolidBrush(Color.Black);
        static int minx = int.MaxValue, maxx = int.MinValue, poz1, poz2;
        static Pen red = new Pen(Color.Red, 2);
        static int timp = 0;
        static Pen green = new Pen(Color.DarkGreen, 2);
        static SolidBrush blue = new SolidBrush(Color.Blue);
        static Stack<Point> h = new Stack<Point>();
        static HashSet<Point> h2 = new HashSet<Point>();

        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = false;
        }
        double DistPoints(Point x1, Point x2)
        {
            return Math.Sqrt((x2.X - x1.X) * (x2.X - x1.X)) + ((x2.Y - x1.Y) * (x2.Y - x1.Y));
        }
        int Orientation(Point x1, Point x2, Point x3)
        {
            int x = (x3.Y - x1.Y) * (x2.X - x1.X) -(x2.Y - x1.Y) * (x3.X - x1.X);

            if (x > 0)
                return 1;
            if (x < 0)
                return -1;

            return 0;
        }
        int dist(Point x1, Point x2, Point x3)
            => Math.Abs(((x3.X - x1.Y) * (x2.X - x1.X) -(x2.Y - x1.Y) * (x3.X - x1.X)));

        private void button1_Click(object sender, EventArgs e)
        { 
            minx = int.MaxValue;
            maxx = int.MinValue;

            h.Clear();
            h2.Clear();

            pictureBox1.Image = draw;
            g.Clear(Color.White);

            Point[] p;
            int n = 7;
            Point l1, l2;
            p = new Point[10];
            Point[] fin = new Point[10];
            p[0] = new Point(20, 80);
            p[1] = new Point(10, 90);
            p[2] = new Point(50, 60);
            p[3] = new Point(80, 90);
            p[4] = new Point(10, 30);
            p[5] = new Point(60, 70);
            p[6] = new Point(60, 70);

            for (int i = 0; i<n; ++i)
            {
                g.FillRectangle(b, p[i].X, p[i].Y, 5, 5);
                if (p[i].X<minx)
                {
                    minx = p[i].X;
                    poz1 = i;
                }

                if (p[i].X > maxx)
                {
                    maxx = p[i].X;
                    poz2 = i;
                }
            }

            QuickHull(p, n, p[poz1], p[poz2], 1);
            QuickHull(p, n, p[poz1], p[poz2], -1);

            Point[] t = h2.ToArray();
            int k = 0;

            label4.Text = "The eliminated points: ";

            for (int i = 0; i<n; ++i)
            { 
                k = 0;

                for (int j = 0; j<t.Length; ++j)
                    if (p[i] == t[j])
                    {
                        k = 1;
                    }

                if (k == 0)
                {
                    label4.Text = label4.Text +"P"+$"{i+1}" + '(' + Convert.ToString(p[i].X) + ',' + Convert.ToString(p[i].Y) + "); ";
                    g.FillRectangle(blue, p[i].X, p[i].Y, 5, 5);
                }
            }

        }
        void QuickHull(Point[] p, int n, Point l1, Point l2, int side)
        {
            int dist1, maxdist = 0, q = -1;
            for (int i = 0; i < n; ++i)
            {
                dist1 = dist(l1, l2, p[i]);
                if (Orientation(l1, l2, p[i]) == side && dist1 > maxdist)
                {
                    q = i;
                    maxdist = dist1;
                }
            }

            if (q == -1)
            {
                g.DrawLine(red, l1, l2);
                h.Push(l1);
                h.Push(l2);
                h2.Add(l1);
                h2.Add(l2);
                return;
            }

            QuickHull(p, n, p[q], l1, -Orientation(p[q], l1, l2));
            QuickHull(p, n, p[q], l2, -Orientation(p[q], l2, l1));
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timp++;
        }
    }
}
