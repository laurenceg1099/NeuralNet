using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet_Attempt
{
    public class Network
    {
        public Layer[] layers;
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

        public void ForwardPropagate()
        {
            layers[0]._nodes = inputX;

            for(int i = 0 ; i < layers.Length-1; i++)
            {
                layers[i + 1]._nodes = layers[i].GetNextNodes();
            }

            var Output = layers[-1]._nodes;


        }
    }
}
