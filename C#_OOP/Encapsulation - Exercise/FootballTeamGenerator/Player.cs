using System.Runtime.CompilerServices;

namespace FootballTeamGenerator
{
    public class Player
    {
        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;

        }

        public double skillLevel
        {
            get
            {
                return (endurance + sprint + dribble + passing + shooting) / 5.0;
            }
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

        private int endurance;
        public int Endurance
        {
            get { return this.endurance; }
            private set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException($"Endurance should be between 0 and 100.");
                this.endurance = value;
            }
        }

        private int sprint;
        public int Sprint
        {
            get { return this.sprint; }
            private set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException($"Sprint should be between 0 and 100.");
                this.sprint = value;
            }
        }
        private int dribble;
        public int Dribble
        {
            get { return this.dribble; }
            private set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException($"Dribble should be between 0 and 100.");
                this.dribble = value;
            }
        }
        private int passing;
        public int Passing
        {
            get { return this.passing; }
            private set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException($"Passing should be between 0 and 100.");
                this.passing = value;
            }
        }

        private int shooting;
        public int Shooting
        {
            get { return this.shooting; }
            private set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException("Shooting should be between 0 and 100.");
                this.shooting = value;
            }
        }

    }
}