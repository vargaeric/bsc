using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GCSem10
{
    public partial class Form1 : Form
    {
        Graphics grp;
        Bitmap bmp;
        Pen blackPen = new Pen(Color.Black, 2);
        Pen redPen = new Pen(Color.Red, 2);

        int moveOnXAxis;
        int moveOnYAxis;
        private List<CustomPoint> points;
        private List<int> name;
        int x = 0;

        public Color[] colors = { Color.Red, Color.Blue, Color.Green };

        PointF coordinates(PointF p)
            => new PointF(p.X + moveOnXAxis, pictureBox1.Height - moveOnYAxis - p.Y);

        public Form1()
        {
            InitializeComponent();

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);

            grp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            points = new List<CustomPoint>();
            name = new List<int>();

            pictureBox1.Image = bmp;
        }

        void DrawLines()
        {
            for (int i = 0; i < points.Count - 1; i++)
            {
                points[i].neighbours.Add(points[i + 1]);
                grp.DrawLine(blackPen, points[i].position, points[i + 1].position);
            }
            points[points.Count - 1].neighbours.Add(points[0]);

            grp.DrawLine(blackPen, points[points.Count - 1].position, points[0].position);
            pictureBox1.Invalidate();
        }

        private void Triangle()
        {
            Pen bluePen = new Pen(Color.Blue);
            bluePen.DashPattern = new float[] { 5, 3.5f };
            List<CustomPoint> intermediatePoint = new List<CustomPoint>();
            intermediatePoint.Add(points[0]);
            intermediatePoint.Add(points[1]);

            for (int i = 2; i < points.Count; i++)
            {
                intermediatePoint.Add(points[i]);

                float det = Determinant(
                    intermediatePoint[intermediatePoint.Count - 1].position,
                    intermediatePoint[intermediatePoint.Count - 3].position,
                    intermediatePoint[intermediatePoint.Count - 2].position);

                while (det > 0)
                {
                    grp.DrawLine(bluePen, intermediatePoint[intermediatePoint.Count - 3].position, intermediatePoint[intermediatePoint.Count - 1].position);
                    points[intermediatePoint.Count - 3].neighbours.Add(intermediatePoint[intermediatePoint.Count - 1]);
                    pictureBox1.Refresh();

                    intermediatePoint.RemoveAt(intermediatePoint.Count - 2);
                    if (intermediatePoint.Count < 3)
                        break;
                    det = Determinant(intermediatePoint[intermediatePoint.Count - 1].position, intermediatePoint[intermediatePoint.Count - 3].position, intermediatePoint[intermediatePoint.Count - 2].position);
                }

                pictureBox1.Refresh();
            }
            pictureBox1.Image = bmp;
        }

        private int getColorIndex(int colorA, int colorB = -1)
        {
            if (colorB < 0)
                return (colorA + 1) % colors.Length;

            int[] _colors = { 0, 0, 0 };
            _colors[colorA] = 1;
            _colors[colorB] = 1;

            for (int i = 0; i < _colors.Length; i++)
                if (_colors[i] == 0)
                    return i;

            return 0;
        }

        public void drawPoints(CustomPoint p)
        {
            if (p.color != -1)
            {
                grp.DrawEllipse(new Pen(colors[p.color], 10), p.position.X - 2, p.position.Y - 2, 5, 5);
                pictureBox1.Invalidate();
            }
        }

        private float Determinant(PointF p1, PointF p2, PointF p3)
            => (((p1.X * p2.Y) + (p2.X * p3.Y) + (p1.Y * p3.X)) - ((p3.X * p2.Y) + (p3.Y * p1.X) + (p2.X * p1.Y)));

        private void Initialization()
        {
            grp.Clear(Color.White);

            pictureBox1.Image = bmp;
            moveOnXAxis = pictureBox1.Width / 2;
            moveOnYAxis = pictureBox1.Height / 2;

            Point beginningOfXAxis = new Point(0, pictureBox1.Height / 2);
            Point endOfXAxis = new Point(pictureBox1.Width, pictureBox1.Height / 2);

            Point beginningOfYAxis = new Point(pictureBox1.Width / 2, 0);
            Point endOfYAxis = new Point(pictureBox1.Width / 2, pictureBox1.Height);

            grp.DrawLine(Pens.Black, beginningOfXAxis, endOfXAxis);
            grp.DrawLine(Pens.Black, beginningOfYAxis, endOfYAxis);

            points.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < points.Count; i++)
                grp.DrawEllipse(blackPen, points[i].position.X - 2, points[i].position.Y - 2, 5, 5);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                x++;
                name.Add(x);
                points.Add(new CustomPoint(new Point(e.X, e.Y)));
                grp.DrawEllipse(blackPen, e.X - 2, e.Y - 2, 5, 5);
                grp.DrawString(" " + x, new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.DarkBlue), new Point(e.X + 5, e.Y + 5));
                pictureBox1.Invalidate();
            }
        }

        public void Add1()
        {
            points.Add(new CustomPoint(coordinates(new PointF(10, 0))));
            points.Add(new CustomPoint(coordinates(new PointF(20, 20))));
            points.Add(new CustomPoint(coordinates(new PointF(0, 70))));
            points.Add(new CustomPoint(coordinates(new PointF(40, 90))));
            points.Add(new CustomPoint(coordinates(new PointF(70, 70))));
            points.Add(new CustomPoint(coordinates(new PointF(110, 40))));
            points.Add(new CustomPoint(coordinates(new PointF(20, 80))));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Initialization();
            Add1();
            DrawLines();
            Triangle();

            int[] colorsCount = { 0, 0, 0 };

            points[0].color = 0; colorsCount[0]++;
            drawPoints(points[0]);
            points[0].neighbours[0].color = 1; colorsCount[1]++;
            drawPoints(points[0].neighbours[0]);

            for (int i = 1; i < points[0].neighbours.Count; i++)
                if (points[0].neighbours[i].color == -1)
                {
                    int clrIndex = getColorIndex(0, points[0].neighbours[i - 1].color);
                    points[0].neighbours[i].color = clrIndex;
                    colorsCount[clrIndex]++;
                }

            for (int i = 0; i < points.Count; i++)
                if (points[i].color == -1)
                {
                    int clrIndex = getColorIndex(points[i].neighbours[0].color, points[i].neighbours[points[i].neighbours.Count - 1].color);
                    points[i].color = clrIndex;
                    colorsCount[clrIndex]++;
                }

            for (int i = 0; i < points.Count; i++)
                drawPoints(points[i]);

            int minIndex = 0;

            for (int i = 1; i < colorsCount.Length; i++)
                if (colorsCount[i] < colorsCount[minIndex])
                    minIndex = i;

            string[] colorsName = { "red", "blue", "green" };
            label1.Text = "The optimal color is " + colorsName[minIndex] + " with " + colorsCount[minIndex] + " appearances.";
        }

        public void Add2()
        {
            points.Add(new CustomPoint(coordinates(new PointF(40, 40))));
            points.Add(new CustomPoint(coordinates(new PointF(50, 60))));
            points.Add(new CustomPoint(coordinates(new PointF(60, 40))));
            points.Add(new CustomPoint(coordinates(new PointF(70, 40))));
            points.Add(new CustomPoint(coordinates(new PointF(90, 60))));
            points.Add(new CustomPoint(coordinates(new PointF(110, 60))));
            points.Add(new CustomPoint(coordinates(new PointF(110, -60))));
            points.Add(new CustomPoint(coordinates(new PointF(90, -60))));
            points.Add(new CustomPoint(coordinates(new PointF(70, -40))));
            points.Add(new CustomPoint(coordinates(new PointF(60, -40))));
            points.Add(new CustomPoint(coordinates(new PointF(50, -60))));
            points.Add(new CustomPoint(coordinates(new PointF(40, -40))));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Initialization();
            Add2();
            DrawLines();
            Triangle();

            int[] colorsCount = { 0, 0, 0 };

            points[0].color = 0; colorsCount[0]++;
            drawPoints(points[0]);
            points[0].neighbours[0].color = 1; colorsCount[1]++;
            drawPoints(points[0].neighbours[0]);

            for (int i = 1; i < points[0].neighbours.Count; i++)
                if (points[0].neighbours[i].color == -1)
                {
                    int clrIndex = getColorIndex(0, points[0].neighbours[i - 1].color);
                    points[0].neighbours[i].color = clrIndex;
                    colorsCount[clrIndex]++;
                }

            for (int i = 0; i < points.Count; i++)
                if (points[i].color == -1)
                {
                    int clrIndex = getColorIndex(points[i].neighbours[0].color, points[i].neighbours[points[i].neighbours.Count - 1].color);
                    points[i].color = clrIndex;
                    colorsCount[clrIndex]++;
                }

            for (int i = 0; i < points.Count; i++)
                drawPoints(points[i]);

            int minIndex = 0;

            for (int i = 1; i < colorsCount.Length; i++)
                if (colorsCount[i] < colorsCount[minIndex])
                    minIndex = i;
            string[] colorsName = { "red", "blue", "green" };
            label1.Text = "The optimal color is " + colorsName[minIndex] + " with " + colorsCount[minIndex] + " appearances.";
        }
    }
    public class CustomPoint
    {
        public PointF position;
        public int color;
        public List<CustomPoint> neighbours;
        public CustomPoint(PointF pos)
        {
            position = pos;
            color = -1;
            neighbours = new List<CustomPoint>();
        }
    }
}
