using System;
using Handball.Models.Contracts;
using Handball.Utilities.Messages;

namespace Handball.Models;
public abstract class Player : IPlayer
{
    private string name;

    private double rating;

    protected Player(string name, double rating)
    {
        this.Name = name;
        this.Rating = rating;
    }
    public string Name
    {
        get => name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException(ExceptionMessages.PlayerNameNull);
            name = value;
        }
    }

    public double Rating
    {
        get => rating;
        protected set => rating = Math.Max(1, Math.Min(10, value));
    }
    public string Team { get; private set; }
    public void JoinTeam(string name)
    {
        Team = name;
    }

    public abstract void IncreaseRating();

    public abstract void DecreaseRating();

    public override string ToString()
    {
        return $"{GetType().Name}: {Name}" +
               Environment.NewLine +
               $"--Rating: {Rating}";
    }
}
