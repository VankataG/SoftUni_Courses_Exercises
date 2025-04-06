using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Models.Managers
{
    public class AmateurManager : Manager
    {
        public AmateurManager(string name) : base(name,15) { }

        public override void RankingUpdate(double updateValue)
        {
            UpdateRanking(updateValue * 0.75);
        }

    }
}
