namespace _09._SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> users = new();
            Dictionary<string, int> languages = new();

            string input;
            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] data = input.Split("-");
                string username = data[0];
                if (data[1] == "banned")
                {
                    users.Remove(username);
                }
                else
                {
                    string language = data[1];
                    int points = int.Parse(data[2]);

                    if (!users.ContainsKey(username))
                        users.Add(username, points);
                    else
                    {
                        if (users[username] < points)
                            users[username] = points;
                    }
                    if (!languages.ContainsKey(language))
                    {
                        languages[language] = 0;
                    }

                    languages[language]++;
                }
            }

            Console.WriteLine("Results:");
            foreach (var (user, points) in users.OrderByDescending(x => x.Value)
                         .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{user} | {points}");
            }

            Console.WriteLine("Submissions:");
            foreach (var (lang, count) in languages.OrderByDescending(x => x.Value)
                         .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{lang} - {count}");
            }
        }
    }
}
