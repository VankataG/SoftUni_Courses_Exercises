using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;

namespace HighwayToPeak.Models
{
    public class Peak : IPeak
    {
        private string name;
        private int elevation;

        public Peak(string name, int elevation, string difficultyLevel)
        {
            this.Name = name;
            this.Elevation = elevation;
            this.DifficultyLevel = difficultyLevel;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.PeakNameNullOrWhiteSpace);
                name = value;
            }
        }

        public int Elevation
        {
            get => elevation;
            private set
            {
                if (value < 1) throw new ArgumentException(ExceptionMessages.PeakElevationNegative);
                elevation = value;
            }

        }
        public string DifficultyLevel { get; }

        public override string ToString()
        {
            return $"Peak: {Name} -> Elevation: {Elevation}, Difficulty: {DifficultyLevel}";
        }
    }
}
