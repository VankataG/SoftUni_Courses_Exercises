using HighwayToPeak.Models.Contracts;

namespace HighwayToPeak.Models;

public class NaturalClimber : Climber
{
    protected override int RecoveryRate => 2;
    public override void Rest(int daysCount) => this.Stamina += daysCount * this.RecoveryRate;

    public override void Climb(IPeak peak)
    {
        if (peak.DifficultyLevel != "Extreme")
        {
            base.Climb(peak);
        }
    }

    public NaturalClimber(string name)
        : base(name, 6)
    {
    }
}