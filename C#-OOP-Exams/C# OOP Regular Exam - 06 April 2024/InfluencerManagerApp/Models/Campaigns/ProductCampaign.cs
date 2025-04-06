using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfluencerManagerApp.Models.Base;

namespace InfluencerManagerApp.Models.Campaigns
{
    public class ProductCampaign : Campaign
    {
        public ProductCampaign(string brand) : base(brand, 60_000) { }
    }
}
