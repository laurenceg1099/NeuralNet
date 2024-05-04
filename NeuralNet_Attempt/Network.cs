using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet_Attempt
{
    public class Network
    {
        public Layer[] layers;
        public Vector lossDerivative;
        public double learningRate = 0.0001;
        public Vector squaredError;
        private int MaxWeight;
        private int MaxBias;
        public Network(int[] layerInfo, int maxweight,int maxbias)
        {
            layers = new Layer[layerInfo.Length];
            for (int i = 0; i < layerInfo.Length; i++)
            {
                if (i != layerInfo.Length - 1)
                    layers[i] = new Layer(layerInfo[i], layerInfo[i + 1],maxweight,maxbias);
                else layers[i] = new Layer(layerInfo[i], 0,maxweight,maxbias);
            }

            //weights and bias
            MaxWeight = maxweight;
            MaxBias = maxbias;  
        }

        public void testNetwork(Vector input)
        {
            layers[0]._nodes = input;

            for (int i = 0; i < layers.Length - 1; i++)
            {
                layers[i + 1]._nodes = layers[i].GetNextNodes();
            }
            var output = layers[^1]._nodes;
            Console.WriteLine($"{input} --> {output}");
        }

        public void ForwardPropagate(Vector input , Vector label)
        {
            layers[0]._nodes = input;

            for(int i = 0 ; i < layers.Length-1; i++)
            {
                layers[i + 1]._nodes = layers[i].GetNextNodes();
            }

            var output = layers[^1]._nodes;

            squaredError = Functions.Loss(output, label);
            lossDerivative = Functions.LossDerivative(output,label);
            

        }

        public void BackwardsPropagate()
        {
            var nextlayers = new Layer[layers.Length];
            nextlayers[^1] = layers[^1];

            //wd1 shouldnt need to be transposed,a bodge
            Matrix wD1 = (layers[^2]._nodes.FromVectorVertical() * (lossDerivative.FromVectorHorizontal().ScaleRows(Functions.ActivationDerivative(layers[^2].Z)))).Transpose();
            Vector bD1 = lossDerivative.FromVectorHorizontal().ScaleRows(Functions.ActivationDerivative(layers[^2].Z)).ExtractVector();
            Vector aD1 = (layers[^2]._weights.Transpose() * lossDerivative.FromVectorVertical().ScaleRows(Functions.ActivationDerivative(layers[^2].Z))).SumRows();


            nextlayers[^2] = layers[^2];
            nextlayers[^2]._weights = nextlayers[^2]._weights.SubMatrix(wD1.ScaleMatrix(learningRate));
            nextlayers[^2]._bias = nextlayers[^2]._bias.SubVector(learningRate * bD1);

            var preNodeDerivative = aD1;
            for (int l = layers.Length-3 ;  l >= 0  ; l--)
            {
                Matrix wDnext = (layers[l]._nodes.FromVectorVertical() * (preNodeDerivative.FromVectorHorizontal().ScaleRows(Functions.ActivationDerivative(layers[l].Z)))).Transpose();
                Vector bDnext = preNodeDerivative.FromVectorHorizontal().ScaleRows(Functions.ActivationDerivative(layers[l].Z)).ExtractVector();
                var nextNodeDerivative = (layers[l]._weights.Transpose() * preNodeDerivative.FromVectorVertical().ScaleRows(Functions.ActivationDerivative(layers[l].Z))).ExtractVector();

               
                nextlayers[l] = layers[l];
                nextlayers[l]._weights = nextlayers[l]._weights.SubMatrix(wDnext.ScaleMatrix(learningRate));
                nextlayers[l]._bias =  nextlayers[l]._bias.SubVector(learningRate * bDnext);

                preNodeDerivative = nextNodeDerivative;
            }

            layers = nextlayers;
        }

    }
}
