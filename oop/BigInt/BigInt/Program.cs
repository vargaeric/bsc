using System;

namespace BigInt
{
    internal class BigInt
    {
        string number;
        int nrOfDigits;
        public int NrOfDigits
        {
            get => nrOfDigits;
        }

        public BigInt(string number = "0")
        {
            this.number = number;
            nrOfDigits = number.Length;
        }

        public override string ToString()
            => number;

        public int this[int i]
        {
            get => number[i] - '0';
        }

        public static BigInt operator +(BigInt addend1, BigInt addend2)
        {
            int litAddNrOfDigits, bigAddNrOfDigits;
            BigInt littlerAddend, biggerAddend;

            if (addend1.NrOfDigits < addend2.NrOfDigits)
            {
                litAddNrOfDigits = addend1.NrOfDigits;
                bigAddNrOfDigits = addend2.NrOfDigits;
                littlerAddend = addend1;
                biggerAddend = addend2;
            }
            else
            {
                litAddNrOfDigits = addend2.NrOfDigits;
                bigAddNrOfDigits = addend1.NrOfDigits;
                littlerAddend = addend2;
                biggerAddend = addend1;
            }

            int index = bigAddNrOfDigits - 1, carry = 0, sumOfTwoDigits;
            string sum = "";

            while (index > -1)
            {
                int indexForLitAdd = litAddNrOfDigits - (bigAddNrOfDigits - index);

                sumOfTwoDigits = indexForLitAdd > -1
                    ? biggerAddend[index] + littlerAddend[indexForLitAdd] + carry
                    : biggerAddend[index] + carry;

                if (sumOfTwoDigits >= 10)
                {
                    carry = 1;
                    sumOfTwoDigits -= 10;
                }
                else
                {
                    carry = 0;
                }

                index--;

                sum = sumOfTwoDigits + sum; 
            };

            if (carry == 1)
                sum =  "1" + sum;

            return new BigInt(sum);
        }

        public static BigInt operator *(BigInt factor1, BigInt factor2)
        {
            int n = factor2.NrOfDigits;
            string stepper = "";
            BigInt sum, product = new BigInt("0");

            for(int i = n - 1; i >= 0; i--)
            {
                int m = factor2[i];

                sum = new BigInt("0");

                for(int j = 0; j < m; j++)
                    sum += factor1;

                product += new BigInt(Convert.ToString(sum) + stepper);
                stepper += "0";
            }

            return product;
        }
    }

    class Program
    {
        static BigInt[] getFibonacciSequence(int n)
        {
            BigInt[] fibonacciSequence = new BigInt[n + 1];

            fibonacciSequence[0] = new BigInt("0");

            if (n >= 1)
                fibonacciSequence[1] = new BigInt("1");

            if (n >= 2)
            {
                BigInt addend1 = new BigInt("0"), addend2 = new BigInt("1"), s;

                for (int i = 2; i <= n; i++)
                {
                    s = addend1;
                    addend1 = addend2;
                    addend2 += s;

                    fibonacciSequence[i] = addend2;
                }
            }

            return fibonacciSequence;
        }

        static BigInt[] getFactorialSequence(int n)
        {
            BigInt[] factorialSequence = new BigInt[n + 1];

            factorialSequence[0] = new BigInt("1");

            if (n >= 1)
            {
                factorialSequence[1] = new BigInt("1");

                if (n >= 2)
                {
                    BigInt currentFactorial = new BigInt("1");

                    for (int i = 2; i <= n; i++)
                    {
                        currentFactorial *= new BigInt(Convert.ToString(i));
                        factorialSequence[i] = currentFactorial;

                    }
                }
            }

            return factorialSequence;
        }

        static void Main(string[] args)
        {
            BigInt[] fibonacciSequence = getFibonacciSequence(100);
            Console.WriteLine($"The fibonacci sequence 100th element is {fibonacciSequence[100]}.");

            BigInt[] factorialSequence = getFactorialSequence(100);
            Console.WriteLine($"100!={factorialSequence[100]}");
        }
    }
}
