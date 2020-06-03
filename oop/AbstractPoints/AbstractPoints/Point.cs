using System;

namespace AbstractPoints
{
    class Point : AbstractPoint
    {
        double r;
        double A;

        public Point(PointRepresentation represenation, double rValue, double AValues)
        {
            if (represenation != PointRepresentation.Rectangular)
            {
                r = rValue;
                A = AValues;
            }
            else
            {
                r = Math.Sqrt(Math.Pow(rValue, 2) + Math.Pow(AValues, 2));
                A = Math.Atan2(AValues, rValue);
            }
        }

        public override double Radius
        {
            get => r;
            set => r = value;
        }

        public override double Angle
        {
            get => A;
            set => A = value;
        }

        public override double Abscissa
        {
            get => GetAbscissa(r, A);
        }

        public override double Ordinate
        {
            get => GetOrdinate(r, A);
        }
    }
}
