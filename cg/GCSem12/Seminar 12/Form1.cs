using System;
using System.Drawing;
using System.Windows.Forms;

namespace Seminar_12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Graphics grp;
        Bitmap bmp;
        Color backColor;
        Color bc;

        public static Random rnd = new Random();
        private static PictureBox display;
        public static int rezx;
        public static int rezy;

        private void Form1_Load(object sender, EventArgs e)
        {
            backColor = Color.White;
            bmp = new Bitmap(Width, Height);
            grp = Graphics.FromImage(bmp);
            InitGraph(pictureBox1);
            grp.Clear(backColor);
        }

        public static void InitGraph(PictureBox T)
        {
            display = T;
            rezx = T.Width;
            rezy = T.Height;
        }

        public static PointF getRNDPoint()
        {
            return new PointF(rnd.Next(rezx), rnd.Next(rezy));
        }

        void point(PointF[] f)
        {
            for (int i = 0; i < f.Length; i++)
            {
                grp.DrawEllipse(new Pen(Color.Black, 3), f[i].X - 2, f[i].Y - 2, 4, 4);
                grp.FillEllipse(new SolidBrush(Color.Black), f[i].X - 2, f[i].Y - 2, 4, 4);
            }
        }

        double area(PointF a, PointF b, PointF c)
        {
            a.X -= c.X; b.X -= c.X;
            a.Y -= c.Y; b.Y -= c.Y;

            return Math.Abs((double)(a.X * b.Y - b.X * a.Y) / 2);
        }
       
        void areap(PointF[] p)
        {
            double areatot = 0;

            for (int i = 1; i < p.Length - 1; i++)
            {
                areatot += area(p[0], p[i], p[i + 1]);
            }

            textBox1.Text = $" {areatot}";
        }

        public static float CrossProductLength(float Ax, float Ay, float Bx, float By, float Cx, float Cy)
        {
            float BAx = Ax - Bx;
            float BAy = Ay - By;
            float BCx = Cx - Bx;
            float BCy = Cy - By;

            return (BAx * BCy - BAy * BCx);
        }

        public bool PolygonIsMonotone(PointF[] Points)
        {

            bool got_negative = false;
            bool got_positive = false;
            int num_points = Points.Length;
            int B, C;
            for (int A = 0; A < num_points; A++)
            {
                B = (A + 1) % num_points;
                C = (B + 1) % num_points;

                float cross_product =
                    CrossProductLength(
                        Points[A].X, Points[A].Y,
                        Points[B].X, Points[B].Y,
                        Points[C].X, Points[C].Y);
                if (cross_product < 0)
                {
                    got_negative = true;
                }
                else if (cross_product > 0)
                {
                    got_positive = true;
                }
                if (got_negative && got_positive) return false;
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PointF p1 = new PointF(70, 220);
            PointF p2 = new PointF(180, 80);
            PointF p3 = new PointF(310, 160);
            PointF p4 = new PointF(510, 40);
            PointF p5 = new PointF(640, 320);
            PointF p6 = new PointF(450, 240);
            PointF p7 = new PointF(250, 310);

            bc = Color.White;
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            grp.Clear(bc);
            PointF[] p = { p3, p4, p5, p6, p7, p1, p2 };
            point(p);

            grp.DrawPolygon(new Pen(Color.Black, 1), p);

            areap(p);

            pictureBox1.Image = bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bc = Color.White;
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            grp.Clear(bc);

            PointF[] points = new PointF[10];

            for (int i = 0; i < points.Length; i++)
            {
                points[i] = getRNDPoint();
                grp.DrawEllipse(new Pen(Color.Black), points[i].X - 2, points[i].Y - 2, 3, 4);
            }

            grp.DrawPolygon(new Pen(Color.Black, 1), points);

            if (PolygonIsMonotone(points) == true)
                textBox2.Text = "Polygon is monotone.";
            else
                textBox2.Text = "Polygon is NOT monotone.";

            pictureBox1.Image = bmp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bc = Color.White;
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            grp.Clear(bc);
            int xM = pictureBox1.Height / 8;
            int ym = pictureBox1.Width / 9;

            Point P1 = new Point((25 + xM) * 2, (10 + ym) * 2);
            Point P2 = new Point((60 + xM) * 2, (-10 + ym) * 2);
            Point P3 = new Point((60 + xM) * 2, (50 + ym) * 2);
            Point P4 = new Point((30 + xM) * 2, (65 + ym) * 2);
            Point P5 = new Point((45 + xM) * 2, (80 + ym) * 2);
            Point P6 = new Point((65 + xM) * 2, (-40 + ym) * 2);
            Point P7 = new Point((75 + xM) * 2, (-50 + ym) * 2);
            Point P8 = new Point((50 + xM) * 2, (-70 + ym) * 2);

            grp.DrawEllipse(new Pen(Color.Black), P1.X - 1, P1.Y - 1, 3, 4);
            grp.DrawEllipse(new Pen(Color.Black), P2.X - 1, P2.Y - 1, 3, 4);
            grp.DrawEllipse(new Pen(Color.Black), P3.X - 1, P3.Y - 1, 3, 4);
            grp.DrawEllipse(new Pen(Color.Black), P4.X - 1, P4.Y - 1, 3, 4);
            grp.DrawEllipse(new Pen(Color.Black), P5.X - 1, P5.Y - 1, 3, 4);
            grp.DrawEllipse(new Pen(Color.Black), P6.X - 1, P6.Y - 1, 3, 4);
            grp.DrawEllipse(new Pen(Color.Black), P7.X - 1, P7.Y - 1, 3, 4);
            grp.DrawEllipse(new Pen(Color.Black), P8.X - 1, P8.Y - 1, 3, 4);

            grp.DrawLine(new Pen(Color.Black), P6, P2);
            grp.DrawLine(new Pen(Color.Black), P2, P3);
            grp.DrawLine(new Pen(Color.Black), P1, P4);
            grp.DrawLine(new Pen(Color.Black), P4, P5);
            grp.DrawLine(new Pen(Color.Black), P5, P3);
            grp.DrawLine(new Pen(Color.Black), P6, P7);
            grp.DrawLine(new Pen(Color.Black), P7, P8);
            grp.DrawLine(new Pen(Color.Black), P8, P1);

            grp.DrawLine(new Pen(Color.Red), P2, P4);
            grp.DrawLine(new Pen(Color.Red), P4, P6);
            grp.DrawLine(new Pen(Color.Red), P6, P3);
            grp.DrawLine(new Pen(Color.Red), P4, P8);
            grp.DrawLine(new Pen(Color.Red), P6, P2);
            grp.DrawLine(new Pen(Color.Red), P4, P3);

            grp.DrawString("P1", new Font("Tahoma", 10), Brushes.Black, P1.X + 1, P1.Y + 3);
            grp.DrawString("P2", new Font("Tahoma", 10), Brushes.Black, P2.X + 1, P2.Y + 3);
            grp.DrawString("P3", new Font("Tahoma", 10), Brushes.Black, P3.X + 1, P3.Y + 3);
            grp.DrawString("P4", new Font("Tahoma", 10), Brushes.Black, P4.X + 1, P4.Y + 3);
            grp.DrawString("P5", new Font("Tahoma", 10), Brushes.Black, P5.X + 1, P5.Y + 3);
            grp.DrawString("P6", new Font("Tahoma", 10), Brushes.Black, P6.X + 1, P6.Y + 3);
            grp.DrawString("P7", new Font("Tahoma", 10), Brushes.Black, P7.X + 1, P7.Y + 3);
            grp.DrawString("P8", new Font("Tahoma", 10), Brushes.Black, P8.X + 1, P8.Y + 3);

            pictureBox1.Image = bmp;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bc = Color.White;
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            grp.Clear(bc);

            Point P1 = new Point(10*2, 30*2);
            Point P2 = new Point(50 * 2, 10 * 2);
            Point P3 = new Point(80 * 2, 20 * 2);
            Point P4 = new Point(110 * 2, 65 * 2);
            Point P5 = new Point(100 * 2, 90 * 2);
            Point P6 = new Point(90 * 2, 70 * 2);
            Point P7 = new Point(60 * 2, 120 * 2);
            Point P8 = new Point(40 * 2, 110 * 2);
            Point P9 = new Point(30 * 2, 65 * 2);
            Point P10 = new Point(20 * 2, 110 * 2);

            grp.DrawEllipse(new Pen(Color.Black), P1.X - 1, P1.Y - 1, 3, 4);
            grp.DrawEllipse(new Pen(Color.Black), P2.X - 1, P2.Y - 1, 3, 4);
            grp.DrawEllipse(new Pen(Color.Black), P3.X - 1, P3.Y - 1, 3, 4);
            grp.DrawEllipse(new Pen(Color.Black), P4.X - 1, P4.Y - 1, 3, 4);
            grp.DrawEllipse(new Pen(Color.Black), P5.X - 1, P5.Y - 1, 3, 4);
            grp.DrawEllipse(new Pen(Color.Black), P6.X - 1, P6.Y - 1, 3, 4);
            grp.DrawEllipse(new Pen(Color.Black), P7.X - 1, P7.Y - 1, 3, 4);
            grp.DrawEllipse(new Pen(Color.Black), P8.X - 1, P8.Y - 1, 3, 4);
            grp.DrawEllipse(new Pen(Color.Black), P9.X - 1, P9.Y - 1, 3, 4);
            grp.DrawEllipse(new Pen(Color.Black), P10.X - 1, P10.Y - 1, 3, 4);

            grp.DrawLine(new Pen(Color.Black), P1, P2);
            grp.DrawLine(new Pen(Color.Black), P2, P3);
            grp.DrawLine(new Pen(Color.Black), P3, P4);
            grp.DrawLine(new Pen(Color.Black), P4, P5);
            grp.DrawLine(new Pen(Color.Black), P5, P6);
            grp.DrawLine(new Pen(Color.Black), P6, P7);
            grp.DrawLine(new Pen(Color.Black), P7, P8);
            grp.DrawLine(new Pen(Color.Black), P8, P9);
            grp.DrawLine(new Pen(Color.Black), P9, P10);
            grp.DrawLine(new Pen(Color.Black), P10, P1);

            grp.DrawLine(new Pen(Color.Red), P1, P9);
            grp.DrawLine(new Pen(Color.Red), P2, P9);
            grp.DrawLine(new Pen(Color.Red), P4, P6);
            grp.DrawLine(new Pen(Color.Red), P6, P3);
            grp.DrawLine(new Pen(Color.Red), P6, P9);
            grp.DrawLine(new Pen(Color.Red), P6, P2);
            grp.DrawLine(new Pen(Color.Red), P7, P9);

            grp.DrawString("P1", new Font("Tahoma", 10), Brushes.Black, P1.X + 1, P1.Y + 3);
            grp.DrawString("P2", new Font("Tahoma",10), Brushes.Black, P2.X + 1, P2.Y + 3);
            grp.DrawString("P3", new Font("Tahoma", 10), Brushes.Black, P3.X + 1, P3.Y + 3);
            grp.DrawString("P4", new Font("Tahoma", 10), Brushes.Black, P4.X + 1, P4.Y + 3);
            grp.DrawString("P5", new Font("Tahoma",10), Brushes.Black, P5.X + 1, P5.Y + 3);
            grp.DrawString("P6", new Font("Tahoma", 10), Brushes.Black, P6.X + 1, P6.Y + 3);
            grp.DrawString("P7", new Font("Tahoma",10), Brushes.Black, P7.X + 1, P7.Y + 3);
            grp.DrawString("P8", new Font("Tahoma",10), Brushes.Black, P8.X + 1, P8.Y + 3);
            grp.DrawString("P9", new Font("Tahoma", 10), Brushes.Black, P9.X + 1, P9.Y + 3);
            grp.DrawString("P10", new Font("Tahoma",10), Brushes.Black, P10.X + 1, P10.Y + 3);

            pictureBox1.Image = bmp;
        }
    }
}
