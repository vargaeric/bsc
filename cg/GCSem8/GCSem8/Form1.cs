using System;
using System.Drawing;
using System.Windows.Forms;

namespace GCSem8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.initGraph(pictureBox1);
            Engine.loadFromFile(@"..\..\coordinates.txt");
            Engine.drawMap(Engine.p, Color.Red);

            Engine.convexHull();
            Engine.drawMap(Engine.ch, Color.Black);
            Engine.RefreshGraph();
        }

        public int i = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Engine.grp.DrawLine(Pens.Black, Engine.ch[(i) % Engine.ch.Count], Engine.ch[(i + 1) % Engine.ch.Count]);
            i++;
            i = i % Engine.ch.Count;
            Engine.RefreshGraph();
        }
    }
}
