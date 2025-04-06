using HighwayToPeak.Models.Contracts;

namespace HighwayToPeak.Models;

public class OxygenClimber : Climber
{
    protected override int RecoveryRate => 1;
    public override void Rest(int daysCount) => this.Stamina += daysCount * this.RecoveryRate;

    public OxygenClimber(string name)
        : base(name, 10)
    {
    }
}