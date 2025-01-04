namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        public Coffee(string name,  double caffeine) : base(name, CoffeePrice,CoffeeMilliliters)
        {
            Caffeine = caffeine;
        }

        private const double CoffeeMilliliters  = 50;
        private const decimal CoffeePrice  = 3.50m ;
        public double Caffeine { get; set; }
    }
}
