namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create player coords and bools 
            int locationCol = 0;
            int locationRow = 0;
            bool endGame = false;
            bool winGame = false;

            //Read array data
            int[] arrInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            int rowsCount = arrInfo[0];
            int colsCount = arrInfo[1];

            //Create matrix
            string[,] matrix = new string[rowsCount, colsCount];

            //Populate matrix
            for (int row = 0; row < rowsCount; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < colsCount; col++)
                {
                    if (input[col] == 'P') //Get player coords
                    {
                        locationRow = row;
                        locationCol = col;
                    }

                    matrix[row, col] = input[col].ToString();
                }
            }

            //Read commands
            string commands = Console.ReadLine();

            //Move your Player
            foreach (char command in commands)
            {
                switch (command) //Make checks for every command so you don't get an error!!!!
                {
                    case 'L':
                        if (locationCol - 1 >= 0) locationCol--;
                        else winGame = true; // Moving out of bounds is a win
                        break;
                    case 'R':
                        if (locationCol + 1 < colsCount) locationCol++;
                        else winGame = true;
                        break;
                    case 'U':
                        if (locationRow - 1 >= 0) locationRow--;
                        else winGame = true;
                        break;
                    case 'D':
                        if (locationRow + 1 < rowsCount) locationRow++;
                        else winGame = true;
                        break;
                }

                //Spread each bunny
                string[,] copyMatrix = (string[,]) matrix.Clone(); //Clone the matrix to skip errors

                for (int row = 0; row < rowsCount; row++)
                {
                    for (int col = 0; col < colsCount; col++)
                    {
                        if (matrix[row, col] == "B")
                        {
                            //Make checks !!!!!
                            if (col > 0)
                                copyMatrix[row, col - 1] = "B";
                            if (col < colsCount - 1)
                                copyMatrix[row, col + 1] = "B";
                            if (row > 0)
                                copyMatrix[row - 1, col] = "B";
                            if (row < rowsCount - 1)
                                copyMatrix[row + 1, col] = "B";
                        }
                    }
                }

                matrix = copyMatrix;

                //Check if you get out of the bunny lair (matrix)
                if (winGame)
                    break;

                //Check if any bunny reached you
                if (matrix[locationRow, locationCol] == "B")
                {
                    endGame = true;
                    break;
                }
            }

            //Output
            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < colsCount; col++)
                {
                    if (matrix[row, col] == "P")
                        matrix[row, col] = ".";
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }

            if (winGame)
            {
                
                Console.WriteLine($"won: {locationRow} {locationCol}");
            }
            else if (endGame)
                    Console.WriteLine($"dead: {locationRow} {locationCol}");
        }
    }
}
