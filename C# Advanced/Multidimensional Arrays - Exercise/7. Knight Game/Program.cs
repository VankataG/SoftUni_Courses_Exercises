namespace _7._Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //create matrix
            int dimensions = int.Parse(Console.ReadLine());
            char[,] matrix = new char[5, 5];

            //Populate the matrix
            for (int row = 0; row < dimensions; row++)
            {
                char[] inputs = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray()
                for (int col = 0; col < dimensions; col++)
                {
                    matrix[row, col] = inputs[col];
                }
            }

            //Check and remove the needed knights
            int count = 0;
            for (int row = 0; row < dimensions; row++)
            {
                
            }
        }
    }
}
