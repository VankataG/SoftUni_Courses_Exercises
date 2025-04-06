using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;

namespace HighwayToPeak.Repositories;

public class ClimberRepository : IRepository<IClimber>
{
    private readonly List<IClimber> all;
    public IReadOnlyCollection<IClimber> All { get; }

    public ClimberRepository()
    {
        this.all = new List<IClimber>();
        this.All = this.all.AsReadOnly();
    }
    public void Add(IClimber model) => this.all.Add(model);

    public IClimber? Get(string name) => this.all.FirstOrDefault(c => c.Name == name);
}