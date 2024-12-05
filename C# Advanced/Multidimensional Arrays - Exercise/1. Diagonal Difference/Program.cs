namespace _1._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int primaryDiagSum = 0;
            int secondaryDiagSum = 0;

            //Read matrix
            int rowsCount = int.Parse(Console.ReadLine());
            int[,] matrix = new int[rowsCount, rowsCount];
            for (int row = 0; row < rowsCount; row++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < rowsCount; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            //Sum primary diagonal sum
            for (int i = 0; i < rowsCount; i++)
            {
                primaryDiagSum += matrix[i, i];
            }

            //Sum secondary diagonal sum
            for (int i = 0; i < rowsCount; i++)
            {
                secondaryDiagSum += matrix[i, rowsCount - 1 - i];
            }

            //Print the absolute difference between the sums
            Console.WriteLine(Math.Abs(primaryDiagSum - secondaryDiagSum));
        }
    }
}
