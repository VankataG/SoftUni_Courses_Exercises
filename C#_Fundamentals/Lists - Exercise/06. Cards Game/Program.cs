namespace _06._Cards_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> p1Cards = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> p2Cards = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (p1Cards.Count > 0 && p2Cards.Count > 0) 
            {
                if (p1Cards[0] > p2Cards[0])
                {
                    p1Cards.Add(p2Cards[0]);
                    p1Cards.Add(p1Cards[0]);
                    RemoveHand(p1Cards, p2Cards);
                }
                else if (p1Cards[0] < p2Cards[0])
                {
                    p2Cards.Add(p1Cards[0]);
                    p2Cards.Add(p2Cards[0]);
                    RemoveHand(p1Cards, p2Cards);
                }
                else
                {
                    RemoveHand(p1Cards, p2Cards);
                }
            }
            string player ="";
            int result = 0;
            if (p1Cards.Count == 0)
            {
                player = "Second";
                result = p2Cards.Sum();
            }
            else if (p2Cards.Count == 0)
            {
                player = "First";
                result = p1Cards.Sum();
            }
            Console.WriteLine($"{player} player wins! Sum: {result}");
        }

        private static void RemoveHand(List<int> p1Cards, List<int> p2Cards)
        {
            p1Cards.RemoveAt(0);
            p2Cards.RemoveAt(0);
        }
    }
}
