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
    public class Layer
    {
        public  Vector _nodes;
        public Matrix _weights;
        public Vector _bias;
        public Vector Z;
        public Matrix _weightGradient;
        public Vector _biasGradient;
        private readonly int _nodes_Count;
        private readonly int _next_Count;

        private Layer(int nodes_count, int next_count)
        {
            _nodes_Count = nodes_count;
            _next_Count = next_count;
            ResetGradients();

        }

        public void ResetGradients()
        {
            _weightGradient = MatrixInitilizer.weightInit(_next_Count, _nodes_Count);
            _biasGradient = MatrixInitilizer.biasInit(_next_Count);
        }

        public Layer(int nodes_count , int next_count, int maxWeight , int maxbias) : this(nodes_count, next_count)
        {
            _nodes = new Vector(new double[nodes_count]);
            _weights = MatrixInitilizer.weightInit(next_count,nodes_count,maxWeight);
            _bias = MatrixInitilizer.biasInit(next_count,maxbias);
           
        }

        public Vector GetNextNodes()
        {
            Z = (_weights.Multiply(_nodes.FromVectorVertical())).ExtractVector().SumVector(_bias);
            return Functions.Activation(Z);
        }

        internal Layer Clone()
        {
            var result = new Layer(_nodes_Count,_next_Count);
            result._nodes = _nodes.Clone();
            result._weights = _weights.Clone();
            result._bias = _bias.Clone();


            return result;
        }

    }
}   
