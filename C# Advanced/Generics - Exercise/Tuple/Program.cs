namespace Tuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //First line
            string[] personData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string fullName = personData[0] + " " + personData[1];
            string adress = personData[2];

            Tuple<string, string> tuple1 = new Tuple<string, string>(fullName, adress);
            Console.WriteLine(tuple1.ToString());

            //Second line
            string[] personBeer = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = personBeer[0];
            int beer = int.Parse(personBeer[1]);

            Tuple<string, int> tuple2 = new Tuple<string, int>(name, beer);
            Console.WriteLine(tuple2.ToString());

            //Third line
            string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int num1 = int.Parse(numbers[0]);
            double num2 = double.Parse(numbers[1]);

            Tuple<int, double> nums = new Tuple<int, double>(num1, num2);
            Console.WriteLine(nums.ToString());
        }
    }
}
