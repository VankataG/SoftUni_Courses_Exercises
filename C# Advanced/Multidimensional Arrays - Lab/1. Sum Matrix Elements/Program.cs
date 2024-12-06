namespace _1._Sum_Matrix_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Read matrix from console
            int[] dimension = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = dimension[0];
            int cols = dimension[1];

            int[,] matrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                int[] numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = numbers[j];
                }
            }



            Console.WriteLine(rows);
            Console.WriteLine(cols);

            //Sum all elements in the matrix
            int sum = 0;
            foreach (int element in matrix)
            {
                sum += element;
            }
            Console.WriteLine(sum);
        }
    }
}
