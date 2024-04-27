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

                    result[r, c] = row.dotProduct(column);
                }

            }

            return new Matrix(result);
        }
         
        public Vector ExtractColumn(int c)
        {
            int matrixHeight = _data.GetLength(0);
            var result = new double[matrixHeight];
            for (var y = 0; y < matrixHeight; y++)
            {
                result[y] = _data[y, c];
            }
            return new Vector(result);
        }


        public Vector ExtractRow(int r)
        {
            int matrixLength = _data.GetLength(1);
            var result = new double[matrixLength];
            for (var x = 0; x < matrixLength; x++)
            {
                result[x] = _data[r, x];
            }
            return new Vector(result);
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

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int y = 0; y < _data.GetLength(0); y++)
            {
                for (int x = 0; x < _data.GetLength(1); x++)
                {
                    sb.Append( _data[y, x].ToString());
                    sb.Append(", ");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public string Dump => ToString();

        public Vector ExtractVector()
        {
            if(_data.GetLength(0) == 1)
                return ExtractRow(0);
            if (_data.GetLength(1) == 1)
                return ExtractColumn(0);
            else
                throw new Exception("could not extract vector from matrix");

        }

        public static Matrix operator*(Matrix a, Matrix b)
        {
            return a.Multiply(b);
        }

        public Vector SumRows()
        {
            var result = new double[_data.GetLength(0)];
            for(int y =0; y < _data.GetLength(0); y++)
            {
                result[y] = ExtractRow(y)._data.Sum();
            }
            return new Vector(result);
        }

        public Vector SumColumns()
        {
            var result = new double[_data.GetLength(1)];
            for (int x = 0; x < _data.GetLength(1); x++)
            {
                result[x] = ExtractColumn(x)._data.Sum();
            }
            return new Vector(result);
        }

        public Matrix ScaleMatrix(double scale)
        {
            var result = new double[_data.GetLength(0),_data.GetLength(1)];
            for(int y =0; y < _data.GetLength(0); y++)
            {
                for(int x = 0; x < _data.GetLength(1); x++)
                {
                    result[y,x] = _data[y,x]*scale;
                }
            }
            return new Matrix(result);
        }

        public Matrix SubMatrix(Matrix m2)
        {
            var result = new double[_data.GetLength(0), _data.GetLength(1)];
            for (int y = 0; y < _data.GetLength(0); y++)
            {
                for (int x = 0; x < _data.GetLength(1); x++)
                {
                    result[y, x] = _data[y, x] - m2._data[y,x];
                }
            }
            return new Matrix(result);
        }

        public Matrix ScaleRows(Vector vector)
        {
            var result = new double[_data.GetLength(0), _data.GetLength(1)];
            for (int y =0; y < _data.GetLength(0); y++)
            {
                for (int x=0;  x < _data.GetLength(1); x++)
                {
                    result[y, x] = _data[y, x] * vector._data[y];
                }
            }

            return new Matrix(result);
        }
    }
}
