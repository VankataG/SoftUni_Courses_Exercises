using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfluencerManagerApp.Models.Base;

namespace InfluencerManagerApp.Models.Campaigns
{
    public class ServiceCampaign : Campaign
    {
        public ServiceCampaign(string brand) : base(brand, 30_000) { }

    }
}
