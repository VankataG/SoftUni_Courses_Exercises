using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;

namespace HighwayToPeak.Models;

public class Peak : IPeak
{
    private string name;
    private int elevation;

    public string Name
    {
        get=>this.name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.PeakNameNullOrWhiteSpace);
            }
            this.name = value;
        }
    }

    public int Elevation
    {
        get=>this.elevation;
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException(ExceptionMessages.PeakElevationNegative);
            }
            this.elevation = value;
        }
    }
    public string DifficultyLevel { get; }

    public Peak(string name, int elevation, string difficultyLevel)
    {
        Name = name;
        Elevation = elevation;
        DifficultyLevel = difficultyLevel;
    }

    public override string ToString()
    {
        return $"Peak: {this.Name} -> Elevation: {this.Elevation}, Difficulty: {this.DifficultyLevel}";
    }
}