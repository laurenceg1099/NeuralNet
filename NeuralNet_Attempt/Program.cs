namespace NeuralNet_Attempt
{
    internal class Program
    {
        static void Main(string[] args)
        {
             double[,] testArray = { { 2, 0 }, { 0, 2 } };
             double[,] testArray2 = { {0,1}, {-1,0} };
             var final = Matrix.Multiply(testArray, testArray2);
        }
    }
}
