using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet_Attempt
{
    public class MatrixInitilizer
    {
        
        
        public static Matrix weightInit(int nextcount, int nodesCount,int maxWeight)
        {
            var rand = new Random();
            var output = new double[nextcount, nodesCount];
            for (int y = 0; y < nextcount; y++)
            {
                for (int x = 0; x < nodesCount; x++)
                {
                    output[y, x] = rand.NextDouble()*maxWeight;
                }

            }

            return new Matrix(output);
        }

        public static Vector biasInit(int nodes,int maxBias)
        {
            var rand = new Random();
            var output = new double[nodes];
            for (int i = 0; i < nodes; i++)
            {
                output[i] = rand.NextDouble() * maxBias;
            }

            return new Vector(output);
        }


    }
}
