namespace Restaurant
{
    public class Cake : Dessert
    {
        public Cake(string name) : base(name, Price, Grams, Calories)
        {
          
        }

        private const double Grams = 250;
        private const double Calories = 1000;
        private const decimal Price = 5;
    }
}
