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
        private Vector _nodes;
        private Matrix _weights;
        private Vector _bias;
        public Layer(int nodes , int nex_count)
        {
            _nodes = new Vector(new double[nodes]);
            _weights = new Matrix(new double[nex_count,nodes]);
            _bias = new Vector(new double[nex_count]);

        }

        public Vector GetNextNodes()
        {
            var Z = (_weights.Multiply(_nodes.FromVectorVertical())).ExtractVector().SumVector(_bias);
            return Functions.Activation(Z);
        }

    }
}
