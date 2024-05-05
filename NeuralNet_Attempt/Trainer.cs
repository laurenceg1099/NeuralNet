using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet_Attempt
{
    internal class Trainer
    {
        private Network n;
        private int gradCycles;
        public Trainer(Network N ,int cycles,double learingRate) 
        { 
            n = N;
            n.learningRate = learingRate;
            gradCycles = cycles;

        }

        public void Train(Vector[][] TrainingData)
        {
            for(int i = 0; i < gradCycles; i++)
            {
                foreach(var example in TrainingData)
                {
                    n.ForwardPropagate(example[0], example[1]);
                    n.BackwardsPropagate();
                    Console.WriteLine($"Iteratrion:{i} {n.squaredError._data.Sum()}");
                }


                n.ApplyGradients(TrainingData.Length);
            }


        }

        public void Test(Vector[] TestingData)
        {
            n.testNetwork(TestingData[0]);
        }
    }
}
