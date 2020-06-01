using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GCSem13
{
    public static class Engine
    {
        public static Random rnd = new Random();
        public static Graphics grp;
        public static Bitmap bmp;
        public static int rezx, rezy;
        public static Color backColor = Color.Aquamarine;
        public static PictureBox display;
        public static List<OP> p = new List<OP>();
        public static void initP()
        {
            p.Clear();
            for (int i = 0; i < 6; i++)
                p.Add(new OP(getPoints(i), getRNDColor()));
        }

        public static void drawMAP()
        {
            ClearGraph();
            Zone();

            foreach (OP op in p)
            {
                op.draw(grp);
            }

            RefreshGraph();
        }
        public static void InitGraph(PictureBox T)
        {
            display = T;
            rezx = T.Width;
            rezy = T.Height;

            bmp = new Bitmap(rezx, rezy);
            grp = Graphics.FromImage(bmp);
            ClearGraph();
            RefreshGraph();
        }

        public static void ClearGraph()
        {
            grp.Clear(backColor);
        }

        public static void RefreshGraph()
        {
            display.Image = bmp;
        }

        public static PointF getPoints(int index)
        {
            PointF[] points = new PointF[6] {
                new PointF(30,50),
                new PointF(60,60),
                new PointF(90,50),
                new PointF(90,50),
                new PointF(90,70),
                new PointF(100,80),
            };

            return points[index];
        }

        public static float getRNDAngle()
        {
            return (float)(rnd.NextDouble() * (Math.PI * 2));
        }

        public static Color getRNDColor()
        {
            return Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        }

        public static PointF[] drawPG(PointF center, int n, float l, float fi)
        {
            PointF[] tor = new PointF[n];
            float uc = (2.0f * (float)Math.PI) / (float)n;

            for (int i = 0; i < n; i++)
            {
                tor[i].X = center.X + l * (float)Math.Cos(uc * i + fi);
                tor[i].Y = center.Y + l * (float)Math.Sin(uc * i + fi);
            }
            return tor;
        }

        public static float dEuclid(PointF A, PointF B)
        {
            return (float)Math.Sqrt((A.X - B.X) * (A.X - B.X) + (A.Y - B.Y) * (A.Y - B.Y));
        }

        public static int returnIDX(PointF A)
        {
            float dmin = dEuclid(A, p[0].loc);
            int idx = 0;

            for (int i = 1; i < p.Count; i++)
            {
                float dLocal = dEuclid(A, p[i].loc);
                if (dLocal < dmin)
                {
                    dmin = dLocal;
                    idx = i;
                }
            }

            return idx;
        }

        public static void Zone()
        {
            for (int i = 0; i < rezx; i++)
                for (int j = 0; j < rezy; j++)
                {
                    int t = returnIDX(new PointF(i, j));
                    bmp.SetPixel(i, j, p[t].fill);
                }

            RefreshGraph();
        }
    }
}
