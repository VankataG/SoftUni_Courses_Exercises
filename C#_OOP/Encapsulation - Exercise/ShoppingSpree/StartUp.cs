namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Create lists for people and product
            List<Person> peopleList = new List<Person>();
            List<Product> productsList = new List<Product>();


            //Populating People List with the given information
            string[] peopleInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries).ToArray();
            foreach (var input in peopleInput)
            {
                string[] personData = input.Split("=", StringSplitOptions.RemoveEmptyEntries);
                string name = personData[0];
                int money = int.Parse(personData[1]);
                try
                {
                    Person person = new Person(name, money);
                    peopleList.Add(person);
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                    return;
                }
            }


            //Populating Product List with the given information
            string[] productInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries).ToArray();
            foreach (var input in productInput)
            {
                string[] productData = input.Split("=", StringSplitOptions.RemoveEmptyEntries);
                string name = productData[0];
                int cost = int.Parse(productData[1]);
                try
                {
                    Product product = new Product(name, cost);
                    productsList.Add(product);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    return;
                }
                
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandData = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = commandData[0];
                string product = commandData[1];

                Person currPerson = peopleList.Find(p => p.Name == name);
                Product currProduct = productsList.Find(p => p.Name == product);

                currPerson.BuyProduct(currProduct);
            }

            foreach (Person person in peopleList)
            {
                Console.WriteLine(person);
            }
        }
    }
}
