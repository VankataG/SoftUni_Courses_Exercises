namespace _05._Shopping_Spree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new();
            List<Product> products = new();

            string[] inputPeople = Console.ReadLine().Split(';');
            for (int i = 0; i < inputPeople.Length; i++)
            {
                string[] personInfo = inputPeople[i].Split("=");
                people.Add(new Person(personInfo[0], decimal.Parse(personInfo[1])));
            }
            string[] inputProducts = Console.ReadLine().Split(';');
            for (int i = 0; i < inputProducts.Length; i++)
            {
                string[] productInfo = inputProducts[i].Split("=");
                products.Add(new Product(productInfo[0], decimal.Parse(productInfo[1])));
            }

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] info = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string name = info[0];
                string product = info[1];

                foreach (Person person in people)
                {
                    if (person.Name == name)
                    {
                        foreach (Product prod in products)
                        {
                            if (prod.Name == product)
                            {
                                if(person.Money >= prod.Cost)
                                {
                                    person.Money -= prod.Cost;
                                    person.Products.Add(prod);
                                    Console.WriteLine($"{person.Name} bought {prod.Name}");
                                }
                                else
                                {
                                    Console.WriteLine($"{person.Name} can't afford {prod.Name}");
                                }
                            }
                        }
                    }
                }
            }
            foreach (Person person in people)
            {
                if (person.Products.Count == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - {String.Join(", ", person.Products.Select(p => p.Name))}");
                }
            }
        }
    }
    public class Person
    {
        public string Name;
        public decimal Money;
        public List<Product> Products = new();
        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
        }

    }
    public class Product
    {
        public string Name;
        public decimal Cost;
        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }
    }

}
