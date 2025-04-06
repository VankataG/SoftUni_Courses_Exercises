using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models.Players
{
    public class Goalkeeper : Player
    {
        public Goalkeeper(string name) : base(name, 2.5) { }

        public override void IncreaseRating()
        {
            Rating += 0.75;
        }

        public override void DecreaseRating()
        {
            Rating -= 1.25;
        }
    }
}
