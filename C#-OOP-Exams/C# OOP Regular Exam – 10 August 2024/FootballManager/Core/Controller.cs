using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using FootballManager.Core.Contracts;
using FootballManager.Models;
using FootballManager.Models.Contracts;
using FootballManager.Models.Managers;
using FootballManager.Repositories;

namespace FootballManager.Core
{
    public class Controller : IController
    {
        private TeamRepository championship = new TeamRepository();
        private List<string> typeNamesList = new List<string>()
        {
            "AmateurManager",
            "SeniorManager",
            "ProfessionalManager"
        };
        public string JoinChampionship(string teamName)
        {
            if (championship.Models.Count == 10)
                return $"Championship is full!";

            if (championship.Exists(teamName))
                return $"{teamName} has already joined the Championship.";

            championship.Add(new Team(teamName));
            return $"{teamName} has successfully joined the Championship.";
        }

        public string SignManager(string teamName, string managerTypeName, string managerName)
        {
            if (!championship.Exists(teamName))
                return $"Team {teamName} does not take part in the Championship.";

            if (!typeNamesList.Contains(managerTypeName))
                return $"{managerTypeName} is an invalid manager type for the application.";

            ITeam team = championship.Get(teamName);
            if (team.TeamManager is not null)
                return $"Team {teamName} has already signed a contract with {team.TeamManager.Name}.";

            if (championship.Models.Any(t => t.TeamManager != null && t.TeamManager.Name == managerName))
                return $"Manager {managerName} is already assigned to another team.";

            IManager manager = CreateManager(managerTypeName, managerName);

            team.SignWith(manager);
            return $"Manager {managerName} is assigned to team {teamName}.";
        }

        private IManager CreateManager(string managerTypeName, string managerName)
        {
            return managerTypeName switch
            {
                "AmateurManager" => new AmateurManager(managerName),
                "SeniorManager" => new SeniorManager(managerName),
                "ProfessionalManager" => new ProfessionalManager(managerName),
                _ => throw new ArgumentException("Invalid manager type.")
            };
        }

        public string MatchBetween(string teamOneName, string teamTwoName)
        {
            if (!championship.Exists(teamOneName) || !championship.Exists(teamTwoName))
                return $"This match does not meet the regulation rules of the Championship.";

            ITeam teamOne = championship.Get(teamOneName);
            ITeam teamTwo = championship.Get(teamTwoName);


            ITeam winner = teamOne;
            ITeam loser = teamTwo;
            if (teamOne.PresentCondition < teamTwo.PresentCondition)
            {
                winner = teamTwo;
                loser = teamOne;
            }
            else if (teamOne.PresentCondition == teamTwo.PresentCondition)
            {
                teamOne.GainPoints(1);
                teamTwo.GainPoints(1);
                return $"The match between {teamOneName} and {teamTwoName} ends in a draw.";
            }

            //ITeam winner = teamOne.PresentCondition > teamTwo.PresentCondition ? teamOne : teamTwo;
            //ITeam loser = winner == teamOne ? teamTwo : teamOne;

            winner.GainPoints(3);
            if (winner.TeamManager != null)
                winner.TeamManager.RankingUpdate(5);
            if (loser.TeamManager != null)
                loser.TeamManager.RankingUpdate(-5);

            return $"Team {winner.Name} wins the match against {loser.Name}.";
        }

        public string PromoteTeam(string droppingTeamName, string promotingTeamName, string managerTypeName, string managerName)
        {
            if (!championship.Exists(droppingTeamName))
                return $"Team {droppingTeamName} does not exist in the Championship.";

            if (championship.Exists(promotingTeamName))
                return $"{promotingTeamName} has already joined the Championship.";

            ITeam team = new Team(promotingTeamName);



            if (!typeNamesList.Contains(managerTypeName))
                return $"{managerTypeName} is an invalid manager type for the application.";

            bool managerAlreadyAssigned = championship.Models.Any(t => t.TeamManager?.Name == managerName);

            if (!managerAlreadyAssigned)
            {
                IManager manager = CreateManager(managerTypeName, managerName);
                team.SignWith(manager);
            }

            foreach (ITeam model in championship.Models)
            {
                model.ResetPoints();
            }

            championship.Remove(droppingTeamName);
            championship.Add(team);
            return $"Team {promotingTeamName} wins a promotion for the new season.";
        }

        public string ChampionshipRankings()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("***Ranking Table***");
            int counter = 1;

            foreach (ITeam team in championship.Models  
                         .OrderByDescending(t => t.ChampionshipPoints)
                         .ThenByDescending(t => t.PresentCondition)
                         .ToList())
            {
                sb.AppendLine($"{counter++}. {team}/{team.TeamManager.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
 