using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet_Attempt
{
    public static class Functions
    {
        // activation functions .... sigmoid?
        public static string ActivationType = "ReLU";
        public static Vector Activation(Vector nodeIn)
        {

            switch (ActivationType)
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




        // loss functions (squared error)

        public static string LossType = "SE";
        public static Vector Loss(Vector prediction, Vector OneHotLabel)
        {

            switch (ActivationType)
            {
                case "SE":
                    return SE(prediction, OneHotLabel);

            }

            throw new NotImplementedException();
        }

        public static Vector SE(Vector prediction, Vector OneHotLabel)
        {
            var error = OneHotLabel.SubVector(prediction);
            var SqEr = new Vector(new double[prediction._data.Length]);
            for (int i = 0;i < prediction._data.Length; i++)
            {
                SqEr._data[i] = Math.Pow(error._data[i], 2);
            }
            return SqEr;
        }
    }
}
