namespace _01._Advertisement_Message
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Add add = new Add();
                Console.WriteLine(add.Random());
            }
        }
    }
    public class Add
    {
        public readonly string[] Phrases =
            {
            "Excellent product.",
            "Such a great product.",
            "I always use that product.",
            "Best product of its category.",
            "Exceptional product.",
            "I can't live without this product."
        };
        public readonly string[] Events =
        {
            "Now I feel good.",
            "I have succeeded with this product.",
            "Makes miracles. I am happy of the results!",
            "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.",
            "I feel great!"
        };
        public readonly string[] Authors =
        {
            "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"
        };
        public readonly string[] Cities =
        {
            "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"

        };
        public string Random()
        {
            Random random = new();
            int index = random.Next(Phrases.Length);
            string phrase = Phrases[index];
            index = random.Next(Events.Length);
            string event1 = Events[index];
            index = random.Next(Authors.Length);
            string author = Authors[index];
            index = random.Next(Cities.Length);
            string city = Cities[index];

            return $"{phrase} {event1} {author} – {city}.";
        }
    }
}
