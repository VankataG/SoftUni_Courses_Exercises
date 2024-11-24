using System.Text.RegularExpressions;

namespace _02._Ad_Astra
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Food> foodList = new List<Food>();
            string input = Console.ReadLine();
            string pattern = @"([#\|])(?<Name>[A-Za-z ]+)\1(?<Data>\d{2}\/\d{2}\/\d{2})\1(?<Calories>\d{1,5})\1";
            int totalCalories = 0;
            foreach (Match match in Regex.Matches(input, pattern))
            {
                string name = match.Groups["Name"].Value;
                string data = match.Groups["Data"].Value;
                int calories = int.Parse(match.Groups["Calories"].Value);
                totalCalories += calories;
                foodList.Add(new Food(name, data, calories));
            }
            Console.WriteLine($"You have food to last you for: {totalCalories / 2000} days!");
            foreach (Food food in foodList)
            {
                Console.WriteLine($"Item: {food.Name}, Best before: {food.Data}, Nutrition: {food.Calories}");
            }
        }
    }

    public class Food
    {
        public Food(string name, string data, int calories)
        {
            Name = name;
            Data = data;
            Calories = calories;
        }

        public int Calories { get; set; }

        public string Data { get; set; }

        public string Name { get; set; }
    }
}
