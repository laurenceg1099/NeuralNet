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
        public double learningRate = 0.5;
        public Network(int[] layerInfo)
        {
            layers = new Layer[layerInfo.Length];
            for (int i = 0; i < layerInfo.Length; i++)
            {
                if (i != layerInfo.Length - 1)
                    layers[i] = new Layer(layerInfo[i], layerInfo[i + 1]);
                else layers[i] = new Layer(layerInfo[i], 0);
            }
        }

        public void ForwardPropagate(Vector input , Vector label)
        {
            layers[0]._nodes = input;

            for(int i = 0 ; i < layers.Length-1; i++)
            {
                layers[i + 1]._nodes = layers[i].GetNextNodes();
            }

            var output = layers[^1]._nodes;

            var squaredError = Functions.Loss(output, label);
            lossDerivative = Functions.LossDerivative(output,label);

        }

        public void BackwardsPropagate()
        {
            var nextlayers = new Layer[layers.Length];
            nextlayers[^1] = layers[^1];
            Matrix wD1 = (lossDerivative.FromVectorVertical() * layers[^2]._nodes.FromVectorHorizontal()) * Functions.ActivationDerivative(layers[^2].Z).FromVectorVertical() ;
            Vector bD1 = (lossDerivative.FromVectorHorizontal() * Functions.ActivationDerivative(layers[^2].Z).FromVectorVertical()).ExtractVector();
            Vector aD1 = (layers[^2]._weights * Functions.ActivationDerivative(layers[2].Z).FromVectorVertical() * lossDerivative.FromVectorVertical()).SumRows();

            nextlayers[^2] = layers[^2];
            nextlayers[^2]._weights.SubMatrix(wD1.ScaleMatrix(learningRate));
            nextlayers[^2]._bias.SubVector(learningRate * bD1);

            var preNodeDerivative = aD1;
            for (int l = layers.Length-3 ;  l >= 0  ; l--)
            {
                
                Matrix wDnext = preNodeDerivative.FromVectorHorizontal() * layers[l]._nodes.FromVectorVertical() * Functions.ActivationDerivative(layers[l].Z).FromVectorVertical();
                Vector bDnext = (preNodeDerivative.FromVectorHorizontal() * Functions.ActivationDerivative(layers[l].Z).FromVectorVertical()).ExtractVector();
                var nextNodeDerivative = (layers[l]._weights * Functions.ActivationDerivative(layers[l].Z).FromVectorVertical() * preNodeDerivative.FromVectorVertical()).SumRows();

                nextlayers[l] = layers[l];
                nextlayers[l]._weights.SubMatrix(wDnext.ScaleMatrix(learningRate));
                nextlayers[l]._bias.SubVector(learningRate * bDnext);

                preNodeDerivative = nextNodeDerivative;
            }
        }

    }
}
