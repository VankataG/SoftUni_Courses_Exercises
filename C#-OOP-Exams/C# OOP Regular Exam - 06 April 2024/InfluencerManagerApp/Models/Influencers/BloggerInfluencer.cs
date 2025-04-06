﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using InfluencerManagerApp.Models.Base;

namespace InfluencerManagerApp.Models.Influencers
{
    public class BloggerInfluencer : Influencer
    {
        public BloggerInfluencer(string username, int followers) : base(username, followers, 2.0) { }

        public override int CalculateCampaignPrice()
        {
            return (int)Math.Floor(this.Followers * this.EngagementRate * 0.2);
        }
    }
}
