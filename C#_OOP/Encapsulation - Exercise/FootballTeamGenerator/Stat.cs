namespace FootballTeamGenerator
{
    public class Stat
    {
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

        private int value;
        public int Value
        {
            get { return this.value; }
            private set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException($"{this.Name} should be between 0 and 100.");
                this.value = value;
            }
        }
    }
}
