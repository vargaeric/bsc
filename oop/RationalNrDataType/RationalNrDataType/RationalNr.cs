using System;

namespace RationalNrDatatype
{
    internal class RationalNr
    {
        int numerator;
        int denominator;

        void validateInput(string input)
        {
            bool isInteger = int.TryParse(input, out _);

            if (!isInteger)
                throw new ArgumentException($"The input string '{input}' is not a valid integer value.");
        }

        void validateDenominator()
        {
            if (denominator == 0)
                throw new ArgumentException("Denominator cannot be zero.");
        }

        public RationalNr()
        {
            string input;

            Console.Write("The numerator of the fraction = ");
            input = Console.ReadLine();
            validateInput(input);
            numerator = Convert.ToInt32(input);

            Console.Write("The denominator of the fraction = ");
            input = Console.ReadLine();
            validateInput(input);
            denominator = Convert.ToInt32(input);

            validateDenominator();
        }

        public RationalNr(int numerator, int denominator = 1)
        {
            this.numerator = numerator;
            this.denominator = denominator;

            validateDenominator();
        }

        public override string ToString()
            => denominator == 1
                ? Convert.ToString(numerator)
                : $"({numerator}/{denominator})";

        // Get greatest common divisor
        static int getGCD(int a, int b)
            => b == 0
                ? a
                : getGCD(b, a % b);

        // Get lowest common denominator
        static int getLCD(int denominator1, int denominator2)
            => (denominator1 * denominator2) / getGCD(denominator1, denominator2);

        public RationalNr simplifiedForm()
        {
            int gcd = getGCD(numerator, denominator);

            return new RationalNr(numerator / gcd, denominator / gcd);
        }

        static RationalNr addingOrSubtractingTwoFractions(RationalNr a, RationalNr b, char operation = '+')
        {
            int lcd = getLCD(a.denominator, b.denominator);

            int multiplierForA = lcd / a.denominator;
            int multiplierForB = lcd / b.denominator;

            RationalNr c = new RationalNr(a.numerator * multiplierForA, a.denominator * multiplierForA);
            RationalNr d = new RationalNr(b.numerator * multiplierForB, b.denominator * multiplierForB);

            int numerator = operation == '+'
                ? c.numerator + d.numerator
                : c.numerator - d.numerator;

            return new RationalNr(numerator, c.denominator).simplifiedForm();
        }

        public static RationalNr operator +(RationalNr a, RationalNr b)
            => addingOrSubtractingTwoFractions(a, b);

        public static RationalNr operator -(RationalNr a, RationalNr b)
            => addingOrSubtractingTwoFractions(a, b, '-');

        public static RationalNr operator *(RationalNr a, RationalNr b)
            => new RationalNr(a.numerator * b.numerator, a.denominator * b.denominator).simplifiedForm();

        public RationalNr getReciprocal()
            => new RationalNr(denominator, numerator);

        public static RationalNr operator /(RationalNr a, RationalNr b)
            => (a * b.getReciprocal()).simplifiedForm();

        public static RationalNr operator ^(RationalNr a, int b)
        {
            RationalNr result = a;

            for (int i = 0; i < b - 1; i++)
            {
                result *= a;
            }

            return result;
        }

        static bool compareTwoFractions(RationalNr a, RationalNr b, string relationalOperator)
        {
            int rightSide = a.numerator * b.denominator;
            int leftSide = a.denominator * b.numerator;

            return relationalOperator switch
            {
                "<" => rightSide < leftSide,
                ">" => rightSide > leftSide,
                "<=" => rightSide <= leftSide,
                ">=" => rightSide >= leftSide,
                "!=" => rightSide != leftSide,
                "==" => rightSide == leftSide,
                _ => false,
            };
        }

        public static bool operator <(RationalNr a, RationalNr b)
            => compareTwoFractions(a, b, "<");

        public static bool operator >(RationalNr a, RationalNr b)
            => compareTwoFractions(a, b, ">");

        public static bool operator <=(RationalNr a, RationalNr b)
            => compareTwoFractions(a, b, "<=");

        public static bool operator >=(RationalNr a, RationalNr b)
            => compareTwoFractions(a, b, ">=");

        public static bool operator ==(RationalNr a, RationalNr b)
            => compareTwoFractions(a, b, "==");

        public static bool operator !=(RationalNr a, RationalNr b)
            => compareTwoFractions(a, b, "!=");
    }
}
