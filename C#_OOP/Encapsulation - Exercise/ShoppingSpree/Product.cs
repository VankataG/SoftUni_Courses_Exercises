namespace ShoppingSpree
{
    public class Product
    {
        public Product(string name, int cost)
        {
            this.Name = name;
            this.Cost = cost;
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
		private int cost;

		public int Cost
		{
			get { return cost; }
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Money cannot be negative");
                cost = value;
            }
		}

        public override string ToString()
        {
            return this.Name;
        }
    }
}
