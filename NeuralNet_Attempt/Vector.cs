using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet_Attempt
{

    public class Vector
    {
        public double[] _data;
        public Vector(double[] inVect)
        {
            _data = inVect;
        }
        public double dotProduct(Vector vectB)
        {
            if (_data.Length != vectB._data.Length)
                throw new Exception("Collum and row size did not match");

            var result = new double[_data.Length];
            for (int i = 0; i < _data.Length; i++)
            {
                result[i] = _data[i] * vectB._data[i];
            }

            // result = [ab,cd,ef,...]
            return result.Sum();
        }

        public Vector SumVector(Vector VectB)
        {
            var result = new Vector(new double[_data.Length]);
            for (int i =0; i < _data.Length; ++i)
            {
                result._data[i] = VectB._data[i] + _data[i];
            }

            return result;
        }

        public Vector SubVector(Vector VectB)
        {
            var result = new Vector(new double[_data.Length]);
            for (int i = 0; i < _data.Length; ++i)
            {
                result._data[i] = _data[i] - VectB._data[i];
            }

            return result;
        }
        public Matrix FromVectorVertical()
        {
            var result = new double[_data.Length, 1];

            for (var y = 0; y < _data.Length; y++)
            {
                result[y, 0] = _data[y];
            }

            return new Matrix(result);
        }

        public Matrix FromVectorHorizontal()
        {
            var result = new double[1,_data.Length];

            for (var x = 0; x < _data.Length; x++)
            {
                result[0, x] = _data[x];
            }

            return new Matrix(result);
        }

        public Vector ScaleVector(double scale)
        {
            var result = new Vector(new double[_data.Length]);
            for(int x=0; x<  _data.Length; x++)
            {
                result._data[x] = _data[x]*scale;
            }

            return result;
        }

        public static Vector operator*(double scale,Vector v1)
        {
            return v1.ScaleVector(scale);
        }
    }
}
