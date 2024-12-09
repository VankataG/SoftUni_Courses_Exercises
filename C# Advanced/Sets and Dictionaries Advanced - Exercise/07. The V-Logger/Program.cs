namespace _07._The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Vlogger> vloggers = new();
            string input;
            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string vlogger = commands[0];
                switch (commands[1])
                {
                    case "joined":
                        if (!vloggers.ContainsKey(vlogger))
                        {
                            vloggers[vlogger] = new Vlogger(vlogger);
                        }
                        break;
                    case "followed":
                        string followed = commands[2];
                        if (vloggers.ContainsKey(vlogger) && vloggers.ContainsKey(followed) && 
                            vlogger != followed && !vloggers[vlogger].Following.Contains(followed))
                        {
                            vloggers[vlogger].Following.Add(followed);

                            vloggers[followed].Followers.Add(vlogger);
                        }
                        break;
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
            int pos = 1;
            foreach (var vlogger in vloggers.Values.OrderByDescending(x => x.Followers.Count)
                         .ThenBy(x => x.Following.Count))
            {
                Console.WriteLine($"{pos}. {vlogger.Name} : {vlogger.Followers.Count} followers, {vlogger.Following.Count} following");
                if (pos == 1)
                {
                    foreach (var follower in vlogger.Followers.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                pos++;
            }
        }
    }

    public class Vlogger
    {
        public Vlogger(string name)
        {
            Name = name;
            Following = new List<string>();
            Followers = new List<string>();
        }
        public string Name { get; set; }
        public List<string> Followers { get; set; }
        public List<string> Following { get; set; }
    }
}
