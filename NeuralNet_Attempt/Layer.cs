using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet_Attempt
{
    class Layer
    {
        private double[] _nodes;
        private double[,] _weights;
        private double[] _bias;
        public Layer(int nodes , int nex_count)
        {
            _nodes = new double[nodes];
            _weights = new double[nex_count,nodes];
            _bias = new double[nex_count];

        }
            
        public double[] GetNextNodes()
        {
            var Z =  (Matrix.Multiply(_weights,Matrix.Transpose(_nodes) + bias;
            return z.activaion;
        }
        
    }
}
