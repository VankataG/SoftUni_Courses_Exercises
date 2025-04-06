using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models.DiverTypes
{
    public class FreeDiver : Diver
    {
        public FreeDiver(string name) : base(name, 120) { }

        public override void Miss(int TimeToCatch )
        {
            this.OxygenLevel -= (int)Math.Round(TimeToCatch * 0.6, MidpointRounding.AwayFromZero);

        }

        public override void RenewOxy()
        {
            this.OxygenLevel = 120;
        }
    }
}
