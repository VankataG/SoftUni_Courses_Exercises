﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Models.Managers
{
    public class ProfessionalManager : Manager
    {
        public ProfessionalManager(string name ) : base(name, 60) { }

        public override void RankingUpdate(double updateValue)
        {
            UpdateRanking(updateValue * 1.5);
        }
    }
}
