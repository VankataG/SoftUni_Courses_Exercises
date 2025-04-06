using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handball.Models.Contracts;
using Handball.Models.Players;
using Handball.Utilities.Messages;

namespace Handball.Models;

public class Team : ITeam
{
    private string name;
    private List<IPlayer> players = new List<IPlayer>();

    public Team(string name)
    {
        this.Name = name;
        this.PointsEarned = 0;
        this.Players = players.AsReadOnly();
    }

    public string Name
    {
        get => name;
        private set
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentException(ExceptionMessages.TeamNameNull);
            name = value;
        }
    }

    public int PointsEarned { get; private set; }

    public double OverallRating => players.Any() ? Math.Round(players.Average(p => p.Rating), 2) : 0;
    
    public IReadOnlyCollection<IPlayer> Players { get; }

    public void SignContract(IPlayer player)
    {
        players.Add(player);
    }

    public void Win()
    {
        this.PointsEarned += 3;
        players.ForEach(p => p.IncreaseRating());
    }

    public void Lose()
    {
        players.ForEach(p => p.DecreaseRating());
    }

    public void Draw()
    {
        this.PointsEarned++;
        IPlayer goalKeeper = players.Find(
            p => p.GetType().Name == nameof(Goalkeeper));
        goalKeeper.IncreaseRating();
    }

    public override string ToString()
    {
        List<String> playersNames = new List<string>();

        foreach (IPlayer player in players)
        {
            playersNames.Add(player.Name);
        }

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Team: {Name} Points: {PointsEarned}");
        sb.AppendLine($"--Overall rating: {OverallRating}");
        if (players.Count == 0)
            sb.AppendLine("--Players: none");
        else
            sb.AppendLine($"--Players: {string.Join(", ", playersNames)}");

        return sb.ToString().Trim();



    }
}

