namespace PizzaCalories
{
    public class Topping
    {
        public Topping(string type, double grams)
        {
            this.Type = type;
            this.Grams = grams;
            this.Calories = (caloriesPerGram * grams) * modifier;
        }
        private double caloriesPerGram = 2;
        private double modifier;
        public double Calories { get; set; }

        private string type;

        public string Type
        {
            get { return type; }
            private set
            {
                if (value.ToLower() == "meat")
                    modifier = 1.2;
                else if (value.ToLower() == "veggies")
                    modifier = 0.8;
                else if (value.ToLower() == "cheese")
                    modifier = 1.1;
                else if (value.ToLower() == "sauce")
                    modifier = 0.9;
                else
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                type = value;
            }
        }
        private double grams;

        public double Grams
        {
            get { return grams; }
            private set
            {
                if (value < 1 || value > 50)
                    throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
                grams = value;
            }
        }


    }
}
