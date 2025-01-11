namespace PizzaCalories
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pizzaName = Console.ReadLine().Split()[1];

            string[] doughData = Console.ReadLine().Split();
            Dough dough;
            try
            {
                 dough = new Dough(doughData[1], doughData[2], double.Parse(doughData[3]));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            Pizza pizza;
            try
            {
                 pizza = new Pizza(pizzaName, dough);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            

            List<Topping> toppings = new();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] toppingData = input.Split();
                try
                {
                    Topping topping = new Topping(toppingData[1], double.Parse(toppingData[2]));
                    pizza.AddTopping(topping);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            Console.WriteLine(pizza);
        }
    }
}
