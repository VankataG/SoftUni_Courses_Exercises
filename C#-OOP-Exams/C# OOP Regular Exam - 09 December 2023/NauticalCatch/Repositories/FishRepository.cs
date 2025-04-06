using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories.Contracts;

namespace NauticalCatchChallenge.Repositories
{
    public class FishRepository : IRepository<IFish>, IEnumerable
    {
        private readonly List<IFish> models = new List<IFish>();
        public IReadOnlyCollection<IFish> Models => models.AsReadOnly();
        public void AddModel(IFish model)
        {
            models.Add(model);
        }

        public IFish GetModel(string name)
        {
            return models.FirstOrDefault(m => m.Name == name);
        }

        public IEnumerator GetEnumerator()
        {
            foreach (IFish model in Models)
            {
                yield return model;
            }
        }
    }
}
