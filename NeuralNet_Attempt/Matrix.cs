using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet_Attempt
{
    public static class Matrix
    {
        public static double[,] Transpose(double[,] inMatix)
        {
            var inY = inMatix.GetLength(0);
            var inX = inMatix.GetLength(1);

            var result = new double[inX, inY];

            for (var y = 0; y < inY; y++)
            {
                for (var x = 0; x < inX; x++)
                {
                    result[x, y] = inMatix[y, x];
                }
            }

            return result;
        }

        public static double[,] FromVector(double[] vector)
        {


            var result = new double[vector.Length, 1];

            for (var y = 0; y < vector.Length; y++)
            {
                result[y, 0] = vector[y];
            }

            return result;
        }

        public static double[,] Multiply(double[,] matrix1, double[,] matrix2)
        {
            if (matrix1.GetLength(1) != matrix2.GetLength(0))
                throw new Exception("Could not do matrix multiplication, sizes were not compatible");

            // not sure why the resulting matrix is this size it just is 
            var R1 = matrix1.GetLength(0);
            var C2 = matrix2.GetLength(1);

            var result = new double[R1, C2];

            for (var c = 0; c < C2; c++)
            {
                var column = Matrix.ExtractColumn(matrix2, c);

                for (var r = 0; r < R1; r++)
                {
                    var row = Matrix.ExtractRow(matrix1, r);

                    result[r, c] = Vector.dotProduct(row, column);
                }

            }

            return result;
        }

        public static double[] ExtractColumn(double[,] matrix, int c)
        {
            int matrixHeight = matrix.GetLength(0);
            var result = new double[matrixHeight];
            for (var y = 0; y < matrixHeight; y++)
            {
                result[y] = matrix[y, c];
            }
            return result;
        }


        public static double[] ExtractRow(double[,] matrix, int r)
        {
            int matrixLength = matrix.GetLength(1);
            var result = new double[matrixLength];
            for (var x = 0; x < matrixLength; x++)
            {
                result[x] = matrix[r, x];
            }
            return result;
        }
    }
}
