using System.Data;
using System.Reflection;

namespace TheGambler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create directions
            Dictionary<string, (int row, int col)> directions = new Dictionary<string, (int row, int col)>()
            {
                ["left"] = (0, -1),
                ["right"] = (0, 1),
                ["up"] = (-1, 0),
                ["down"] = (1, 0),
            };

            //some variables
            bool jackpot = false;
            bool lostAll = false;
            int money = 100;
            (int row, int col) position = (-1, -1);

            //Populate game field
            int size = int.Parse(Console.ReadLine());
            char[,] matrix= new char[size, size];
            for (int row = 0; row < size; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    if (input[col] == 'G')
                    {
                        position = (row, col);
                        matrix[row, col] = '-';
                    }
                    else matrix[row,col] = input[col];
                }
            }
            //Play
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                (int lastRow, int lastCol) lastPosition = position;

                if (directions.ContainsKey(command))
                {
                    position.row += directions[command].row;
                    position.col += directions[command].col;
                }
                else continue;

                if (position.row < 0 || position.row > size - 1 ||
                    position.col < 0 || position.col > size - 1)
                {
                    position = lastPosition;
                    lostAll = true;
                    break;
                }
                switch (matrix[position.row,position.col])
                {
                    case 'W':
                        money += 100;
                        matrix[position.row, position.col] = '-';
                        break;
                    case 'P':
                        matrix[position.row, position.col] = '-';
                        money -= 200;
                        if (money <= 0) lostAll = true;
                        break;
                    case 'J':
                        money += 100000;
                        jackpot = true;
                        break;
                }
                if (lostAll || jackpot) break;
            }

            //Output
            if (jackpot)
            {
                Console.WriteLine("You win the Jackpot!");
                Console.WriteLine($"End of the game. Total amount: {money}$");
            }
            else if (lostAll) Console.WriteLine("Game over! You lost everything!");
            else Console.WriteLine($"End of the game. Total amount: {money}$");

            if (!lostAll)
            {
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (position.row == row && position.col == col)
                            Console.Write("G");
                        else
                            Console.Write(matrix[row, col]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
