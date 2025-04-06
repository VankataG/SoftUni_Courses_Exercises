using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Models
{
    public class NaturalClimber : Climber
    {
        //⦁	Will NOT be allowed to climb peaks with extreme difficulty level.
        public NaturalClimber(string name) : base(name, 6) { }

        public override void Rest(int daysCount)
        {
            Stamina += daysCount * 2;
        }
    }
}
