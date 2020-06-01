using System.Drawing;

namespace GCSem13
{
    public class OP
    {
        public PointF loc;
        public Color fill;

        public OP(PointF loc, Color fill)
        {
            this.loc = loc;
            this.fill = fill;
        }

        public void draw(Graphics grp)
        {
            grp.FillEllipse(new SolidBrush(fill), loc.X - 5, loc.Y - 5, 11, 11);
            grp.DrawEllipse(new Pen(Color.Black), loc.X - 5, loc.Y - 5, 11, 11);
        }
    }
}
