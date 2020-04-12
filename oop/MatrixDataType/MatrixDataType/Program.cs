using System;

namespace MatrixDataType
{
    class Program
    {
        internal class Matrix
        {
            double[,] m;
            int rowLength { get; set; }
            public int RowLength
            {
                get => rowLength;
                set => rowLength = value;
            }
            int colLength { get; set; }
            public int ColLength
            {
                get => colLength;
                set => colLength = value;
            }

            public Matrix(double[,] m)
            {
                this.m = m;
                RowLength = m.GetLength(0);
                ColLength = m.GetLength(1);
            }

            double getElement(int i, int j)
                => m[i, j];

            public override string ToString()
            {
                string stringToWriteOut = "";

                for(int i = 0; i < rowLength; i++)
                    for(int j = 0; j < colLength; j++)
                    {
                        stringToWriteOut += Convert.ToString(m[i, j]);
                        stringToWriteOut += j != colLength - 1
                            ? "\t"
                            : "\n";
                    }

                return stringToWriteOut;
            }

            Matrix addingOrSubtractingTwoMatrices(Matrix a, Matrix b, bool getSum = true)
            {
                if (a.RowLength != b.RowLength)
                    throw new ArgumentException("The two matrices have different number of rows.");
                if (a.ColLength != b.ColLength)
                    throw new ArgumentException("The two matrices have different number of columns.");

                double[,] elements = new double[a.RowLength, a.ColLength];

                for (int i = 0; i < rowLength; i++)
                    for (int j = 0; j < colLength; j++)
                        elements[i, j] = getSum
                            ? a.getElement(i,j) + b.getElement(i,j)
                            : a.getElement(i,j) - b.getElement(i,j);

                return new Matrix(elements);
            }

            public Matrix add(Matrix addend)
                => addingOrSubtractingTwoMatrices(this, addend);

            public Matrix substract(Matrix subtrahend)
                => addingOrSubtractingTwoMatrices(this, subtrahend, false);

            public Matrix multiply(Matrix factor)
            {
                if (colLength != factor.rowLength)
                    throw new ArgumentException("Multiplication is not possible because the first " +
                        "matrix number of columns does not equals with the second matrix number of rows.");

                double[,] elements = new double[rowLength, factor.colLength];
                double sumForOneElement;

                for(int i = 0; i < rowLength; i++)
                    for(int j = 0; j < factor.colLength; j++)
                    {
                        sumForOneElement = 0;

                        for(int k = 0; k <= factor.colLength; k++)
                            sumForOneElement += m[i, k] * factor.getElement(k, j);

                        elements[i, j] = sumForOneElement;
                    }

                return new Matrix(elements);
            }

            static double[,] red(double[,] old, int lin, int col)
            {
                int n = old.GetLength(0);
                double[,] tor = new double[n - 1, n - 1];

                for (int i = 0; i < lin; i++)
                    for (int j = 0; j < col; j++)
                        tor[i, j] = old[i, j];

                for (int i = lin + 1; i < n; i++)
                    for (int j = 0; j < col; j++)
                        tor[i - 1, j] = old[i, j];

                for (int i = 0; i < lin; i++)
                    for (int j = col + 1; j < n; j++)
                        tor[i, j - 1] = old[i, j];

                for (int i = lin + 1; i < n; i++)
                    for (int j = col + 1; j < n; j++)
                        tor[i - 1, j - 1] = old[i, j];

                return tor;
            }

            static double getDeterminant(double[,] mat)
            {
                int n = mat.GetLength(0);
                if (n == 1)
                    return mat[0, 0];

                double result = 0;

                for (int i = 0; i < n; i++)
                    result += Math.Pow(-1, i) * mat[0, i] * getDeterminant(red(mat, 0, i));

                return result;
            }

            static double[,] removeRowAndColumn(double[,] mat, int i, int j)
            {
                int n = mat.GetLength(0);
                double[,] result = new double[n - 1, n - 1];
                int kmp, lmp;

                for (int k = 0; k < n - 1; k++)
                {
                    kmp = k < i ? 0 : 1;

                    for (int l = 0; l < n - 1; l++)
                    {
                        lmp = l < j ? 0 : 1;

                        result[k, l] = mat[k + kmp, l + lmp];
                    }
                }

                return result;
            }

            double[,] getMatrixOfMinors()
            {
                int n = rowLength;
                double[,] matrixOfMinors = new double[n, n];

                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                    {
                        matrixOfMinors[i, j] = getDeterminant(removeRowAndColumn(m, i, j));
                    }

                return matrixOfMinors;
            }

            double[,] getMatrixOfCofactors(double[,] mat)
            {
                int n = mat.GetLength(0);
                double[,] matrixOfCofactors = new double[n, n];

                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        matrixOfCofactors[i, j] = (i + j) % 2 == 0 || mat[i, j] == 0
                            ? mat[i, j]
                            : -mat[i, j];

                return matrixOfCofactors;
            }

            double[,] getTransposeOfAMatrix(double[,] mat)
            {
                int n = mat.GetLength(0);
                double[,] transposeOfAMatrix = new double[n, n];

                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        transposeOfAMatrix[i, j] = mat[j, i];

                return transposeOfAMatrix;
            }

            public static Matrix operator /(Matrix mat, double divisor)
            {
                double[,] elements = new double[mat.RowLength, mat.ColLength];

                for (int i = 0; i < mat.rowLength; i++)
                    for (int j = 0; j < mat.colLength; j++)
                        elements[i, j] = mat.getElement(i, j) / divisor;

                return new Matrix(elements);
            }

            public Matrix getInverse()
            {
                if (rowLength != colLength)
                    throw new ArgumentException("Determinant can not be calculated because the " +
                        "number of rows does not equals with the number of columns.");

                double determinantOfTheMatrix = getDeterminant(m);

                if (determinantOfTheMatrix == 0)
                    throw new ArgumentException("Inverse can not be calculated because the " +
                        "determinant of the matrix is zero.");

                double[,] matrixOfMinors = getMatrixOfMinors();
                double[,] matrixOfCofactors = getMatrixOfCofactors(matrixOfMinors);
                double[,] adjugateOfAMatrix = getTransposeOfAMatrix(matrixOfCofactors);

                return new Matrix(adjugateOfAMatrix) / determinantOfTheMatrix;
            }
        }

        static void Main(string[] args)
        {
            try
            {
                double[,] matrixElements1 = {
                    { 1, 2, 3 },
                    { 4, 5, 6 },
                    { 7, 8, 9 },
                    { 10, 11, 12 }
                };
                double[,] matrixElements2 = {
                    { 2, 2, 3 },
                    { 4, 5, 8 },
                    { 7, 5, 9 },
                    { 10, 11, 13 }
                };
                Matrix matrix1 = new Matrix(matrixElements1);
                Matrix matrix2 = new Matrix(matrixElements2);

                Console.WriteLine($"Matrix1:\n{matrix1}");
                Console.WriteLine($"Matrix2:\n{matrix2}");
                Console.WriteLine($"The sum of the two matrix:\n{matrix1.add(matrix2)}");
                Console.WriteLine($"The difference of the two matrix:\n{matrix1.substract(matrix2)}");

                double[,] matrixElements3 = {
                    { 3, 2, 6 },
                    { 4, 3, 2 }
                };
                double[,] matrixElements4 = {
                    { 1, 8 },
                    { 5, 7 },
                    { 3, 1 }
                };
                Matrix matrix3 = new Matrix(matrixElements3);
                Matrix matrix4 = new Matrix(matrixElements4);

                Console.WriteLine($"Matrix3:\n{matrix3}");
                Console.WriteLine($"Matrix4:\n{matrix4}");
                Console.WriteLine($"The product of the two matrix:\n{matrix3.multiply(matrix4)}");

                double[,] matrixElements5 = {
                    { 3, 0, 2 },
                    { 2, 0, -2 },
                    { 0, 1, 1 }
                };
                Matrix matrix5 = new Matrix(matrixElements5);

                Console.WriteLine($"Matrix5:\n{matrix5}");
                Console.WriteLine($"The inverse of the matrix:\n{matrix5.getInverse()}");
            }
            catch (ArgumentException error)
            {
                Console.WriteLine(error.Message);
            }
        }
    }
}
