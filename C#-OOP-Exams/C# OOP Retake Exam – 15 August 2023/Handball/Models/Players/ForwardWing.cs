using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models.Players
{
    public class ForwardWing : Player
    {
        public ForwardWing(string name) : base(name, 5.5) { }

        public override void IncreaseRating()
        {
            this.Rating += 1.25;
        }

        public override void DecreaseRating()
        {
            this.Rating -= 0.75;
        }
    }
}
