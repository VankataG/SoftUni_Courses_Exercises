using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handball.Models.Contracts;
using Handball.Repositories.Contracts;

namespace Handball.Repositories;

public class PlayerRepository : IRepository<IPlayer>
{
    private List<IPlayer> models = new List<IPlayer>();
    public IReadOnlyCollection<IPlayer> Models => models.AsReadOnly();
    public void AddModel(IPlayer model)
    {
        models.Add(model);
    }

    public bool RemoveModel(string name)
    {
        IPlayer playerToRemove = this.GetModel(name);

        if (playerToRemove == null) return false;

        models.Remove(playerToRemove);
        return true;
    }

    public bool ExistsModel(string name)
    {
        return models.Exists(m => m.Name == name);
    }

    public IPlayer GetModel(string name)
    {
        return models.FirstOrDefault(m => m.Name == name);
    }
}