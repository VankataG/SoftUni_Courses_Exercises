using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;

namespace HighwayToPeak.Repositories
{
    public class ClimberRepository : IRepository<IClimber>
    {
        private List<IClimber> all = new List<IClimber>();

        public ClimberRepository()
        {
            this.All = all.AsReadOnly();
        }

        public IReadOnlyCollection<IClimber> All { get; }

        public void Add(IClimber model)
        {
            all.Add(model);
        }

        public IClimber Get(string name)
        {
            return all.FirstOrDefault(c => c.Name == name);
        }
    }
}
