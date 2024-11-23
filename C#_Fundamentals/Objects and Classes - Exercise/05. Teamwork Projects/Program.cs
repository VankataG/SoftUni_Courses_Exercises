namespace _05._Teamwork_Projects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams  = new();

            int teamCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < teamCount; i++)
            {
                string[] infos = Console.ReadLine().Split("-");
                string creator = infos[0];
                string teamName = infos[1];

                Team team = new Team(teamName, creator);
                Team sameTeam = teams.Find(x => x.Name == teamName);
                Team sameCreator = teams.Find(x => x.Creator == creator);

                if (sameTeam != null)
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }
                if (sameCreator != null)
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                    continue;
                }

                teams.Add(team);
                Console.WriteLine($"Team {teamName} has been created by {creator}!");
            }

            string input;
            while ((input = Console.ReadLine()) != "end of assignment")
            {
                string[] infos = input.Split("->");
                string user = infos[0];
                string team = infos[1];

                Team existingTeam = teams.Find(x => x.Name == team);
                Team memberInTeam = teams.Find(x => x.Members.Contains(user));
                Team creatorOfTeam = teams.Find(x => x.Creator == user);
                if (existingTeam == null)
                {
                    Console.WriteLine($"Team {team} does not exist!");
                    continue;
                }
                else if (memberInTeam != null || creatorOfTeam != null)
                {
                    Console.WriteLine($"Member {user} cannot join team {team}!");
                }
                else
                {
                    foreach ( Team teaM in teams)
                    {
                        if (teaM.Name == team)
                        {
                            teaM.Members.Add(user);
                        }
                    }
                }
            }
            List<Team> validTeams =teams.Where(x => x.Members.Count > 0).ToList();

            foreach (Team team in validTeams
                .OrderByDescending(x => x.Members.Count)
                .ThenBy(x => x.Name))
            {
                Console.WriteLine(team.Name);
                Console.WriteLine($"- {team.Creator}");
                foreach (string member in team.Members.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            List<Team> invalidTeams = teams.Where(x => x.Members.Count == 0)
                .OrderBy(x => x.Name)
                .ToList();
            Console.WriteLine("Teams to disband:");
            foreach (Team team in invalidTeams)
            {
                Console.WriteLine(team.Name);
            }
        }
    }
    public class Team
    {
        public Team(string name, string creator)
        {
            Name = name;
            Creator = creator;
            Members = new();
        }
        public string Name { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }


    }
    

}
