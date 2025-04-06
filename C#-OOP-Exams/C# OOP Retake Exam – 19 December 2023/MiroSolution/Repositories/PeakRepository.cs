using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;

namespace HighwayToPeak.Repositories;

public class PeakRepository : IRepository<IPeak>
{
    private readonly List<IPeak> all;
    public IReadOnlyCollection<IPeak> All { get; }

    public PeakRepository()
    {
        this.all = new List<IPeak>();
        this.All = this.all.AsReadOnly();
    }

    public void Add(IPeak model) => this.all.Add(model);

    public IPeak? Get(string name) => this.all.FirstOrDefault(p => p.Name == name);
}