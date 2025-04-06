using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;

namespace HighwayToPeak.Models
{
    public abstract class Climber : IClimber
    {
        private string name;
        private int stamina;
        private readonly List<string> conqueredPeaks = new List<string>();
        protected Climber(string name, int stamina)
        {
            Name = name;
            Stamina = stamina;
            ConqueredPeaks = conqueredPeaks.AsReadOnly();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(ExceptionMessages.ClimberNameNullOrWhiteSpace);
                name = value;
            }
        }

        public int Stamina
        {
            get => stamina;
            protected set => stamina = Math.Max(0, Math.Min(10, value));
        }
        public IReadOnlyCollection<string> ConqueredPeaks { get; }
        public void Climb(IPeak peak)
        {
            if (!conqueredPeaks.Contains(peak.Name))
                conqueredPeaks.Add(peak.Name);
            switch (peak.DifficultyLevel)
            {
                case "Extreme": Stamina -= 6; break;
                case "Hard": Stamina -= 4; break;
                case "Moderate": Stamina -= 2; break;
            }
        }

        public abstract void Rest(int daysCount);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{GetType().Name} - Name: {Name}, Stamina: {Stamina}");
            if (conqueredPeaks.Count == 0)
                sb.AppendLine("Peaks conquered: no peaks conquered");
            else
                sb.AppendLine($"Peaks conquered: {conqueredPeaks.Count}");

            return sb.ToString().Trim();
        }
    }
}
