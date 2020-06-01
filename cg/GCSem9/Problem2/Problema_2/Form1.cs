using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Problema_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Graphics grp;
        Bitmap bmp;
        List<Point> points;
        Point[] pointArray;
        Dictionary<Point, string> hash = new Dictionary<Point, string>();
        int index;

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pB.Width, pB.Height);
            grp = Graphics.FromImage(bmp);

            points = new List<Point>();
            points.Add(new Point(11,110));
            points.Add(new Point(20, 90));
            points.Add(new Point(30, 100));
            points.Add(new Point(40, 90));
            points.Add(new Point(50, 70));
            points.Add(new Point(6, 70));
            points.Add(new Point(70, 110));

            labelPoints.Visible = false;
            labelEnumPoints.Visible = false;
           
            buttonNext.Enabled = false;
        }
        private List<Point> Graham(Point[] points)
        {
            int index = 0;
            for (int i = 1; i < points.Length; i++)
                if (points[i].X < points[index].X ||
                    (points[i].X == points[index].X && points[i].Y > points[index].Y))
                    index = i;

            Swap(ref points[0], ref points[index]);
            Sort(points);
            Insert(ref points);

            int pointsNr = 2;
            int steps = 0;

            for (int i = 3; i < points.Length; i++)
            {
                while (pointsNr > 1 && Orientation(points[pointsNr - 1], points[pointsNr], points[i]) >= 0)
                    pointsNr--;

                pointsNr++;

                Swap(ref points[pointsNr], ref points[i]);
            }

            Array.Resize(ref points, pointsNr + 1);

            return points.ToList();
        }

        int pointNrs = 2;

        public void GrahamStep(int i)
        {
            grp.DrawEllipse(new Pen(Color.Red), pointArray[i].X, pointArray[i].Y, 3, 3);
            grp.FillEllipse(new SolidBrush(Color.Red), pointArray[i].X, pointArray[i].Y, 3, 3);

            while (pointNrs > 1 && Orientation(pointArray[pointNrs-1],pointArray[pointNrs],pointArray[i])>=0)
            {
                grp.DrawLine(new Pen(pB.BackColor), pointArray[pointNrs - 1], pointArray[pointNrs]);
                pointNrs--;
            }

            pointNrs++;
       
            Swap(ref pointArray[pointNrs], ref pointArray[i]);

            labelEnumPoints.Text = "";

            for (int j = 0; j < pointNrs; j++)
                labelEnumPoints.Text += hash[pointArray[j]] + " ";

            for (int j = 0; j < pointNrs-1; j++)
                grp.DrawLine(new Pen(Color.Blue), pointArray[j], pointArray[j + 1]);

            pB.Image = bmp;
        }
        public void Swap(ref Point a, ref Point b)
        {
            Point aux = new Point();
            aux = a;
            a = b;
            b = aux;
        }

        private float Orientation(Point A, Point B, Point C)
        {
            double temp = (B.Y - A.Y) * (C.X - A.X) - (C.Y - A.Y) * (B.X - A.X);

            if (temp < 0)
                return -1;
            else if (temp == 0)
                return 0;
            else
                return 1;
        }

        private void Sort(Point[] points)
        {
            for (int i = 1; i < points.Length - 1; i++)
            {
                float axisXi = points[0].X - points[i].X;
                float axisYi = points[0].Y - points[i].Y;

                for (int j = i + 1; j < points.Length; j++)
                {
                    float axisXj = points[0].X - points[j].X;
                    float axisYj = points[0].Y - points[j].Y;

                    if (axisYi * axisXj > axisYj * axisXi)
                    {
                        Swap(ref points[i], ref points[j]);
                        axisXi = points[0].X - points[i].X;
                        axisYi = points[0].Y - points[i].Y;
                    }
                }
            }
        }
        private void Insert(ref Point[] points)
        {
            Array.Resize(ref points, points.Length + 1);

            for (int i = points.Length - 1; i > 0; i--)
                points[i] = points[i - 1];

            points[0] = points[points.Length - 1];
        }

        int curent = 3;

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < points.Count; i++)
            {
                hash.Add(new Point(points[i].X*3,points[i].Y*3), "P" + (i + 1));
            }

            int pointwidth = 5;
           
            pointArray = points.ToArray();

            for (int i = 0; i < pointArray.Length; i++)
            {
                pointArray[i] = new Point(pointArray[i].X * 3, pointArray[i].Y * 3);
                grp.DrawEllipse(new Pen(Color.Black), pointArray[i].X, pointArray[i].Y, pointwidth, pointwidth);
                grp.FillEllipse(new SolidBrush(Color.Black), pointArray[i].X, pointArray[i].Y, pointwidth, pointwidth);
                grp.DrawString("P" + (i + 1), new Font(FontFamily.GenericMonospace, 10, FontStyle.Bold), new SolidBrush(Color.Black), pointArray[i]);
            }

            index = 0;

            for (int i = 1; i < pointArray.Length; i++)
                if (pointArray[i].X < pointArray[index].X ||
                    (pointArray[i].X == pointArray[index].X && pointArray[i].Y > pointArray[index].Y))
                    index = i;

            Swap(ref pointArray[0], ref pointArray[index]);
            Sort(pointArray);
            Insert(ref pointArray);

            labelPoints.Visible = true;
            labelEnumPoints.Visible = true;
            labelEnumPoints.Text = "";

            for (int i = 0; i <= 2; i++)
                labelEnumPoints.Text += hash[pointArray[i]] + " ";
            for (int i = 0; i < 2; i++)
                grp.DrawLine(new Pen(Color.Black), pointArray[i], pointArray[i + 1]);

            buttonStart.Enabled = false;
            buttonNext.Enabled = true;

            pB.Image = bmp;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (curent < pointArray.Length)
            {
                GrahamStep(curent);
                curent++;
            }
            else
            {
                Array.Resize(ref pointArray, pointNrs + 1);

                for (int j = 0; j < pointArray.Length-1; j++)
                    grp.DrawLine(new Pen(Color.Blue), pointArray[j], pointArray[j + 1]);

                grp.DrawLine(new Pen(Color.Blue), pointArray[0], pointArray[pointArray.Length - 1]);
                pB.Image = bmp;
            }
        }
    }
}
