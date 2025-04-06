using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballManager.Models.Contracts;
using FootballManager.Repositories.Contracts;

namespace FootballManager.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        private List<ITeam> models = new List<ITeam>();
        public IReadOnlyCollection<ITeam> Models => models.AsReadOnly();
        public int Capacity { get; }
        public void Add(ITeam model)
        {
            if (Capacity < 10)
                models.Add(model);
        }

        public bool Remove(string name)
        {
            var team = models.FirstOrDefault(t => t.Name == name);

            return models.Remove(team);
        }

        public bool Exists(string name)
        {
            return models.Exists(t => t.Name == name);
            
        }

        public ITeam Get(string name)
        {
            return models.FirstOrDefault(t => t.Name == name);
        }
    }
}
