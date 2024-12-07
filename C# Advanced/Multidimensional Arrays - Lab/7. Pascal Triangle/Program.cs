namespace _7._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowsCount = int.Parse(Console.ReadLine());

            ulong[][] triangle = new ulong[rowsCount][];
            for (int row = 0; row < rowsCount; row++)
            {
                triangle[row] = new ulong[row + 1];
                triangle[row][0] = 1;
                for (int col = 1; col < row; col++)
                {
                    triangle[row][col] = triangle[row - 1][col] + triangle[row - 1][col - 1];
                }
                triangle[row][triangle[row].Length - 1] = 1;
            }

            foreach (var row in triangle)
            {
                Console.WriteLine(String.Join(" ", row));
            }
        }
    }
}
