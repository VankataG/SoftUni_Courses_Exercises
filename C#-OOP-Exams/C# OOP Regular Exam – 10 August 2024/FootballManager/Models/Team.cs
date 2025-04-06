using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballManager.Models.Contracts;
using FootballManager.Utilities.Messages;

namespace FootballManager.Models
{
    public class Team : ITeam
    {
        private string name;

        public Team(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.TeamNameNull);
                name = value;
            }
        }
        public int ChampionshipPoints { get; private set; }
        public IManager TeamManager { get; private set; }

        public int PresentCondition
        {
            get
            {
                if (TeamManager == null) return 0;

                if (ChampionshipPoints == 0)  return (int)Math.Floor(TeamManager.Ranking);

                return (int)Math.Floor(ChampionshipPoints * TeamManager.Ranking);
            }
          
        }

        public void SignWith(IManager manager)
        {
            this.TeamManager = manager;
        }

        public void GainPoints(int points)
        {
            this.ChampionshipPoints += points;
        }

        public void ResetPoints()
        {
            this.ChampionshipPoints = 0;
        }

        public override string ToString()
        {
            return $"Team: {this.Name} Points: {this.ChampionshipPoints}";
        }
       
    }
}
