using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCSem6
{
    public partial class Form1 : Form
    {
        Graphics grp;
        Bitmap bmp;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            grp.Clear(Color.White);

            PointF[] positions = new PointF[3];
            Random r = new Random();

            for (int i = 0; i < 8; i++)
            {
                positions[0].X = r.Next(500);
                positions[0].Y = r.Next(500);
                positions[1].X = r.Next(500);
                positions[1].Y = r.Next(500);
                positions[2].X = r.Next(500);
                positions[2].Y = r.Next(500);

                Color RandomColor = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
                SolidBrush sb = new SolidBrush(RandomColor);
                grp.FillPolygon(sb, positions);

                pictureBox1.Image = bmp;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            generateRandomSquaresOrCircles();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            generateRandomSquaresOrCircles(false);
        }

        private void generateRandomSquaresOrCircles(bool generateSquares = true)
        {
            grp.Clear(Color.White);

            PointF position = new PointF();
            Random r = new Random();
            int size = 0;

            for (int i = 0; i < 8; i++)
            {
                position.X = r.Next(400);
                position.Y = r.Next(400);

                size = r.Next(50, 100);

                Color RandomColor = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
                SolidBrush sb = new SolidBrush(RandomColor);

                switch (generateSquares)
                {
                    case false:
                        grp.FillEllipse(sb, position.X, position.Y, size, size);
                        break;
                    default:
                        grp.FillRectangle(sb, position.X, position.Y, size, size);
                        break;
                }

                pictureBox1.Image = bmp;
            }
        }
    }
}
