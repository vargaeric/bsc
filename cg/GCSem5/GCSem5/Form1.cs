using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCSem5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap bmp1;
        Graphics grp1;

        int Ax = -1, Ay = -1, Bx = -1, By = -1, Cx = -1, Cy = -1;

        PointF A, B, C;

        int numarulProblemei = 1;

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp1 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp1 = Graphics.FromImage(bmp1);

            Ax = Convert.ToInt32(numericUpDown1.Value);
            Ay = Convert.ToInt32(numericUpDown2.Value);
            Bx = Convert.ToInt32(numericUpDown3.Value);
            By = Convert.ToInt32(numericUpDown4.Value);
            Cx = Convert.ToInt32(numericUpDown5.Value);
            Cy = Convert.ToInt32(numericUpDown6.Value);

            rezolvaProblemaAleasa();
        }

        private void initializare()
        {
            grp1.Clear(Color.White);

            A = new PointF(Ax, Ay);
            B = new PointF(Bx, By);
            C = new PointF(Cx, Cy);

            grp1.DrawLine(Pens.Black, A, B);
            grp1.DrawLine(Pens.Black, A, C);
            grp1.DrawLine(Pens.Black, C, B);

            SolidBrush redBrush = new SolidBrush(Color.Red);
            SolidBrush greenBrush = new SolidBrush(Color.Green);
            SolidBrush blueBrush = new SolidBrush(Color.Blue);

            grp1.FillEllipse(redBrush, Ax-4, Ay-4, 8, 8);
            grp1.FillEllipse(greenBrush, Bx-4, By-4, 8, 8);
            grp1.FillEllipse(blueBrush, Cx-4, Cy-4, 8, 8);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Ax = Convert.ToInt32(numericUpDown1.Value);
            rezolvaProblemaAleasa();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Ay = Convert.ToInt32(numericUpDown2.Value);
            rezolvaProblemaAleasa();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            Bx = Convert.ToInt32(numericUpDown3.Value);
            rezolvaProblemaAleasa();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            By = Convert.ToInt32(numericUpDown4.Value);
            rezolvaProblemaAleasa();
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            Cx = Convert.ToInt32(numericUpDown5.Value);
            rezolvaProblemaAleasa();
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            Cy = Convert.ToInt32(numericUpDown6.Value);
            rezolvaProblemaAleasa();
        }

        private void rezolvaProblema1()
        {
            initializare();

            PointF mediaA = new PointF((Bx + Cx) / 2, (By + Cy) / 2);
            PointF mediaB = new PointF((Ax + Cx) / 2, (Ay + Cy) / 2);
            PointF mediaC = new PointF((Bx + Ax) / 2, (By + Ay) / 2);

            grp1.DrawLine(Pens.Red, A, mediaA);
            grp1.DrawLine(Pens.Green, B, mediaB);
            grp1.DrawLine(Pens.Blue, C, mediaC);

            pictureBox1.Image = bmp1;
        }

        private void rezolvaProblema2()
        {
            initializare();

            float biAx, biAy, biBx, biBy, biCx, biCy;
            float dAC, dAB, dCB;

            dAC = Convert.ToSingle(Math.Sqrt((Ax - Cx) * (Ax - Cx) + (Ay - Cy) * (Ay - Cy)));
            dAB = Convert.ToSingle(Math.Sqrt((Ax - Bx) * (Ax - Bx) + (Ay - By) * (Ay - By)));
            dCB = Convert.ToSingle(Math.Sqrt((Cx - Bx) * (Cx - Bx) + (Cy - By) * (Cy - By)));

            biAx = (dAC * Bx + dAB * Cx) / (dAB + dAC);
            biAy = (dAC * By + dAB * Cy) / (dAB + dAC);
            biBx = (dAB * Cx + dCB * Ax) / (dAB + dCB);
            biBy = (dAB * Cy + dCB * Ay) / (dAB + dCB);
            biCx = (dAC * Bx + dCB * Ax) / (dCB + dAC);
            biCy = (dAC * By + dCB * Ay) / (dCB + dAC);

            grp1.DrawLine(Pens.Red, Ax, Ay, biAx, biAy);
            grp1.DrawLine(Pens.Green, Bx, By, biBx, biBy);
            grp1.DrawLine(Pens.Blue, Cx, Cy, biCx, biCy);

            pictureBox1.Image = bmp1;
        }

        private void rezolvaProblema3()
        {
            initializare();

            double inaltimeAK = ((Ax - Bx) * (Cx - Bx) + (Ay - By) * (Cy - By)) / (Math.Pow(Cx - Bx, 2) + Math.Pow(Cy - By, 2));
            double inaltimeAx = Bx + inaltimeAK * (Cx - Bx);
            double inaltimeAy = By + inaltimeAK * (Cy - By);

            double inaltimeBK = ((Bx - Ax) * (Cx - Ax) + (By - Ay) * (Cy - Ay)) / (Math.Pow(Cx - Ax, 2) + Math.Pow(Cy - Ay, 2));
            double inaltimeBx = Ax + inaltimeBK * (Cx - Ax);
            double inaltimeBy = Ay + inaltimeBK * (Cy - Ay);

            double inaltimeCK = ((Cx - Ax) * (Bx - Ax) + (Cy - Ay) * (By - Ay)) / (Math.Pow(Bx - Ax, 2) + Math.Pow(By - Ay, 2));
            double inaltimeCx = Ax + inaltimeCK * (Bx - Ax);
            double inaltimeCy = Ay + inaltimeCK * (By - Ay);

            grp1.DrawLine(Pens.Red, Ax, Ay, Convert.ToSingle(inaltimeAx), Convert.ToSingle(inaltimeAy));
            grp1.DrawLine(Pens.Green, Bx, By, Convert.ToSingle(inaltimeBx), Convert.ToSingle(inaltimeBy));
            grp1.DrawLine(Pens.Blue, Cx, Cy, Convert.ToSingle(inaltimeCx), Convert.ToSingle(inaltimeCy));

            pictureBox1.Image = bmp1;
        }

        private void rezolvaProblema4()
        {
            initializare();

            // mijlocul cercului (x,y)
            double d = 2 * (Ax * (By - Cy) + Bx * (Cy - Ay) + Cx * (Ay - By));

            double s1 = (Math.Pow(Ax, 2) + Math.Pow(Ay, 2)) * (By - Cy);
            double s2 = (Math.Pow(Bx, 2) + Math.Pow(By, 2)) * (Cy - Ay);
            double s3 = (Math.Pow(Cx, 2) + Math.Pow(Cy, 2)) * (Ay - By);
            double Ux = 1 / d * (s1 + s2 + s3);

            double s4 = (Math.Pow(Ax, 2) + Math.Pow(Ay, 2)) * (Cx - Bx);
            double s5 = (Math.Pow(Bx, 2) + Math.Pow(By, 2)) * (Ax - Cx);
            double s6 = (Math.Pow(Cx, 2) + Math.Pow(Cy, 2)) * (Bx - Ax);
            double Uy = 1 / d * (s4 + s5 + s6);

            // diametrul cercului
            double dAC = Convert.ToSingle(Math.Sqrt((Ax - Cx) * (Ax - Cx) + (Ay - Cy) * (Ay - Cy)));
            double dAB = Convert.ToSingle(Math.Sqrt((Ax - Bx) * (Ax - Bx) + (Ay - By) * (Ay - By)));
            double dCB = Convert.ToSingle(Math.Sqrt((Cx - Bx) * (Cx - Bx) + (Cy - By) * (Cy - By)));

            double dia = 2 * dAC * dAB * dCB / Math.Sqrt((dAC + dAB + dCB) * (dAC - dAB + dCB) * (dAB - dCB + dAC) * (dCB - dAC + dAB));

            // pozitia mediatoarelor pe linie
            PointF mediaA = new PointF((Bx + Cx) / 2, (By + Cy) / 2);
            PointF mediaB = new PointF((Ax + Cx) / 2, (Ay + Cy) / 2);
            PointF mediaC = new PointF((Bx + Ax) / 2, (By + Ay) / 2);
            PointF PunctO = new PointF(Convert.ToSingle(Ux), Convert.ToSingle(Uy));

            // desenare
            grp1.DrawLine(Pens.Red, mediaA, PunctO);
            grp1.DrawLine(Pens.Green, mediaB, PunctO);
            grp1.DrawLine(Pens.Blue, mediaC, PunctO);

            SolidBrush darkCyanBrush = new SolidBrush(Color.DarkCyan);
            grp1.DrawEllipse(Pens.DarkCyan, Convert.ToSingle(Ux-dia/2), Convert.ToSingle(Uy-dia/2), Convert.ToSingle(dia), Convert.ToSingle(dia));
            grp1.FillEllipse(darkCyanBrush, Convert.ToSingle(Ux-4), Convert.ToSingle(Uy-4), 8, 8);

            pictureBox1.Image = bmp1;
        }

        private void rezolvaProblemaAleasa()
        {
            switch (numarulProblemei)
            {
                case 1:
                    rezolvaProblema1();
                    break;
                case 2:
                    rezolvaProblema2();
                    break;
                case 3:
                    rezolvaProblema3();
                    break;
                case 4:
                    rezolvaProblema4();
                    break;
                default:
                    rezolvaProblema1();
                    break;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            numarulProblemei = 1;

            rezolvaProblemaAleasa();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            numarulProblemei = 2;

            rezolvaProblemaAleasa();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            numarulProblemei = 3;

            rezolvaProblemaAleasa();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            numarulProblemei = 4;

            rezolvaProblemaAleasa();
        }
    }
}