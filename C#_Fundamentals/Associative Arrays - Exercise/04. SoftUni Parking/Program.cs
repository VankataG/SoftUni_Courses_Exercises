namespace _04._SoftUni_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> usersPlates = new();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split();
                string username = commands[1];
                switch (commands[0])
                {
                    case "register":
                        string licensePlate = commands[2];
                        if (usersPlates.ContainsKey(username))
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {usersPlates[username]}");
                        }
                        else
                        {
                            usersPlates.Add(username, licensePlate);
                            Console.WriteLine($"{username} registered {licensePlate} successfully");
                        }
                        break;

                    case "unregister":
                        if (!usersPlates.ContainsKey(username))
                        {
                            Console.WriteLine($"ERROR: user {username} not found");
                        }
                        else
                        {
                            usersPlates.Remove(username);
                            Console.WriteLine($"{username} unregistered successfully");
                        }
                        break;

                }
            }
            foreach ((string user, string plate) in usersPlates)
            {
                Console.WriteLine($"{user} => {plate}");
            }
        }
    }
}
