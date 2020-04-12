using System;

namespace RationalNrDatatype
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                RationalNr rationalNr1 = new RationalNr();
                RationalNr rationalNr2 = new RationalNr(2, 7);
                int realNr = 4;

                Console.WriteLine($"{rationalNr1} + {rationalNr2} = {rationalNr1 + rationalNr2}");
                Console.WriteLine($"{rationalNr1} - {rationalNr2} = {rationalNr1 - rationalNr2}");
                Console.WriteLine($"{rationalNr1} * {rationalNr2} = {rationalNr1 * rationalNr2}");
                Console.WriteLine($"{rationalNr1} / {rationalNr2} = {rationalNr1 / rationalNr2}");
                Console.WriteLine($"{rationalNr1} ^ {realNr} = {rationalNr1 ^ realNr}");
                Console.WriteLine($"{rationalNr1} < {rationalNr2} = {rationalNr1 < rationalNr2}");
                Console.WriteLine($"{rationalNr1} > {rationalNr2} = {rationalNr1 > rationalNr2}");
                Console.WriteLine($"{rationalNr1} <= {rationalNr2} = {rationalNr1 <= rationalNr2}");
                Console.WriteLine($"{rationalNr1} >= {rationalNr2} = {rationalNr1 >= rationalNr2}");
                Console.WriteLine($"{rationalNr1} == {rationalNr2} = {rationalNr1 == rationalNr2}");
                Console.WriteLine($"{rationalNr1} != {rationalNr2} = {rationalNr1 != rationalNr2}");
            }
            catch (ArgumentException error)
            {
                Console.WriteLine(error.Message);
            }
        }
    }
}
