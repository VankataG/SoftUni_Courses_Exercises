using HighwayToPeak.Models.Contracts;

namespace HighwayToPeak.Models;

public class BaseCamp : IBaseCamp
{
    private readonly List<string> residents;
    public IReadOnlyCollection<string> Residents { get; }

    public BaseCamp()
    {
        this.residents = new List<string>();
        this.Residents = residents.AsReadOnly();
    }
    public void ArriveAtCamp(string climberName)
    { 
        residents.Add(climberName);
        residents.Sort();
    }

    public void LeaveCamp(string climberName)
    {
        this.residents.Remove(climberName);
    }
 }