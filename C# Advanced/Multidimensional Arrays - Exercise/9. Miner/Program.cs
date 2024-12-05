namespace _9._Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int totalCoal = 0;
            int locationRow = 0;
            int locationCol = 0;

            //Read matrix data
            int dimensions = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[,] matrix = new string[dimensions, dimensions];
            
            //Populate the matrix
            for (int row = 0; row < dimensions; row++)
            {
                string[] inputs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    
                for (int col = 0; col < dimensions; col++)
                {
                    matrix[row, col] = inputs[col];
                    if (inputs[col] == "c")
                        totalCoal++;
                    else if (inputs[col] == "s")
                    {
                        locationRow = row;
                        locationCol = col;
                    }
                }
            }

            //Read the commands and process them
            bool endGame = false;
            bool winGame = false;
            
            foreach (string command in commands)
            {
                switch (command)
                {
                    case "left":
                        if (locationCol > 0) 
                            locationCol --;
                        break;
                    case "right":
                        if (locationCol < dimensions - 1)
                            locationCol++;
                        break;
                    case "up":
                        if (locationRow  > 0)
                            locationRow --;
                        break;
                    case "down":
                        if (locationRow < dimensions - 1)
                            locationRow++;
                        break;
                }

                //Check your current location 
                if (matrix[locationRow, locationCol] == "c")
                {
                    totalCoal--;
                    matrix[locationRow, locationCol] = "*";
                    if (totalCoal == 0)
                    {
                        winGame = true;
                        break;
                    }
                }
                    
                else if (matrix[locationRow, locationCol] == "e")
                {
                    endGame = true;
                    break;
                }
            }
            //Print 
            if (endGame)
            {
                Console.WriteLine($"Game over! ({locationRow}, {locationCol})");
            }
            else if (winGame)
            {
                Console.WriteLine($"You collected all coals! ({locationRow}, {locationCol})");
            }
            else
            {
                Console.WriteLine($"{totalCoal} coals left. ({locationRow}, {locationCol})");
            }
        }
    }
}
