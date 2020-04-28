using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

public static class Engine
{
    public static Graphics grp;
    public static Bitmap bmp;
    public static PictureBox display;
    public static int resx, resy;
    public static Color backColor = Color.White;

    public static List<PointF> p = new List<PointF>();
    public static List<PointF> ch = new List<PointF>();
    public static void loadFromFile(string fileName)
    {
        TextReader dataLoad = new StreamReader(fileName);
        string buffer;

        while ((buffer = dataLoad.ReadLine()) != null)
        {
            float x = float.Parse(buffer.Split(' ')[0]);
            float y = float.Parse(buffer.Split(' ')[1]);
            p.Add(new PointF(x, y));
        }
    }

    public static void initGraph(PictureBox T)
    {
        display = T;
        resx = T.Width;
        resy = T.Height;

        bmp = new Bitmap(resx, resy);
        grp = Graphics.FromImage(bmp);

        ClearGraph();
        RefreshGraph();
    }

    public static void drawMap(List <PointF> toDraw, Color color)
    {
        foreach(PointF point in toDraw)
            grp.FillEllipse(new SolidBrush(color), point.X - 3, point.Y - 3, 7, 7);
    }

    public static void ClearGraph()
        => grp.Clear(backColor);

    public static void RefreshGraph()
        => display.Image = bmp;

    public static int Orientare(PointF P, PointF Q, PointF R)
    {
        double temp = (Q.Y - P.Y) * (R.X - Q.X) - (R.Y - Q.Y) * (Q.X - P.X);

        if (temp < 0)
            return -1;
        else if (temp == 0)
            return 0;
        else
            return 1;
    }

    public static void convexHull()
    {
        for (int x = 0; x < (p.Count - 1); x++)
            for (int y = x + 1; y < p.Count; y++)
            {
                int semn = 0;
                for (int k = 0; k < p.Count; k++)
                    if (k != x && k != y)
                    {
                        semn += Orientare(p[x], p[y], p[k]);
                        if (Math.Abs(semn) == (p.Count - 2))
                        {
                            ch.Add(p[x]);
                            ch.Add(p[y]);
                        }
                    }
            }
    }
}