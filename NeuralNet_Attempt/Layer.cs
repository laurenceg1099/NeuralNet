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
        public Layer(int nodes_count , int next_count, int maxWeight , int maxbias)
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

        

    }
}   
