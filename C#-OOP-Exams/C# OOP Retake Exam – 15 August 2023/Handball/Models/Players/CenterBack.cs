using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models.Players
{
    public class CenterBack : Player
    {
        public CenterBack(string name) : base(name, 4) { }

        public override void IncreaseRating()
        {
            this.Rating++;
        }

        public override void DecreaseRating()
        {
            this.Rating--;
        }
    }
}
