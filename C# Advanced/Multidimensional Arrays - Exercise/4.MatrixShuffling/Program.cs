namespace _4.MatrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Read matrix
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rowsCount = input[0];
            int colsCount = input[1];

            string[,] matrix = new string[rowsCount, colsCount];
            for (int row = 0; row < rowsCount; row++)
            {
                string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            //Swap coordinates by input
            string comm;
            while ((comm = Console.ReadLine()) != "END")
            {
                string[] commands = comm.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (commands[0] == "swap")
                {
                    
                    if (commands.Length > 5 || commands.Length < 5 )
                        PrintError();
                    else
                    {
                        int row1 = int.Parse(commands[1]);
                        int col1 = int.Parse(commands[2]);
                        int row2 = int.Parse(commands[3]);
                        int col2 = int.Parse(commands[4]);
                        if (row1 < 0 || row1 > rowsCount - 1 || row2 < 0 || row2 > rowsCount - 1 ||
                            col1 < 0 || col1 > colsCount - 1 || col2 < 0 || col2 > colsCount - 1)
                            PrintError();


                        else
                        {
                            SwapElementsInMatrix(matrix, row1, col1, row2, col2);
                            PrintMatrix(matrix, rowsCount, colsCount);
                        }
                    }
                }
                else
                {
                    PrintError();   
                }
            }
        }

        static void PrintError()
        {
            Console.WriteLine("Invalid input!");
        }

        static void SwapElementsInMatrix(string[,] matrix, int row1, int col1, int row2, int col2)
        {
            string copyElement = matrix[row1, col1];
            matrix[row1, col1] = matrix[row2, col2];
            matrix[row2, col2] = copyElement;
        }

        static void PrintMatrix(string[,] matrix, int rowsCount, int colsCount)
        {
            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < colsCount; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

    }
}
