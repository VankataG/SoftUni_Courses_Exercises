using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Models.Players;
using Handball.Repositories;

namespace Handball.Core
{
    public class Controller : IController
    {
        private List<string> playerTypes = new List<string>()
        {
            nameof(Goalkeeper),
            nameof(CenterBack),
            nameof(ForwardWing)
        };
        private PlayerRepository players = new PlayerRepository();
        private TeamRepository teams = new TeamRepository();
        public string NewTeam(string name)
        {
            if (teams.ExistsModel(name))
                return $"{name} is already added to the {nameof(TeamRepository)}.";

            teams.AddModel(new Team(name));
            return $"{name} is successfully added to the {nameof(TeamRepository)}.";
        }

        public string NewPlayer(string typeName, string name)
        {
            if (!playerTypes.Contains(typeName))
                return $"{typeName} is invalid position for the application.";

            IPlayer player = players.GetModel(name);
            if (player != null)
                return $"{name} is already added to the {nameof(PlayerRepository)} as {player.GetType().Name}.";

            player = CreatePlayer(typeName, name);
            players.AddModel(player);
            return $"{name} is filed for the handball league.";
        }


        public string NewContract(string playerName, string teamName)
        {
            IPlayer player = players.GetModel(playerName);
            ITeam team = teams.GetModel(teamName);

            if (player == null)
                return $"Player with the name {playerName} does not exist in the {nameof(PlayerRepository)}.";

            if (team == null)
                return $"Team with the name {teamName} does not exist in the {nameof(TeamRepository)}.";

            
            if (player.Team != null)
                return $"Player {playerName} has already signed with {player.Team}.";

            player.JoinTeam(teamName);
            team.SignContract(player);
            return $"Player {playerName} signed a contract with {teamName}.";
        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            ITeam firstTeam = teams.GetModel(firstTeamName);
            ITeam secondTeam = teams.GetModel(secondTeamName);

            if (firstTeam.OverallRating == secondTeam.OverallRating)
            {
                firstTeam.Draw();
                secondTeam.Draw();
                return $"The game between {firstTeamName} and {secondTeamName} ends in a draw!";
            }

            ITeam winner, loser;
            if (firstTeam.OverallRating > secondTeam.OverallRating)
            {
                winner = firstTeam;
                loser = secondTeam;
            }
            else
            {
                winner = secondTeam;
                loser = firstTeam;
            }

            winner.Win();
            loser.Lose();
            return $"Team {winner.Name} wins the game over {loser.Name}!";
        }

        public string PlayerStatistics(string teamName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"***{teamName}***");

            ITeam team = teams.GetModel(teamName);
            foreach (IPlayer player in team.Players
                         .OrderByDescending(p => p.Rating)
                         .ThenBy(p => p.Name))
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().Trim();
        }

        public string LeagueStandings()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***League Standings***");

            foreach (ITeam team in teams.Models
                         .OrderByDescending(t => t.PointsEarned)
                         .ThenByDescending(t => t.OverallRating)
                         .ThenBy(t => t.Name))
            {
                sb.AppendLine(team.ToString());
            }

            return sb.ToString().Trim();
        }

        private static IPlayer CreatePlayer(string typeName, string name)
        {
            return typeName switch
            {
                nameof(Goalkeeper) => new Goalkeeper(name),
                nameof(CenterBack) => new CenterBack(name),
                nameof(ForwardWing) => new ForwardWing(name),
            };
        }
    }
}
