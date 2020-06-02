using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCSem13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Partea de initializari
        Graphics grp;
        Bitmap bmp;
        List<Point> points = new List<Point>();
        Color[] colors = new Color[] { Color.Yellow, Color.Green, Color.YellowGreen, Color.HotPink, Color.Khaki, Color.BlueViolet, Color.OrangeRed, Color.MediumOrchid, Color.MediumSpringGreen, Color.RoyalBlue };
        string letters = "ABCDEFGHIJ";
        int pointCount = 10;
        Random rnd = new Random();
        Point tobeChecked = new Point();

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            points = new List<Point>();
            label1.Text = string.Empty;

            Engine.InitGraph(pictureBox1);
            Engine.RefreshGraph();
        }

        private void DrawPoints()
        {
            for (int i = 0; i < points.Count; i++)
            {
                grp.FillEllipse(new SolidBrush(Color.Black), points[i].X, points[i].Y, 3, 3);
                grp.DrawString(letters[i].ToString(), new Font("Verdana", 8, FontStyle.Regular), new SolidBrush(Color.Black), points[i].X, points[i].Y);
            }
        }

        private Point getRandomPoint()
        {
            Point toReturn = new Point();

            do
            {
                toReturn.X = rnd.Next() % bmp.Width;
                toReturn.Y = rnd.Next() % bmp.Height;
            } while (points.Contains(toReturn));
            return toReturn;
        }
        public int SqDistance(Point A, Point B)
        {
            return (B.Y - A.Y) * (B.Y - A.Y) + (B.X - A.X) * (B.X - A.X);
        }

        private void loadPoints()
        {
            label1.Text += "10 random points:\n";

            for (int i = 0; i < pointCount; i++)
            {
                Point added = getRandomPoint();
                points.Add(added);
                label1.Text += $"{letters[i].ToString()}=({added.X},{added.Y})\n";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            points.Clear();
            // grp.Clear(Color.White);
            label1.Text = "";
            loadPoints();

          

            for (int i = 0; i < pictureBox1.Width; i++)
                for (int j = 0; j < pictureBox1.Height; j++)
                {
                    Point toCheck = new Point(i, j);
                    if (!points.Contains(toCheck))
                    {
                        int minindex = 0, mindistance = SqDistance(toCheck, points[0]);
                       // bool granita = false;
                        for (int z = 1; z < points.Count; z++)
                        {
                            int sqdist = SqDistance(toCheck, points[z]);
                            if (sqdist < mindistance)
                            {
                                minindex = z;
                                mindistance = sqdist;
                            }
                           
                        }
                        
                        grp.FillEllipse(new SolidBrush(colors[minindex]), toCheck.X, toCheck.Y, 3, 3);
                    }

                }

            



            //Afisarea punctului scris de noi
            try
            {
                tobeChecked.X = int.Parse(textBox1.Text);
                tobeChecked.Y = int.Parse(textBox2.Text);
                grp.FillEllipse(new SolidBrush(Color.Black), tobeChecked.X, tobeChecked.Y, 10, 10);
            }
            catch
            {

            }

            pictureBox1.Image = bmp;
            DrawPoints();
            pictureBox1.Image = bmp;
        }

     
        

        private void button3_Click(object sender, EventArgs e) // Exercitiul 1- diagrama voronoi cu cele 7 puncte date
        {
            Engine.initPMax();
            Engine.Drawmap();
            Engine.grp.DrawString("A", new Font("Tahoma", 8, FontStyle.Regular), new SolidBrush(Color.Black), 30 * 3 + 2, 50 * 3 + 8);
            Engine.grp.DrawString("B", new Font("Tahoma", 8, FontStyle.Regular), new SolidBrush(Color.Black), 60 * 3 + 2, 60 * 3 + 8);
            Engine.grp.DrawString("C", new Font("Tahoma", 8, FontStyle.Regular), new SolidBrush(Color.Black), 90 * 3 - 19, 50 * 3 - 15);
            Engine.grp.DrawString("D", new Font("Tahoma", 8, FontStyle.Regular), new SolidBrush(Color.Black), 90 * 3 + 10, 50 * 3 - 15);
            Engine.grp.DrawString("E", new Font("Tahoma", 8, FontStyle.Regular), new SolidBrush(Color.Black), 90 * 3 - 15, 70 * 3 - 8);
            Engine.grp.DrawString("F", new Font("Tahoma", 8, FontStyle.Regular), new SolidBrush(Color.Black), 100 * 3 + 5, 80 * 3 + 5);

        }

       
    }
}
