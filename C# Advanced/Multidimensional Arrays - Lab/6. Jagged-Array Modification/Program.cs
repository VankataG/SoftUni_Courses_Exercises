namespace _6._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Read matrix
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArr = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                jaggedArr[row] = Console.ReadLine().Split().Select(int.Parse).ToArray(); 
            }

            //Modify the matrix
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                //Get coordinates from console
                string[] commands = input.Split();
                int row = int.Parse(commands[1]);   
                int col = int.Parse(commands[2]);
                int value = int.Parse(commands[3]);

                
                if (row >= 0 && row < rows && col >= 0 && col < jaggedArr[row].Length)           //Check the coordinates
                {
                    switch (commands[0])
                    {
                        case "Add":
                            jaggedArr[row][col] += value;       //Add given value
                            break;
                        case "Subtract":
                            jaggedArr[row][col] -= value;      //Subtract given value
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
            }

            //Print the modified matrix
            foreach (var row in jaggedArr)
            {
                Console.WriteLine(String.Join(" ", row));
            }
        }
    }
}
