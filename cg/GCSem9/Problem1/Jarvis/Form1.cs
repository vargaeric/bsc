using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jarvis
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			Engine.resx = pictureBox1.Width;
			Engine.resy = pictureBox1.Height;
			Engine.InitGraph();
			Engine.g.Clear(Color.White);
			Engine.initPoint();
			Engine.draw();
			pictureBox1.Image = Engine.b;
		}

		private void BtnStart_Click(object sender, EventArgs e)
		{
			Jarvis.ConvexHull(Jarvis.Points);
			List<Point> JRpoints = new List<Point>();

			foreach (Point point in Jarvis.ConvexHull(Jarvis.Points))
			{
				Engine.g.FillEllipse(Brushes.Red, point.X - 3, point.Y - 3, 6, 6);
				JRpoints.Add(point);
			}

			for (int i = 0; i < JRpoints.Count; i++)
			{
				if (JRpoints[JRpoints.Count - 1] == JRpoints[i])
				{
					Engine.g.DrawLine(Pens.Black, JRpoints[JRpoints.Count - 1], JRpoints[0]);
				}
				else
				{
					Engine.g.DrawLine(Pens.Black, JRpoints[i], JRpoints[i + 1]);
				}
			}

			pictureBox1.Image = Engine.b;
		}

		private void BtnAddPoints_Click(object sender, EventArgs e)
		{
            Jarvis.Points.Clear();
            Engine.g.Clear(Color.White);
            pictureBox1.Image = Engine.b;
            Engine.initPoint();
			Engine.draw();
			pictureBox1.Image = Engine.b;
		}
    }
}
