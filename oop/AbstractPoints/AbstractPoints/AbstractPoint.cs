using System;

namespace AbstractPoints
{
    public abstract class AbstractPoint
    {
        public enum PointRepresentation
        {
            Polar,
            Rectangular
        }
        public abstract double Radius { get; set; }
        public abstract double Angle { get; set; }
        public abstract double Abscissa { get; }
        public abstract double Ordinate { get; }

        public void Move(double x, double y)
        {
            double abscissa = GetAbscissa(Radius, Angle);
            double ordinate = GetOrdinate(Radius, Angle);

            abscissa += x;
            ordinate += y;

            Radius = getRadius(abscissa, ordinate);
            Angle = getAngle(abscissa, ordinate);
        }

        public void Rotate(double angle)
            => Angle += angle;

        private double roundNr(double nr)
            => Math.Round(nr, 2, MidpointRounding.AwayFromZero);

        public override string ToString()
            => $"({roundNr(Abscissa)}, {roundNr(Ordinate)})" +
            $":[{roundNr(Radius)}, {roundNr(Angle)}]";

        protected static double getRadius(double x, double y)
            => Math.Sqrt(x * x + y * y);

        protected static double getAngle(double x, double y)
            => Math.Atan2(y, x);

        protected static double GetAbscissa(double rad, double ang)
            => rad * Math.Cos(ang);
        protected static double GetOrdinate(double rad, double ang)
            => rad * Math.Sin(ang);
    }
}
