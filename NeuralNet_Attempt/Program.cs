namespace NeuralNet_Attempt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MatrixTest();

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
