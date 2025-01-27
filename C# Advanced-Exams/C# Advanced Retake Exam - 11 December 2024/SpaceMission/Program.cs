namespace SpaceMission
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int spaceField = int.Parse(Console.ReadLine());

            int resources = 100;
            int locationRow = -1;
            int locationCol = -1;

            //Read the matrix
            string[,] matrix = new string[spaceField, spaceField];
            for (int i = 0; i < spaceField; i++)
            {
                string[] symbols = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < spaceField; j++)
                {
                    matrix[i, j] = symbols[j];
                    if (matrix[i, j] == "S")
                    {
                        locationRow = i;
                        locationCol = j;
                        matrix[i, j] = ".";
                    }
                }
            }


            int lastPosRow = -1;
            int lastPosCol = -1;

            bool reachedEryndor = false;
            bool outOfSpace = false;
            bool strandedInSpace = false;

            while (!reachedEryndor || resources >= 5)
            {
                string command = Console.ReadLine();
                resources -= 5;
                if (resources < 0)
                {
                    strandedInSpace = true;
                    break;
                }
                
                switch (command)
                {
                    case "up":
                        locationRow--;
                        if (locationRow < 0)
                        {
                            lastPosRow = locationRow + 1;
                            lastPosCol = locationCol;
                            outOfSpace = true;
                        } 
                        break;

                    case "down":
                        locationRow++;
                        if (locationRow > spaceField - 1)
                        {
                            lastPosRow = locationRow - 1;
                            lastPosCol = locationCol;
                            outOfSpace = true;
                        }
                            
                        break;

                    case "left":
                        locationCol--;
                        if (locationCol < 0)
                        {
                            lastPosRow = locationRow;
                            lastPosCol = locationCol + 1;
                            outOfSpace = true;
                        }
                            
                        break;

                    case "right":
                        locationCol++;
                        if (locationCol > spaceField - 1)
                        {
                            lastPosRow = locationRow;
                            lastPosCol = locationCol- 1;
                            outOfSpace = true;
                        }
                            
                        break;
                }

                if (outOfSpace)
                    break;

                if (matrix[locationRow, locationCol] == "R")
                {
                    resources += 10;
                    if (resources > 100)
                        resources = 100;
                }
                else if (matrix[locationRow, locationCol] == "M")
                {
                    resources -= 5;
                    matrix[locationRow, locationCol] = ".";
                    if (resources <= 0)
                    {
                        strandedInSpace = true;
                        break;
                    }
                }
                else if (matrix[locationRow, locationCol] == "P")
                {
                    reachedEryndor = true;
                    break;
                }
            }

            if (reachedEryndor)
            {
                Console.WriteLine($"Mission accomplished! The spaceship reached Planet Eryndor with {resources} resources left.");
            }
            else if (strandedInSpace)
            {
                Console.WriteLine("Mission failed! The spaceship was stranded in space.");
                matrix[locationRow, locationCol] = "S";
            }
            else if (outOfSpace)
            {
                Console.WriteLine("Mission failed! The spaceship was lost in space.");
                matrix[lastPosRow, lastPosCol] = "S";
            }

           

            for (int i = 0; i < spaceField; i++)
            {
                for (int j = 0; j < spaceField; j++)
                {
                    Console.Write(matrix[i ,j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
