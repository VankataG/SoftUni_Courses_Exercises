namespace _8._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> vehicles = new Queue<string>();
            int totalPassed = 0;

            int n = int.Parse(Console.ReadLine());
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                if (input == "green")
                {
                    if (n > vehicles.Count) n = vehicles.Count;
                    for (int i = 0; i < n; i++)
                    {
                        totalPassed++;
                        Console.WriteLine($"{vehicles.Dequeue()} passed!");
                    }
                }
                else
                {
                    vehicles.Enqueue(input);
                }
            }

            Console.WriteLine($"{totalPassed} cars passed the crossroads.");
        }
    }
}
