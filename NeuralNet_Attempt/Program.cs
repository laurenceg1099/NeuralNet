namespace NeuralNet_Attempt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //perameters to play with 
            var learningRate = 0.004;
            var cycles = 5000;
            //trainer and network init
            var n = new Network([3,5,4,3], 1, 1);
            var t = new Trainer(n, cycles, learningRate);


            var feature1 = new Vector([1, 0, 0]);
            var label1 = new Vector([0, 1, 1]);
            var Data1 = new Vector[] { feature1, label1 };

            var feature2 = new Vector([0, 1, 1]);
            var label2 = new Vector([1, 0, 0]);
            var Data2 = new Vector[] { feature2, label2 };


            var feature3 = new Vector([0, 0, 0]);
            var label3 = new Vector([1, 1, 1]);
            var Data3 = new Vector[] { feature3, label3 };


            var feature4 = new Vector([0, 1, 0]);
            var label4 = new Vector([1, 0, 1]);
            var Data4 = new Vector[] { feature4, label4 };

            var feature5 = new Vector([1, 1, 0]);
            var label5 = new Vector([0, 0, 1]);
            var Data5 = new Vector[] { feature5, label5 };


            var feature6 = new Vector([1, 1, 1]);
            var label6 = new Vector([0, 0, 0]);
            var Data6 = new Vector[] { feature6, label6 };


            var InputData = new Vector[][] {Data1,Data2,Data3,Data4,Data5,Data6};

            t.Train(InputData);
            t.Test([new Vector([1,0,0])]);
            t.Test([new Vector([0,1,1])]);
            Console.WriteLine();
            t.Test([new Vector([1, 0, 1])]);
            t.Test([new Vector([1, 1, 1])]);
        }

    private static void MatrixTest()
    {
        double[,] testArray = { { 2, }, { 0 } };
        double[,] testArray2 = { { 0, 1, 2 } };
        var m1 = new Matrix(testArray);
        var m2 = new Matrix(testArray2);
        var resul = m1 * m2;//m1.Multiply(m2);
        resul.print();
    }
}
}
