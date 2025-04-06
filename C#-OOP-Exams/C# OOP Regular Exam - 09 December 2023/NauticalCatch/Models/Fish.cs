using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using ArgumentException = System.ArgumentException;

namespace NauticalCatchChallenge.Models
{
    public abstract class Fish : IFish
    {
        protected Fish(string name, double points, int timeToCatch)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(ExceptionMessages.FishNameNull);
            if (points is < 1 or > 10)
                throw new ArgumentException(ExceptionMessages.PointsNotInRange);
            this.Name = name;
            this.Points = points;
            this.TimeToCatch = timeToCatch;
        }
        public string Name { get; }
        public double Points { get; }
        public int TimeToCatch { get; }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {Name} [ Points: {Points}, Time to Catch: {TimeToCatch} seconds ]";
        }
    }
}
