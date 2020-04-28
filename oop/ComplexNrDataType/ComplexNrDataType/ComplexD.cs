using System;

namespace ComplexNrDatatype
{
    internal class ComplexD : ComplexNr
    {
        public override ComplexNr toThePower(int power)
        {
            Program.trigonometricForm nrsOfTrigoForm = getNrsOfTrigoForm(this, power);

            return new ComplexNr(nrsOfTrigoForm.factor, 0)
                * new ComplexNr(nrsOfTrigoForm.realPart, nrsOfTrigoForm.imaginaryPart);
        }

        // Calculate the distance between two complex numbers
        public static double getDisBtwTwoComplexNrs(ComplexNr complexNr1, ComplexNr complexNr2)
        {
            ComplexNr difference = complexNr2 - complexNr1;

            return roundNr(
                Math.Sqrt(Math.Pow(difference.realPart, 2) + Math.Pow(difference.imaginaryPart, 2))
            );
        }

        // Calculate the distance between a complex number and a set of complex numbers
        public double getDisBtwCompAndSet(ComplexNr[] listOfComplexNrs)
        {
            if (listOfComplexNrs.Length == 0)
                throw new ArgumentException($"The array given as a set of complex numbers was" +
                    $" empty.");

            double disBtwTwoComplexNrs;
            double minDis =  getDisBtwTwoComplexNrs(this, listOfComplexNrs[0]);

            foreach (ComplexNr complexNr in listOfComplexNrs)
            {
                disBtwTwoComplexNrs = getDisBtwTwoComplexNrs(this, complexNr);
                if (minDis < disBtwTwoComplexNrs)
                    minDis = disBtwTwoComplexNrs;
            };

            return roundNr(minDis);
        }
    }
}