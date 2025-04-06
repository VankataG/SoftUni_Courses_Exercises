using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Models
{
    public abstract class Diver : IDiver
    {
        private string name;
        private int oxygenLevel;
        private readonly List<string> _catch = new List<string>();
        private double competitionPoints;


        protected Diver(string name, int oxygenLevel)
        {
            this.Name = name;
            this.OxygenLevel = oxygenLevel;
            this.Catch = _catch.AsReadOnly();
            this.CompetitionPoints = 0;
            this.HasHealthIssues = false;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.DiversNameNull);
                name = value;
            }
        }

        public int OxygenLevel
        {
            get => oxygenLevel;
            protected set
            {
                if (value < 0)
                {
                    value = 0;
                }

                oxygenLevel = value;
            }
        }
        public IReadOnlyCollection<string> Catch { get; }

        public double CompetitionPoints
        {
            get => competitionPoints;
            private set => competitionPoints = Math.Round(value, 1);
        }
        public bool HasHealthIssues { get; private set; }
        public void Hit(IFish fish)
        {
            this.OxygenLevel -= fish.TimeToCatch;
            _catch.Add(fish.Name);
            this.CompetitionPoints += fish.Points;
        }

        public abstract void Miss(int TimeToCatch);

        public void UpdateHealthStatus()
        {
            this.HasHealthIssues = !this.HasHealthIssues;
        }

        public abstract void RenewOxy();

        public override string ToString()
        {
            return $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {Catch.Count}, Points earned: {CompetitionPoints} ]";
        }

    }
}
