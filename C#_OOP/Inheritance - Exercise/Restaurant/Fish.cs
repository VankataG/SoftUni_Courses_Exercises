using System.Runtime.CompilerServices;

namespace Restaurant
{
    public class Fish : MainDish
    {
        public Fish(string name, decimal price) : base(name, price, Grams)
        {
            
        }
        private const double Grams = 22;
        
    }
}
