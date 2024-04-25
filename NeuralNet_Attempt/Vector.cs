using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet_Attempt
{
    
    public static class Vector
    {
        public static double dotProduct(double[] vectA, double[] vectB)
        {
            if (vectA.Length != vectB.Length)
                throw new Exception("Collum and row size did not match");

            var result = new double[vectA.Length];
            for(int i = 0; i < vectA.Length; i++)
            {
                result[i] = vectA[i] * vectB[i];    
            }

            // result = [ab,cd,ef,...]
            return result.Sum();
        }
    }
}
