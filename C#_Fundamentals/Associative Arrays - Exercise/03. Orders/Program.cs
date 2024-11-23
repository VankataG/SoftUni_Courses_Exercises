namespace _03._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Product> productsPrices = new();
            string input;
            while ((input = Console.ReadLine()) != "buy")
            {
                string[] infos = input.Split();
                string name = infos[0];
                double price = double.Parse(infos[1]);
                int quantity = int.Parse(infos[2]);

                Product product = new Product(name, price, quantity);
                if (!productsPrices.ContainsKey(name))
                {
                    productsPrices.Add(name, product);
                }
                else
                {
                    productsPrices[name].Price = price;
                    productsPrices[name].Quantity += quantity;
                }
            }
            foreach ((string product, Product prices) in productsPrices)
            {
                Console.WriteLine($"{product} -> {prices.Quantity * prices.Price:f2}");
            }
        }
    }
    public class Product
    {
        public Product(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }


    }

}
