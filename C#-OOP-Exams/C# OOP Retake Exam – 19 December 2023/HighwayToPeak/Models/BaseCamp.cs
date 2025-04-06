using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HighwayToPeak.Models.Contracts;

namespace HighwayToPeak.Models
{
    public class BaseCamp : IBaseCamp
    {
        private readonly List<string> residents = new List<string>();

        public BaseCamp()
        {
            this.Residents = residents.AsReadOnly();
        }
        public IReadOnlyCollection<string> Residents { get; }
        public void ArriveAtCamp(string climberName)
        {
            residents.Add(climberName);
        }

        public void LeaveCamp(string climberName)
        {
            residents.Remove(climberName);
        }
    }
}
