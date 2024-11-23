namespace Lists___Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int maxWagonCapacity = int.Parse(Console.ReadLine());

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] inputs = input.Split().ToArray();

                if (inputs[0] == "Add")
                {
                    int passengers = int.Parse(inputs[1]);
                    wagons.Add(passengers);
                }
                else
                {
                    int passengers = int.Parse(inputs[0]);
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i] + passengers <= maxWagonCapacity)
                        {
                            wagons[i] += passengers;
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(String.Join(" ", wagons));
        }
    }
}
