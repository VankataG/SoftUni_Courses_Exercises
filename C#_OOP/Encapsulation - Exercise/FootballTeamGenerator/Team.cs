namespace FootballTeamGenerator
{
    public class Team
    {
        public Team(string name)
        {
            this.Name = name;
        }
		private string name;

		public string Name
		{
			get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value == " ")
                    throw new ArgumentException("A name should not be empty.");
                name = value;
            }
		}

        private List<Player> Players { get; set; } = new List<Player>();

        public double Rating
        {
            get { return GetRating(); }

        }

        public void AddPlayer(Player player)
        {
            if(!Players.Contains(player))
                Players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            if (!Players.Any(p => p.Name == playerName))
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");

            Player playerToRemove = Players.Find(p => p.Name == playerName);
            Players.Remove(playerToRemove);
        }


        private double GetRating()
        {
            if (Players.Count == 0)
                return 0;

            double result = 0;
            foreach (Player player in Players)
            {
                result += player.skillLevel;
            }

            result /= Players.Count;
            return result;
        }

        public override string ToString()
        {
            
            return $"{this.Name} - {Math.Round(this.Rating)}";
        }
    }
}
