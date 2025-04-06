using System.Text;
using HighwayToPeak.Models.Contracts;

namespace HighwayToPeak.Models;

public abstract class Climber : IClimber
{
    private string name;
    private int stamina;
    private List<string> conqueredPeaks;

    public string Name
    {
        get => this.name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Climber's name cannot be null or whitespace.");
            }
            this.name = value;
        }
    }

    public int Stamina
    {
        get => this.stamina;
        protected set => this.stamina = Math.Max(0, Math.Min(10, value));
    }

    protected abstract int RecoveryRate { get; }
    public IReadOnlyCollection<string> ConqueredPeaks { get; }

    protected Climber(string name, int stamina)
    {
        this.Name = name;
        this.Stamina = stamina;
        this.conqueredPeaks = new List<string>();
        this.ConqueredPeaks = this.conqueredPeaks.AsReadOnly();
    }

    public virtual void Climb(IPeak peak)
    {
        if (!conqueredPeaks.Contains(peak.Name))
        {
            this.conqueredPeaks.Add(peak.Name);
        } 

        this.Stamina -= peak.DifficultyLevel switch
        {
            "Extreme" => 6,
            "Hard" => 4,
            "Moderate" => 2,
            _ => 0
        };
    }

    public abstract void Rest(int daysCount);
        

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        //sb.Append($"Name: {Name}, Stamina: {Stamina}, Count of Conquered Peaks: ");

        //if(this.conqueredPeaks.Count > 0)
        //{
        //    sb.AppendLine($"{ConqueredPeaks.Count}");
        //}
        //else
        //{
        //    sb.Append("no peaks conquered");
        //}

        sb.AppendLine($"{this.GetType().Name} - Name: {Name}, Stamina: {Stamina}");

        if (this.conqueredPeaks.Count > 0)
            sb.AppendLine($"Peaks conquered: {this.conqueredPeaks.Count}");
        else
            sb.AppendLine("Peaks conquered: no peaks conquered");

        return sb.ToString().Trim();
    }
}