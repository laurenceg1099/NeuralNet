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
        public  Vector _nodes;
        private Matrix _weights;
        private Vector _bias;
        public Layer(int nodes_count , int next_count)
        {
            _nodes = new Vector(new double[nodes_count]);
            _weights = new Matrix(new double[next_count,nodes_count]);
            _bias = new Vector(new double[next_count]);

        }

        public Vector GetNextNodes()
        {
            var Z = (_weights.Multiply(_nodes.FromVectorVertical())).ExtractVector().SumVector(_bias);
            return Functions.Activation(Z);
        }

    }
}
