namespace NeuralNet_Attempt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //perameters to play with 
            var learningRate = 0.00005;
            var cycles = 900;
            //trainer and network init
            var n = new Network(new int[4] { 3, 16, 48, 3 }, 1, 1);
            var t = new Trainer(n, cycles, learningRate);


            var feature = new Vector(new double[3] { 1, 0, 0 });
            var label = new Vector(new double[3] { 0, 1, 1 });

            var Data = new Vector[2] { feature, label };
            var InputData = new Vector[][] { Data };

            t.Train(InputData);
            var testItem = new Vector(new double[3] { 0, 0, 1 });
            t.Test(new Vector[1] {testItem});

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
