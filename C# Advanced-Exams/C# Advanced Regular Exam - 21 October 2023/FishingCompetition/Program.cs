using System;

namespace FishingCompetition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool gameOver = false;
            int posRow = -1;
            int posCol = -1;
            int fish = 0;

            //Create and populate matrix
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    if (input[col] == 'S')
                    {
                        matrix[row, col] = '-';
                        posRow = row;
                        posCol = col;
                    }
                    else
                        matrix[row, col] = input[col];
                }
            }

            //play
            string command;
            while ((command = Console.ReadLine()) != "collect the nets")
            {
                switch (command)
                {
                    case "up":
                        if (posRow == 0)
                            posRow = size - 1;
                        else
                            posRow--;
                        break;
                    case "down":
                        if (posRow == size - 1)
                            posRow = 0;
                        else
                            posRow++;
                        break;
                    case "left":
                        if (posCol == 0)
                            posCol = size - 1;
                        else
                            posCol--;
                        break;
                    case "right":
                        if (posCol == size - 1)
                            posCol = 0;
                        else
                            posCol++;
                        break;
                }
                if (char.IsDigit(matrix[posRow, posCol]))
                {
                    fish += int.Parse(matrix[posRow, posCol].ToString());
                    matrix[posRow, posCol] = '-';
                }
                else if (matrix[posRow, posCol] == 'W')
                {
                    gameOver = true;
                    fish = 0;
                    break;
                }
            }

            if (gameOver)
                Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{posRow},{posCol}]");
            else if (fish >= 20)
                Console.WriteLine("Success! You managed to reach the quota!");
            else
                Console.WriteLine($"You didn't catch enough fish and didn't reach the quota! You need {20 - fish} tons of fish more.");

            if (fish > 0)
                Console.WriteLine($"Amount of fish caught: {fish} tons.");

            if (!gameOver)
            {
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (col == posCol && row == posRow)
                            Console.Write('S');
                        else
                            Console.Write(matrix[row, col]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
