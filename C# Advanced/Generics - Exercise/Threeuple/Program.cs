namespace Threeuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //First line
            string[] personData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string fullName = personData[0] + " " + personData[1];
            string adress = personData[2];
            string town = personData[3];

            Threeuple<string, string, string> tuple1 = new Threeuple<string, string, string>(fullName, adress, town);
            Console.WriteLine(tuple1.ToString());

            //Second line
            string[] personBeer = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = personBeer[0];
            int beer = int.Parse(personBeer[1]);
            bool isDrunk = personBeer[2] == "drunk";

            Threeuple<string, int, bool> tuple2 = new Threeuple<string, int, bool>(name, beer, isDrunk);
            Console.WriteLine(tuple2.ToString());

            //Third line
            string[] personBank = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            name = personBank[0];
            double balance = double.Parse(personBank[1]);
            string bankName = personBank[2];

            Threeuple<string, double, string> tuple3 = new Threeuple<string, double, string>(name, balance, bankName);
            Console.WriteLine(tuple3.ToString());
        }
    }
}
