using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet_Attempt
{
    public static class Functions
    {
        public static string type = "ReLU";
        public static Vector Activation(Vector nodeIn)
        {

            switch (type)
            {
                case "ReLU":
                    return ReLU(nodeIn);

            }

            return nodeIn;
        }

        public static Vector ReLU(Vector nodeIn)
        {
            var result = new Vector(new double[nodeIn._data.Length]);
            for (int i = 0; i < nodeIn._data.Length; i++) 
            {
                result._data[i] = Math.Max(0, nodeIn._data[i]); 
            }

            return result;
        }

    }
}
