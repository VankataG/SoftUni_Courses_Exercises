namespace FootballTeamGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] commands = input.Split(";", StringSplitOptions.RemoveEmptyEntries);

                switch (commands[0])
                {
                    case "Team":
                        try
                        {
                            Team newTeam = new Team(commands[1]);
                            if (!teams.Contains(newTeam))
                                teams.Add(newTeam);
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case "Add":
                        string teamName = commands[1];
                        if (!teams.Any(t => t.Name == teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            continue;
                        }
                        string playerName = commands[2];
                        int endurance = int.Parse(commands[3]);
                        int sprint = int.Parse(commands[4]);
                        int dribble = int.Parse(commands[5]);
                        int passing = int.Parse(commands[6]);
                        int shooting = int.Parse(commands[7]);

                        try
                        {
                            Player newPlayer = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                            teams.Find(t => t.Name == teamName).AddPlayer(newPlayer);

                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case "Remove":
                        try
                        {
                            teams.Find(t => t.Name == commands[1]).RemovePlayer(commands[2]);
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case "Rating":
                        string team = commands[1];
                        if (!teams.Any(t => t.Name == team))
                        {
                            Console.WriteLine($"Team {team} does not exist.");
                            continue;
                        }

                        Console.WriteLine(teams.Find(t => t.Name == team));
                        break;
                }
            }
        }
    }
}
