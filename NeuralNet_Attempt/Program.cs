namespace NeuralNet_Attempt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = new Network(new int[3] { 3,4, 8 });
            n.ForwardPropagate(new Vector(new double[] { 0, 1, 0 }), new Vector(new double[] { 0, 0, 1, 0, 0, 0, 0, 0 }));
            n.BackwardsPropagate();

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
