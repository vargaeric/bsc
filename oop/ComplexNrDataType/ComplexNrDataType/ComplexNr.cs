using System;

namespace ComplexNrDatatype
{
    class ComplexNr
    {
        double realPart;
        double imaginaryPart;

        void validateInput(string input)
        {
            bool isNumeric = double.TryParse(input, out _);

            if (!isNumeric)
                throw new ArgumentException($"The input string '{input}' is not a valid number.");
        }

        public ComplexNr()
        {
            string input;

            Console.Write("The real part of the complex number = ");
            input = Console.ReadLine();
            validateInput(input);
            realPart = Convert.ToDouble(input);

            Console.Write("The imaginary part of the complex number = ");
            input = Console.ReadLine();
            validateInput(input);
            imaginaryPart = Convert.ToDouble(input);
        }

        public ComplexNr(double realPart, double imaginaryPart = 0)
        {
            this.realPart = realPart;
            this.imaginaryPart = imaginaryPart;
        }

        double roundNr(double nr)
            => Math.Round(nr, 3, MidpointRounding.AwayFromZero);

        public override string ToString() =>
            imaginaryPart < 0
                ? $"({roundNr(realPart)}{roundNr(imaginaryPart)}i)"
                : $"({roundNr(realPart)}+{roundNr(imaginaryPart)}i)";

        public static ComplexNr operator +(ComplexNr a, ComplexNr b)
            => new ComplexNr(a.realPart + b.realPart, a.imaginaryPart + b.imaginaryPart);

        public static ComplexNr operator -(ComplexNr a, ComplexNr b)
            => new ComplexNr(a.realPart - b.realPart, a.imaginaryPart - b.imaginaryPart);

        public static ComplexNr operator *(ComplexNr a, ComplexNr b)
            => new ComplexNr(
                a.realPart * b.realPart - a.imaginaryPart * b.imaginaryPart,
                a.realPart * b.imaginaryPart + a.imaginaryPart * b.realPart
            );

        public static ComplexNr operator ^(ComplexNr a, int power)
        {
            ComplexNr result = a;

            for (int i = 0; i < power - 1; i++)
            {
                result *= a;
            }

            return result;
        }

        public string trigonometricFormToThePowerOf(int power)
        {
            double theta = Math.Atan(this.imaginaryPart / this.realPart);
            double r = Math.Sqrt(Math.Pow(this.realPart, 2) + Math.Pow(this.imaginaryPart, 2));

            double rToThePowerOfN = roundNr(Math.Pow(r, power));
            double realPart = Math.Cos(theta * power);
            double imaginaryPart = Math.Sin(theta * power);

            return $"{rToThePowerOfN}*{new ComplexNr(realPart, imaginaryPart)}";
        }
    }
}
