namespace _05._Cities_by_Continent_and_Country
{
    internal class Program
    {
        /*
           9
           Europe Bulgaria Sofia
           Asia China Beijing
           Asia Japan Tokyo
           Europe Poland Warsaw
           Europe Germany Berlin
           Europe Poland Poznan
           Europe Bulgaria Plovdiv
           Africa Nigeria Abuja
           Asia China Shanghai
         */
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> map = new();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(" ");
                string continent = info[0];
                string country = info[1];
                string city = info[2];
                if (!map.ContainsKey(continent))
                    map[continent] = new Dictionary<string, List<string>>();
                
                if (!map[continent].ContainsKey(country))
                    map[continent][country] = new List<string>();

                map[continent][country].Add(city);
            }

            foreach (string continent in map.Keys)
            {
                Console.WriteLine($"{continent}:");
                foreach ((var country, var cities)in map[continent])
                {
                    Console.WriteLine($"{country} -> {String.Join(", ", cities)}");
                }
            }
        }
    }
}
