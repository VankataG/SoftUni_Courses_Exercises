namespace PizzaCalories
{
    public class Dough
    {
        public Dough(string flourType, string bakingTechnique, double grams)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Grams = grams;
            Calories = (caloriesPerGram * grams) * modifier1 * modifier2;
        }
        private string flourType;

        public string FlourType
        {
            get { return flourType; }
            private set
            {
                if (value.ToLower() == "white")
                    modifier1 = 1.5;
                else if (value.ToLower() == "wholegrain")
                    modifier1 = 1.0;
                else
                    throw new ArgumentException("Invalid type of dough.");

                flourType = value;
            }
        }

        private string bakingTechnique;

        public string BakingTechnique
        {
            get { return bakingTechnique; }
            private set
            {
                if (value.ToLower() == "crispy")
                    modifier2 = 0.9;
                else if (value.ToLower() == "chewy")
                    modifier2 = 1.1;
                else if (value.ToLower() == "homemade")
                    modifier2 = 1.0;
                else
                    throw new ArgumentException("Invalid type of dough.");
                bakingTechnique = value;
            }
        }

        private double modifier1;
        private double modifier2;

        private double caloriesPerGram = 2;

        public double Calories { get; set; }

        private double grams;
        public double Grams
        {
            get { return grams; }
            set
            {
                if (value < 1 || value > 200)
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                grams = value;
            }
        }

    }
}
