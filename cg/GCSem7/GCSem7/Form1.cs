using System;
using System.Drawing;
using System.Windows.Forms;

namespace GCSem7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap bmp;
        Graphics grp;

        int mutarePeAxaX;
        int mutarePeAxaY;

        Label[] etichete = new Label[12];
        int numarulEtichetelor = 0;

        struct EcuatiaDreptei
        {
            public float a;
            public float b;
            public float c;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mutarePeAxaX = pictureBox1.Width / 2;
            mutarePeAxaY = pictureBox1.Height / 2;

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);

            initializare();
        }

        PointF calculareCoordonate(PointF punct)
            => new PointF(punct.X + mutarePeAxaX, pictureBox1.Height - mutarePeAxaY - punct.Y);

        void initializare()
        {
            stergeEtichetele();

            grp.Clear(Color.White);

            Point inceputAxaX = new Point(0, pictureBox1.Height / 2);
            Point sfarsitAxaX = new Point(pictureBox1.Width, pictureBox1.Height / 2);

            Point inceputAxaY = new Point(pictureBox1.Width / 2, 0);
            Point sfarsitAxaY = new Point(pictureBox1.Width / 2, pictureBox1.Height);

            grp.DrawLine(Pens.Black, inceputAxaX, sfarsitAxaX);
            grp.DrawLine(Pens.Black, inceputAxaY, sfarsitAxaY);

            pictureBox1.Image = bmp;
        }

        //calcularea a, b si c din forma generala a ecuatiei unei drepte
        EcuatiaDreptei calcABC(Point punctulA, Point punctulB)
        {
            EcuatiaDreptei ecuatiaDreptei;

            ecuatiaDreptei.a = punctulA.Y - punctulB.Y;
            ecuatiaDreptei.b = punctulB.X - punctulA.X;
            ecuatiaDreptei.c = punctulB.X * punctulA.Y - punctulB.Y * punctulA.X;

            return ecuatiaDreptei;
        }

        PointF calcIntersectie(Point A, Point B, Point C, Point D)
        {
            EcuatiaDreptei AB = calcABC(A, B);
            EcuatiaDreptei CD = calcABC(C, D);

            // Punctul de intersectie
            PointF punctDeInter = new PointF();

            float x = (CD.c * AB.b - AB.c * CD.b) / (AB.a * CD.b - CD.a * AB.b);
            float y = (-AB.c - AB.a * x) / AB.b;
            punctDeInter = calculareCoordonate(new PointF(x, y));

            // Corectiune pentru punctul de intersectie
            return new PointF(
                mutarePeAxaX + (mutarePeAxaX - punctDeInter.X),
                mutarePeAxaY + (mutarePeAxaY - punctDeInter.Y)
            );
        }

        void deseneazaLinie(Point punctulA, Point punctulB, string color = "black")
        {
            Pen pen = new Pen(Color.Black);

            switch(color)
            {
                case "green":
                    pen.Color = Color.Green;
                    break;
                case "blue":
                    pen.Color = Color.Blue;
                    break;
                default:
                    break;
            }

            grp.DrawLine(pen, calculareCoordonate(punctulA), calculareCoordonate(punctulB));

            pictureBox1.Image = bmp;
        }

        void deseneazaPunct(PointF punctDeInter)
        {
            SolidBrush redBrush = new SolidBrush(Color.Red);
            grp.FillEllipse(redBrush, punctDeInter.X - 3, punctDeInter.Y - 3, 5, 5);

            pictureBox1.Image = bmp;
        }

        void creazaEticheta(string text, Point pozitia, int mutaX = 0, int mutaY = 0)
        {
            int nre = numarulEtichetelor;

            etichete[nre] = new Label();
            etichete[nre].Text = text;
            etichete[nre].Height = 10;
            etichete[nre].Width = 10;
            etichete[nre].Font = new Font("Arial", 6);

            PointF pozitieMutata = new PointF(pozitia.X + mutaX, pozitia.Y + mutaY);

            etichete[nre].Location = Point.Round(calculareCoordonate(pozitieMutata));

            Controls.Add(etichete[nre]);

            etichete[nre].BringToFront();

            numarulEtichetelor++;
        }

        void stergeEtichetele()
        {
            for(int i = 0; i < numarulEtichetelor; i++)
                Controls.Remove(etichete[i]);

            numarulEtichetelor = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            initializare();

            Point A = new Point(-150, 40);
            Point B = new Point(150, -40);
            Point C = new Point(30, 10);
            Point D = new Point(100, -120);

            PointF punctDeInter = calcIntersectie(A, B, C, D);

            deseneazaLinie(A, B);
            deseneazaLinie(C, D);

            creazaEticheta("A", A, 0, 10);
            creazaEticheta("B", B, -10, -3);
            creazaEticheta("C", C, 5, 5);
            creazaEticheta("D", D, 5, 5);

            deseneazaPunct(punctDeInter);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            initializare();

            Point A = new Point(-150, -10);
            Point B = new Point(40, 150);
            Point C = new Point(-150, 100);
            Point D = new Point(150, -120);

            PointF punctDeInter = calcIntersectie(A, B, C, D);

            deseneazaLinie(A, B);
            deseneazaLinie(C, D);

            creazaEticheta("A", A, 0, -5);
            creazaEticheta("B", B, 5);
            creazaEticheta("C", C, 0, 10);
            creazaEticheta("D", D, -10, -5);

            deseneazaPunct(punctDeInter);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            initializare();

            Point A = new Point(-15, -10);
            Point B = new Point(40, 100);
            Point C = new Point(-10, 100);
            Point D = new Point(20, 20);

            PointF punctDeInter = calcIntersectie(A, B, C, D);

            deseneazaLinie(A, B);
            deseneazaLinie(C, D);

            creazaEticheta("A", A, -13);
            creazaEticheta("B", B, 5, 5);
            creazaEticheta("C", C, -13, 5);
            creazaEticheta("D", D, 5, 3);

            deseneazaPunct(punctDeInter);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            initializare();

            Point A = new Point(10, 10);
            Point B = new Point(50, 30);
            Point C = new Point(-20, -30);
            Point D = new Point(30, -10);
            Point E = new Point(30, 40);
            Point F = new Point(-20, -70);
            Point G = new Point(-40, -20);
            Point H = new Point(30, 10);
            Point I = new Point(-20, 40);
            Point K = new Point(30, -40);
            Point L = new Point(-30, 30);
            Point M = new Point(10, 30);

            PointF ABxEF = calcIntersectie(A, B, E, F);
            PointF CDxEF = calcIntersectie(C, D, E, F);
            PointF GHxEF = calcIntersectie(G, H, E, F);
            PointF CDxIK = calcIntersectie(C, D, I, K);
            PointF GHxIK = calcIntersectie(G, H, I, K);

            deseneazaLinie(A, B, "green");
            deseneazaLinie(G, H, "green");
            deseneazaLinie(C, D, "green");
            deseneazaLinie(E, F, "blue");
            deseneazaLinie(I, K, "blue");
            deseneazaLinie(L, M, "blue");

            creazaEticheta("A", A, -8, 11);
            creazaEticheta("B", B, 5, 5);
            creazaEticheta("C", C, -13, 5);
            creazaEticheta("D", D, 5, 3);
            creazaEticheta("E", E, 0, 10);
            creazaEticheta("F", F, 5, 5);
            creazaEticheta("G", G, -13, 5);
            creazaEticheta("H", H, 5, 3);
            creazaEticheta("I", I, -10, 13);
            creazaEticheta("K", K, 5, 5);
            creazaEticheta("L", L, -13, 5);
            creazaEticheta("M", M, 3, 5);

            deseneazaPunct(ABxEF);
            deseneazaPunct(CDxEF);
            deseneazaPunct(GHxEF);
            deseneazaPunct(CDxIK);
            deseneazaPunct(GHxIK);
        }
    }
}
