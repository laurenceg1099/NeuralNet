namespace NeuralNet_Attempt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[,] testArray = { { 2, 0 }, { 0, 2 } };
            double[,] testArray2 = { { 0, 1 }, { -1, 0 } };
            var m1 = new Matrix(testArray);
            var m2 = new Matrix(testArray2);
            var resul = m1.Multiply(m2);
            resul.print();


        }
    }
}
