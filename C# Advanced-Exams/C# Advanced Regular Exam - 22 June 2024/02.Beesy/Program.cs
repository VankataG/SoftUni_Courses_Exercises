namespace _02.Beesy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());

            int beeRow = -1;
            int beeCol = -1;
            int energy = 15;
            int nectar = 0;

            //Some bools
            bool reachedHive = false;
            bool outOfEnergy = false;
            bool restoreEnergy = true;

            //Populate matrix(Game field)
            char[,] matrix = new char[range, range];

            for (int row = 0; row < range; row++)
            {
                string data = Console.ReadLine();
                for (int col = 0; col < range; col++)
                {
                    if (data[col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                        matrix[row, col] = '-';
                    }
                    else
                        matrix[row, col] = data[col];
                }
            }

            //Play

            while (!reachedHive && !outOfEnergy)
            {
                string command = Console.ReadLine();
                energy--;

                switch (command)
                {
                    case "up":
                        if (beeRow == 0)
                            beeRow = range - 1;
                        else
                            beeRow--;

                        break;
                    case "down":
                        if (beeRow == range - 1)
                            beeRow = 0;
                        else
                            beeRow++;

                        break;
                    case "left":
                        if (beeCol == 0)
                            beeCol = range - 1;
                        else
                            beeCol--;

                        break;
                    case "right":
                        if (beeCol == range - 1)
                            beeCol = 0;
                        else
                            beeCol++;

                        break;
                }

                if (matrix[beeRow, beeCol] == 'H')
                {
                    reachedHive = true;
                    break;
                }

                if (char.IsDigit(matrix[beeRow, beeCol]))
                {
                    nectar += int.Parse(matrix[beeRow, beeCol].ToString());
                    matrix[beeRow, beeCol] = '-';
                }

                if (energy == 0 && nectar < 30) 
                    outOfEnergy = true;
                else if (energy == 0 && nectar >= 30 && restoreEnergy)
                {
                    if (nectar - 30 > 0)
                    {
                        energy += nectar - 30;
                        nectar = 30;
                        restoreEnergy = false;
                    }
                    else outOfEnergy = true;
                }
                else if (energy == 0 && nectar >= 30 && !restoreEnergy)
                {
                    outOfEnergy = true;
                    break;
                }
            }
            if (reachedHive && nectar >= 30)
                Console.WriteLine($"Great job, Beesy! The hive is full. Energy left: {energy}");
            else if (reachedHive && nectar < 30)
                Console.WriteLine($"Beesy did not manage to collect enough nectar.");
            else if (outOfEnergy)
                Console.WriteLine($"This is the end! Beesy ran out of energy.");

            for (int row = 0; row < range; row++)
            {
                for (int col = 0; col < range; col++)
                {
                    if (row == beeRow && col == beeCol)
                        Console.Write("B");
                    else
                        Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
            //for (int row = 0; row < range; row++)
            //{
            //    Console.WriteLine(string.Concat(Enumerable.Range(0, range)
            //        .Select(col => (row == beeRow && col == beeCol) ? 'B' : matrix[row, col])));
            //}

        }
    }
}

