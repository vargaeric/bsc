using System;

namespace ComplexNrDatatype
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ComplexNr complexNr1 = new ComplexNr();
                ComplexNr complexNr2 = new ComplexNr(2, -3);
                int realNr = 3;

                Console.WriteLine($"{complexNr1} + {complexNr2} = {complexNr1 + complexNr2}");
                Console.WriteLine($"{complexNr1} - {complexNr2} = {complexNr1 - complexNr2}");
                Console.WriteLine($"{complexNr1} * {complexNr2} = {complexNr1 * complexNr2}");
                Console.WriteLine($"{complexNr1} ^ {realNr} = {complexNr1 ^ realNr}");
                Console.WriteLine($"The trigonometric form: " +
                    $"{complexNr1.trigonometricFormToThePowerOf(1)}");
                Console.WriteLine($"The trigonometric form to the power of {realNr}: " +
                    $"{complexNr1.trigonometricFormToThePowerOf(realNr)}");
            }
            catch (ArgumentException error)
            {
                Console.WriteLine(error.Message);
            }
        }
    }
}
