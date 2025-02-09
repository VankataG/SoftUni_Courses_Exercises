namespace GroceriesManagement
{
    public class GroceriesStore
    {
        public GroceriesStore(int capacity)
        {
            this.Capacity = capacity;
            this.Turnover = 0;
            this.Stall = new List<Product>();
        }
        public int Capacity { get; set; }
        public double Turnover { get; set; }
        public List<Product> Stall { get; set; }

        public void AddProduct(Product product)
        {
            if (Stall.Count < Capacity && !Stall.Contains(product))
                Stall.Add(product);
        }

        public bool RemoveProduct(string name) => Stall.Remove(Stall.FirstOrDefault(p => p.Name == name));
        
        public string SellProduct(string name, double quantity)
        {
            var product = Stall.Find(p => p.Name == name);
            if (product == null) return "Product not found";

            var totalPrice = product.Price * quantity;
            Turnover += totalPrice;
            return $"{product.Name} - {totalPrice:F2}$";
        }

        public string GetMostExpensive()
        {
            return Stall.OrderByDescending(p => p.Price).FirstOrDefault().ToString();
        }

        public string CashReport()
        {
            return $"Total Turnover: {Turnover:F2}$";
        }

        public string PriceList()
        {
            return "Groceries Price List:" +
                   Environment.NewLine +
                   string.Join(Environment.NewLine, Stall);
        }
    }
}
