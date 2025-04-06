using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handball.Models.Contracts;
using Handball.Repositories.Contracts;

namespace Handball.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        private List<ITeam> models = new List<ITeam>();
        public IReadOnlyCollection<ITeam> Models => models.AsReadOnly();
        public void AddModel(ITeam model)
        {
            models.Add(model);
        }

        public bool RemoveModel(string name)
        {
            ITeam teamToRemove = this.GetModel(name);

            if (teamToRemove == null) return false;

            models.Remove(teamToRemove);
            return true;
        }

        public bool ExistsModel(string name)
        {
            return models.Exists(m => m.Name == name);
        }

        public ITeam GetModel(string name)
        {
            return models.FirstOrDefault(m => m.Name == name);
        }
    }
}
