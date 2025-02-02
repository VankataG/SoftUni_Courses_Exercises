namespace ClearSkies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Some in game properties
            int enemies = 0;

            int armor = 300;
            int posRow = -1;
            int posCol = -1;

            bool completed = false;
            bool failed = false;
            //Create and populate matrix
            int range = int.Parse(Console.ReadLine());

            char[,] matrix = new char[range, range];

            for (int row = 0; row < range; row++)
            {
                string data = Console.ReadLine();
                for (int col = 0; col < range; col++)
                {
                    if (data[col] == 'J')
                    {
                        (posRow, posCol) = (row, col);
                        matrix[row, col] = '-';
                        continue;
                    } 
                    if (data[col] == 'E')
                        enemies++;
                    
                    matrix[row, col] = data[col];
                }
            }
            
            //Play
            while (!completed && !failed)
            {
                string command = Console.ReadLine();
                switch (command)
                {
                    case "up":
                        posRow--;
                        break;
                    case "down":
                        posRow++;
                        break;
                    case "left":
                        posCol--;
                        break;
                    case "right":
                        posCol++;
                        break;
                }
                switch (matrix[posRow,posCol])
                {
                    case 'E':
                        if (enemies == 1)
                        {
                            completed = true;
                            matrix[posRow, posCol] = '-';
                        }
                        else
                        {
                            armor -= 100;
                            enemies--;
                            matrix[posRow, posCol] = '-';
                            if (armor == 0)
                                failed = true;
                        }
                        break;
                    case 'R':
                        armor = 300;
                        matrix[posRow, posCol] = '-';
                        break;
                }
            }

            //Output
            if (completed)
                Console.WriteLine("Mission accomplished, you neutralized the aerial threat!");
            else if(failed)
                Console.WriteLine($"Mission failed, your jetfighter was shot down! Last coordinates [{posRow}, {posCol}]!");

            for (int row = 0; row < range; row++)
            {
                for (int col = 0; col < range;col++)
                {
                    if (posRow == row && posCol == col)
                        Console.Write("J");
                    else
                        Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
