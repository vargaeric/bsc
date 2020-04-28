using System;

namespace ComplexNrDatatype
{
    class ComplexNr
    {
        public double realPart { get; }
        public double imaginaryPart { get; }

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

        public static double roundNr(double nr)
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

        public virtual ComplexNr toThePower(int power)
        {
            ComplexNr result = this;

            for (int i = 0; i < power - 1; i++)
                result *= this;

            return result;
        }

        // Get the numbers of the trigonometric form
        public Program.trigonometricForm getNrsOfTrigoForm(ComplexNr complexNr, int power)
        {
            double theta = Math.Atan(this.imaginaryPart / this.realPart);
            double r = Math.Sqrt(Math.Pow(this.realPart, 2) + Math.Pow(this.imaginaryPart, 2));

            return new Program.trigonometricForm
            {
                factor = roundNr(Math.Pow(r, power)),
                realPart = Math.Cos(theta * power),
                imaginaryPart = Math.Sin(theta * power)
            };
        }

        public string trigonometricFormToThePowerOf(int power = 1)
        {
            Program.trigonometricForm nrsOfTrigoForm = getNrsOfTrigoForm(this, power);

            return $"{nrsOfTrigoForm.factor}*" +
                $"{new ComplexNr(nrsOfTrigoForm.realPart, nrsOfTrigoForm.imaginaryPart)}";
        }
    }
}
