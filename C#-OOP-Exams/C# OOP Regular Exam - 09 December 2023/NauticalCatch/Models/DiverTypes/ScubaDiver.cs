using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models.DiverTypes
{
    public class ScubaDiver : Diver
    {
        public ScubaDiver(string name) : base(name, 540) { }

        public override void Miss(int TimeToCatch)
        {
            this.OxygenLevel -= (int)Math.Round(TimeToCatch * 0.3, MidpointRounding.AwayFromZero);

        }

        public override void RenewOxy()
        {
            this.OxygenLevel = 540;
        }
    }
}
