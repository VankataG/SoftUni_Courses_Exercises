namespace _02._The_Lift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int people = int.Parse(Console.ReadLine());
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();

            for (int i = 0; i < wagons.Count; i++)
            {
                if (people > 4 - wagons[i])
                {
                    people -= 4 - wagons[i];
                    wagons[i] = 4;
                }
                else
                {
                    wagons[i] += people;
                    people = 0;
                    
                }
            }
            if (people == 0 && wagons[wagons.Count -1] == 4)
            {
                
                Console.WriteLine(String.Join(" ", wagons));
            }
            else if (people == 0)
            {
                Console.WriteLine("The lift has empty spots!");
                Console.WriteLine(String.Join(" ", wagons));
            }
            else
            {
                Console.WriteLine($"There isn't enough space! {people} people in a queue!");
                Console.WriteLine(String.Join(" ", wagons));
            }
        }
    }
}
