using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        public Person(string name, int money)
        {
            this.Name = name;
			this.Money = money;
            this.Products = new List<Product>();
        }
		private string name;

		public string Name
		{
			get { return name; }
            private set
            {
                if (String.IsNullOrEmpty(value) || value == " ")
                    throw new ArgumentException("Name cannot be empty");
                name = value;
            }
		}

		private int money;

		public int Money
		{
			get { return money; }
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Money cannot be negative");
                money = value;
            }
		}

		public List<Product> Products { get; set; }

        public void BuyProduct(Product product)
        {
            if (this.Money >= product.Cost)
            {
                this.Products.Add(product);
                this.Money -= product.Cost;
                Console.WriteLine($"{this.Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
        }

        public override string ToString()
        {
            StringBuilder result = new();

            result.Append($"{this.Name} - ");
            if (this.Products.Count == 0)
                result.Append("Nothing bought");
            else
                result.Append(String.Join(", ", this.Products));


            return result.ToString();
        }
    }
}
