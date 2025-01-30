namespace EscapeTheMaze
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool gameOver = false;
            bool escaped = false;

            int health = 100;
            int playerRow = -1;
            int playerCol = -1;

            int range = int.Parse(Console.ReadLine());

            char[,] maze = new char[range, range];

            for (int row = 0; row < range; row++)
            {
                string rowData = Console.ReadLine();
                for (int col = 0; col < range; col++)
                {
                    if (rowData[col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                        maze[row, col] = '-';
                    }
                    else
                        maze[row, col] = rowData[col];
                }
            }

            while (!escaped && !gameOver)
            {
                string command = Console.ReadLine();
                switch (command)
                {
                    case "up":
                        if (playerRow == 0) continue;
                        playerRow--;
                        break;
                    case "down":
                        if (playerRow == range - 1) continue;
                        playerRow++;
                        break;
                    case "left":
                        if (playerCol == 0) continue;
                        playerCol--;
                        break;
                    case "right":
                        if (playerCol == range - 1) continue;
                        playerCol++;
                        break;
                }

                switch (maze[playerRow, playerCol])
                {
                    case 'M':
                        health -= 40;

                        if (health <= 0)
                        {
                            health = 0;
                            gameOver = true;
                            break;
                        }
                        maze[playerRow, playerCol] = '-';
                        break;
                    case 'H':
                        health += 15;
                        if (health > 100)
                            health = 100;
                        maze[playerRow, playerCol] = '-';
                        break;
                    case 'X':
                        escaped = true;
                        break;
                }
            }

            if (gameOver)
                Console.WriteLine("Player is dead. Maze over!");
            else if (escaped)
            {
                Console.WriteLine("Player escaped the maze. Danger passed!");
            }

            Console.WriteLine($"Player's health: {health} units");

            for (int row = 0; row < range; row++)
            {
                for (int col = 0; col < range; col++)
                {
                    if (playerRow == row && playerCol == col)
                        Console.Write("P");
                    else
                        Console.Write(maze[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
