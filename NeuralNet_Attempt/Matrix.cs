using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet_Attempt
{
    public class Matrix
    {
        public double[,] _data;
        public Matrix(double[,] InArray)
        {
            _data = InArray;
        }
        public Matrix Transpose()
        {
            var inY = _data.GetLength(0);
            var inX = _data.GetLength(1);

            var result = new double[inX, inY];

            for (var y = 0; y < inY; y++)
            {
                for (var x = 0; x < inX; x++)
                {
                    result[x, y] = _data[y, x];
                }
            }

            return new Matrix(result);
        }

        public static Matrix FromVector(double[] vector)
        {


            var result = new double[vector.Length, 1];

            for (var y = 0; y < vector.Length; y++)
            {
                result[y, 0] = vector[y];
            }

            return new Matrix(result);
        }

        public Matrix Multiply(Matrix matrix2)
        {
            var matrix1 = _data;

            if (matrix1.GetLength(1) != matrix2._data.GetLength(0))
                throw new Exception("Could not do matrix multiplication, sizes were not compatible");

            // not sure why the resulting matrix is this size it just is 
            var R1 = matrix1.GetLength(0);
            var C2 = matrix2._data.GetLength(1);

            var result = new double[R1, C2];

            for (var c = 0; c < C2; c++)
            {
                var column = matrix2.ExtractColumn(c);

                for (var r = 0; r < R1; r++)
                {
                    var row = ExtractRow(r);

                    result[r, c] = Vector.dotProduct(row, column);
                }

            }

            return new Matrix(result);
        }

        public double[] ExtractColumn(int c)
        {
            int matrixHeight = _data.GetLength(0);
            var result = new double[matrixHeight];
            for (var y = 0; y < matrixHeight; y++)
            {
                result[y] = _data[y, c];
            }
            return result;
        }


        public double[] ExtractRow(int r)
        {
            int matrixLength = _data.GetLength(1);
            var result = new double[matrixLength];
            for (var x = 0; x < matrixLength; x++)
            {
                result[x] = _data[r, x];
            }
            return result;
        }


        public void print()
        {
            for (int y = 0; y < _data.GetLength(0); y++)
            {
                var str = "";
                for (int x = 0; x < _data.GetLength(1); x++)
                {
                    str += _data[y, x].ToString();
                }
                Console.WriteLine(str);
            }

        }
    }
}
