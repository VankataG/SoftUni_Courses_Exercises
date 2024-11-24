using System.Xml;

namespace _03._Bakery_Shop
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Dictionary<string, int> foodList = new();
            string input;
            int totalSold = 0;
            while ((input = Console.ReadLine()) != "Complete")
            {
                string[] commands = input.Split();
                int quantity = int.Parse(commands[1]);
                string food = commands[2];
                switch (commands[0])
                {
                    case "Receive":
                        if (quantity <= 0) continue;
                        if (!foodList.ContainsKey(food))
                        {
                            foodList.Add(food, 0);
                        }

                        foodList[food] += quantity;
                        break;
                    case "Sell":
                        if (!foodList.ContainsKey(food))
                        {
                            Console.WriteLine(($"You do not have any {food}."));
                        }
                        else
                        {
                            if (quantity > foodList[food])
                            {
                                Console.WriteLine($"There aren't enough {food}. You sold the last {foodList[food]} of them.");
                                totalSold += foodList[food];
                                foodList.Remove(food);
                            }
                            else
                            {
                                foodList[food] -= quantity;
                                totalSold += quantity;
                                Console.WriteLine($"You sold {quantity} {food}.");
                                if (foodList[food] == 0)
                                {
                                    foodList.Remove(food);
                                }
                            }
                        }

                        break;
                }
            }

            foreach ((string food, int quantity) in foodList)
            {
                Console.WriteLine($"{food}: {quantity}");
            }
            Console.WriteLine($"All sold: {totalSold} goods");
        }
    }

    public class Food
    {
        public Food(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
        public string Name;
        public int Quantity;

    }
}
