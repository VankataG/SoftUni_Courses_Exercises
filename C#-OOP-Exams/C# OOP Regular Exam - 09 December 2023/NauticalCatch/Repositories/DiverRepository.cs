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
    public class DiverRepository : IRepository<IDiver>, IEnumerable
    {
        private readonly List<IDiver> models = new List<IDiver>();
        public IReadOnlyCollection<IDiver> Models => models.AsReadOnly();
        public void AddModel(IDiver model)
        {
            models.Add(model);
        }

        public IDiver GetModel(string name)
        {
            return models.FirstOrDefault(m => m.Name == name);
        }


        public IEnumerator GetEnumerator()
        {
            foreach (IDiver model in Models)
            {
                yield return model;
            }
        }
    }
}
