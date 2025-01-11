namespace PizzaCalories
{
    public class Pizza
    {
        public Pizza(string name, Dough dough)
        {
            Name = name;
            Dough = dough;
            Calories = dough.Calories;
        }
        public double Calories { get; set; }
        private string name;
        public string Name
        {
            get { return name;}
            set
            {
                if (String.IsNullOrEmpty(value) || value.Length > 15)
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                name = value;
            }
        }
        public Dough Dough { get; set; }
        public List<Topping> Toppings { get; set; } = new();

        public void AddTopping(Topping topping)
        {
            if (Toppings.Count >= 10)
                throw new ArgumentException("Number of toppings should be in range [0..10].");

            Toppings.Add(topping);
            Calories += topping.Calories;
        }
        

        public override string ToString()
        {
            return $"{this.Name} - {this.Calories:F2} Calories.";
        }
    }
}
