using System.Globalization;
namespace _04._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shopsProductMap = new();
            string input;
            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] info = input.Split(", ");
                string shop = info[0];
                string product = info[1];
                double price = double.Parse(info[2], CultureInfo.InvariantCulture);

                if (!shopsProductMap.ContainsKey(shop))
                {
                    shopsProductMap[shop] = new Dictionary<string, double>();
                }

                shopsProductMap[shop].Add(product, price);
            }

            foreach (var shop in shopsProductMap.Keys)
            {
                Console.WriteLine($"{shop}->");
                foreach (var product in shopsProductMap[shop])
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
            
        }
    }
}
