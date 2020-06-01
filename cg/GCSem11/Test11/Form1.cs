using System;
using System.Drawing;
using System.Windows.Forms;

namespace GCSem11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PointF a = new PointF(20 * 2, 80 * 2);
            PointF b = new PointF(50 * 2, 25 * 2);
            PointF c = new PointF(110 * 2, 70 * 2);
            PointF d = new PointF(90 * 2, 130 * 2);
            PointF E = new PointF(60 * 2, 70 * 2);
            PointF f = new PointF(35 * 2, 110 * 2);
            PointF g = new PointF(30 * 2, 80 * 2);

            PointF[] p = { a, b, c, d, E, f, g };
            PointF[] t1 = { a, b, g };
            PointF[] t2 = { f, E, g };
            PointF[] t3 = { b, E, g };
            PointF[] t4 = { c, E, b };
            PointF[] t5 = { d, E, c };

            Color bc = Color.White;
            Bitmap bmp2 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics grp2 = Graphics.FromImage(bmp2);
            grp2.Clear(bc);

            Pen pen = new Pen(Color.Black, 1);

            grp2.FillPolygon(new SolidBrush(Color.Red), t1);
            grp2.FillPolygon(new SolidBrush(Color.Blue), t2);
            grp2.FillPolygon(new SolidBrush(Color.Green), t3);
            grp2.FillPolygon(new SolidBrush(Color.Blue), t4);
            grp2.FillPolygon(new SolidBrush(Color.Red), t5);

            grp2.DrawPolygon(pen, p);

            grp2.DrawLine(new Pen(Color.Black, 1), g, b);
            grp2.DrawLine(new Pen(Color.Black, 1), g, E);
            grp2.DrawLine(new Pen(Color.Black, 1), E, b);
            grp2.DrawLine(new Pen(Color.Black, 1), c, E);

            grp2.DrawEllipse(pen, a.X - 3, a.Y - 3, 6, 6);
            grp2.FillEllipse(new SolidBrush(Color.Red), a.X - 3, a.Y - 3, 6, 6);
            grp2.DrawEllipse(pen, b.X - 3, b.Y - 3, 6, 6);
            grp2.FillEllipse(new SolidBrush(Color.Green), b.X - 3, b.Y - 3, 6, 6);
            grp2.DrawEllipse(pen, c.X - 3, c.Y - 3, 6, 6);
            grp2.FillEllipse(new SolidBrush(Color.Blue), c.X - 3, c.Y - 3, 6, 6);
            grp2.DrawEllipse(pen, d.X - 3, d.Y - 3, 6, 6);
            grp2.FillEllipse(new SolidBrush(Color.Green), d.X - 3, d.Y - 3, 6, 6);
            grp2.DrawEllipse(pen, E.X - 3, E.Y - 3, 6, 6);
            grp2.FillEllipse(new SolidBrush(Color.Red), E.X - 3, E.Y - 3, 6, 6);
            grp2.DrawEllipse(pen, f.X - 3, f.Y - 3, 6, 6);
            grp2.FillEllipse(new SolidBrush(Color.Green), f.X - 3, f.Y - 3, 6, 6);
            grp2.DrawEllipse(pen, g.X - 3, g.Y - 3, 6, 6);
            grp2.FillEllipse(new SolidBrush(Color.Blue), g.X - 3, g.Y - 3, 6, 6);

            bmp2.RotateFlip(RotateFlipType.Rotate180FlipX);
            pictureBox1.Image = bmp2;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Engine.InitGraph(pictureBox1);
            Engine.initP();
            Engine.drawMAP();
        }
    }
}
