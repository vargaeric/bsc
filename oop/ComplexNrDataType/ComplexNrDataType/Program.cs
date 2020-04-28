using System;

namespace ComplexNrDatatype
{
    class Program
    {
        public struct trigonometricForm
        {
            public double factor;
            public double realPart;
            public double imaginaryPart;
        }

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
                Console.WriteLine($"{complexNr1} ^ {realNr} = {complexNr1.toThePower(realNr)}");
                Console.WriteLine($"The trigonometric form: " +
                    $"{complexNr1.trigonometricFormToThePowerOf()}");
                Console.WriteLine($"The trigonometric form to the power of {realNr}: " +
                    $"{complexNr1.trigonometricFormToThePowerOf(realNr)}");
                Console.WriteLine();

                ComplexD complexD = new ComplexD();
                ComplexNr[] listOfComplexNrs = new ComplexNr[5] { 
                    new ComplexNr(14, 6),
                    new ComplexNr(-12, 0),
                    new ComplexNr(3, 9),
                    new ComplexNr(5, 5),
                    new ComplexNr(7, 12),
                };

                Console.WriteLine($"{complexD} ^ {realNr} (calculated with the trigonometric" +
                    $" form) = {complexD.toThePower(realNr)}");
                Console.WriteLine($"The distance between the complex number and a set of complex" +
                    $" numbers is {complexD.getDisBtwCompAndSet(listOfComplexNrs)}");
            }
            catch (ArgumentException error)
            {
                Console.WriteLine(error.Message);
            }
        }
    }
}
