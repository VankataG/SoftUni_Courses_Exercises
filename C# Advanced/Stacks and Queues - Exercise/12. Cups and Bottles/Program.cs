namespace _12._Cups_and_Bottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> waterBottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            int wastedWater = 0;

            while (true)
            {
                if (cups.Count == 0 || waterBottles.Count == 0) break;

                int currCup = cups.Peek();
                int currBottle = waterBottles.Peek();
                if (currCup > currBottle)
                {
                    while (currCup > 0)
                    {
                        currCup -= waterBottles.Pop();
                    }

                    cups.Dequeue();
                    wastedWater += Math.Abs(currCup);
                }
                else
                {
                    cups.Dequeue();
                    waterBottles.Pop();
                    wastedWater += currBottle - currCup;
                }
            }

            if (cups.Count == 0)
            {
                Console.WriteLine($"Bottles: {String.Join(" ", waterBottles.Reverse())}");
            }
            else if (waterBottles.Count == 0)
            {
                Console.WriteLine($"Cups: {String.Join(" ", cups)}");
            }
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
