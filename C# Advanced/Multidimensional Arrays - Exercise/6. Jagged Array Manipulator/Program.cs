namespace _6._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Read jagged array data and create it
            int rowsCount = int.Parse(Console.ReadLine());
            int[][] jaggedArr = new int[rowsCount][];

            //Populate the array by info
            for (int row = 0; row < rowsCount; row++)
            {
                jaggedArr[row] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }
            //Analyze and change array
            for (int row = 0; row < rowsCount - 1; row++)
            {
                if (jaggedArr[row].Length == jaggedArr[row + 1].Length)
                {
                    for (int col = 0; col < jaggedArr[row].Length; col++)
                    {
                        jaggedArr[row][col] *= 2;
                        jaggedArr[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jaggedArr[row].Length; col++)
                    {
                        jaggedArr[row][col] /= 2;
                    }
                    for (int col = 0; col < jaggedArr[row + 1].Length; col++)
                    {
                        jaggedArr[row + 1][col] /= 2;
                    }
                }
            }

            //Read commands and apply them to the jagged array
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(commands[1]);
                int col = int.Parse(commands[2]);
                int value = int.Parse(commands[3]);
                if (row >= 0 && row < rowsCount && col >= 0 && col < jaggedArr[row].Length) //check if everything is valid
                {
                    switch (commands[0])
                    {
                        case "Add":
                            jaggedArr[row][col] += value;
                            break;
                        case "Subtract":
                            jaggedArr[row][col] -= value;
                            break;
                    }
                }
            }

            //Print the final state of the jagged array
            foreach (var row in jaggedArr)
            {
                Console.WriteLine(String.Join(" ", row));
            }
        }
    }
}
