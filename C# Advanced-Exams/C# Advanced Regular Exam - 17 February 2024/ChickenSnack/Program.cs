namespace ChickenSnack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> totalMoney = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Queue<int> prices = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int food = 0;
            while (prices.Count > 0 && totalMoney.Count > 0)
            {
                int money = totalMoney.Pop();
                int price = prices.Dequeue();

                if (money == price) food++;
                else if (money > price)
                {
                    food++;
                    money -= price;
                    if (totalMoney.Count > 0)
                        totalMoney.Push(totalMoney.Pop() + money);
                    else
                        totalMoney.Push(money);
                }
            }

            if (food == 0)
                Console.WriteLine("Henry remained hungry. He will try next weekend again.");
            else if (food == 1)
                Console.WriteLine($"Henry ate: 1 food.");
            else if (food < 4)
                Console.WriteLine($"Henry ate: {food} foods.");
            else
                Console.WriteLine($"Gluttony of the day! Henry ate {food} foods.");

        }
    }
}
