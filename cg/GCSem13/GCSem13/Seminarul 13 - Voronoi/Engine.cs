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
    class Engine
    {
         
        public static Random rnd = new Random();
        public static Graphics grp;
        public static Bitmap bmp;
        public static int rezx, rezy;
        public static Color backColor = Color.White;
        public static PictureBox display;
        public static List<OP> p = new List<OP>();
       
        
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

        public static PointF getRNDPoint()
        {
            return new PointF(rnd.Next(rezx), rnd.Next(rezy));
        }

        public static float getRNDAngle()
        {
            return (float)(rnd.NextDouble()*(Math.PI * 2));
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
                tor[i].X = center.X + l*(float)Math.Cos(uc * i + fi);
                tor[i].Y = center.Y + l*(float)Math.Sin(uc * i + fi);
            }

            return tor;
        }
        public static void initPRandom(int n)
        {
            p.Clear();
            for (int i = 0; i < n; i++)
            {
                p.Add(new OP(getRNDPoint(), getRNDColor()));
            }
            RefreshGraph();
        }
        public static void initP()
        {
            p.Clear();
            p.Add(new OP(new PointF(30, 50), getRNDColor()));
            p.Add(new OP(new PointF(60, 60), getRNDColor()));
            p.Add(new OP(new PointF(90, 50), getRNDColor()));
            p.Add(new OP(new PointF(90, 50), getRNDColor()));
            p.Add(new OP(new PointF(90, 70), getRNDColor()));
            p.Add(new OP(new PointF(100, 80), getRNDColor()));
            RefreshGraph();
        }
        public static void initPMax()
        {
            p.Clear();
            p.Add(new OP(new PointF(30 * 3, 50 * 3), getRNDColor()));
            p.Add(new OP(new PointF(60  *3, 60*  3), getRNDColor()));
            p.Add(new OP(new PointF(90 * 3, 50 * 3), getRNDColor()));
            p.Add(new OP(new PointF(90 * 3, 50  *3), getRNDColor()));
            p.Add(new OP(new PointF(90 * 3, 70 * 3), getRNDColor()));
            p.Add(new OP(new PointF(100 * 3, 80 * 3), getRNDColor()));
            RefreshGraph();
        }
        public static void Drawmap()
        {
            ClearGraph();
            Zone();
            foreach (OP op in p)
            {
                op.draw(grp);
            }
            RefreshGraph();

        }
        public static float dEuclid(PointF a, PointF b)
        {
            return (float)Math.Sqrt((a.X - b.X)*(a.X - b.X) + (a.Y - b.Y)*(a.Y - b.Y));
        }


        public static float dManhattan(PointF a, PointF b)
        {
            return (float)(Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y));
        }
        public static int returnIDX(PointF a)
        {
            float dmin = dEuclid(a, p[0].location);
            int idx = 0;
            for (int i = 1; i < p.Count; i++)
            {
                float dlocal = dEuclid(a, p[i].location);
                if (dlocal < dmin)
                {
                    dmin = dlocal;
                    idx = i;
                }

            }
            return idx;
        }
        public static void Zone()
        {
            for (int i = 0; i < rezx; i++)
            {
                for (int j = 0; j < rezy; j++)
                {
                    int t = returnIDX(new PointF(i, j));
                    bmp.SetPixel(i, j, p[t].fill);
                }
                RefreshGraph();
            }
        }


    }
}


