using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfluencerManagerApp.Core.Contracts;
using InfluencerManagerApp.Models.Campaigns;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Models.Influencers;
using InfluencerManagerApp.Repositories;

namespace InfluencerManagerApp.Core
{
    public class Controller : IController
    {
        private InfluencerRepository influencers;
        private CampaignRepository campaigns;
        private List<string> influencerTypes = new List<string>()
        {
            "BusinessInfluencer",
            "FashionInfluencer",
            "BloggerInfluencer"
        };

        private List<string> campaignTypes = new List<string>()
        {
            "ProductCampaign",
            "ServiceCampaign"
        };

        public Controller()
        {
            influencers = new InfluencerRepository();
            campaigns = new CampaignRepository();
        }


        public string RegisterInfluencer(string typeName, string username, int followers)
        {
            if (!influencerTypes.Contains(typeName))
                return $"{typeName} has not passed validation.";

            IInfluencer existingInfluencer = influencers.FindByName(username);
            if (existingInfluencer != null)
                return $"{username} is already registered in {nameof(InfluencerRepository)}.";

            IInfluencer influencer = CreateInfluencer(typeName, username, followers);
            influencers.AddModel(influencer);
            return $"{username} registered successfully to the application.";
        }



        public string BeginCampaign(string typeName, string brand)
        {
            if (!campaignTypes.Contains(typeName))
                return $"{typeName} is not a valid campaign in the application.";

            if (campaigns.FindByName(brand) != null)
                return $"{brand} campaign cannot be duplicated.";

            ICampaign campaign = CreateCampaign(typeName, brand);
            campaigns.AddModel(campaign);
            return $"{brand} started a {typeName}.";
        }


        public string AttractInfluencer(string brand, string username)
        {
            IInfluencer influencer = influencers.FindByName(username);
            ICampaign campaign = campaigns.FindByName(brand);

            if (influencer == null)
                return $"{nameof(InfluencerRepository)} has no {username} registered in the application.";

            if (campaign == null)
                return $"There is no campaign from {brand} in the application.";

            if (campaign.Contributors.Any(c => c == username))
                return $"{username} is already engaged for the {brand} campaign.";

            string campaignType = campaign.GetType().Name;
            string influencerType = influencer.GetType().Name;
            if ((campaignType == nameof(ProductCampaign) && influencerType == nameof(BloggerInfluencer)) ||
                (campaignType == nameof(ServiceCampaign) && influencerType == nameof(FashionInfluencer)))
                return $"{username} is not eligible for the {brand} campaign.";

            int amount = influencer.CalculateCampaignPrice();
            if (campaign.Budget < amount)
                return $"The budget for {brand} is insufficient to engage {username}.";

            influencer.EarnFee(amount);
            influencer.EnrollCampaign(brand);
            campaign.Engage(influencer);
            return $"{username} has been successfully attracted to the {brand} campaign.";
        }

        public string FundCampaign(string brand, double amount)
        {
            ICampaign campaign = campaigns.FindByName(brand);

            if (campaign == null)
                return "Trying to fund an invalid campaign.";

            if (amount <= 0)
                return "Funding amount must be greater than zero.";

            campaign.Gain(amount);
            return $"{brand} campaign has been successfully funded with {amount} $";
        }

        public string CloseCampaign(string brand)
        {
            ICampaign campaign = campaigns.FindByName(brand);

            if (campaign == null)
                return "Trying to close an invalid campaign.";

            if (campaign.Budget <= 10_000)
                return $"{brand} campaign cannot be closed as it has not met its financial targets.";

            foreach (IInfluencer influencer in influencers.Models)
            {
                if (influencer.Participations.Contains(brand))
                {
                    influencer.EarnFee(2000);
                    influencer.EndParticipation(brand);
                }
            }

            campaigns.RemoveModel(campaign);
            return $"{brand} campaign has reached its target.";

        }

        public string ConcludeAppContract(string username)
        {
            IInfluencer influencer = influencers.FindByName(username);

            if (influencer == null)
                return $"{username} has still not signed a contract.";

            if (influencer.Participations.Count > 0)
                return $"{username} cannot conclude the contract while enrolled in active campaigns.";

            influencers.RemoveModel(influencer);
            return $"{username} concluded their contract.";

        }

        public string ApplicationReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (IInfluencer influencer in influencers.Models.OrderByDescending(i => i.Income)
                         .ThenByDescending(i => i.Followers))
            {
                sb.AppendLine(influencer.ToString());
                if (influencer.Participations.Count > 0)
                {
                    sb.AppendLine("Active Campaigns:");
                    foreach (ICampaign campaign in campaigns.Models.OrderBy(c => c.Brand))
                    { 
                        if (campaign.Contributors.Contains(influencer.Username))
                            sb.AppendLine($"--{campaign.ToString()}");
                    }
                }
            }

            return sb.ToString().Trim();
        }


        private IInfluencer CreateInfluencer(string typeName, string username, int followers)
        {
            return typeName switch
            {
                "BusinessInfluencer" => new BusinessInfluencer(username, followers),
                "FashionInfluencer" => new FashionInfluencer(username, followers),
                "BloggerInfluencer" => new BloggerInfluencer(username, followers),
                _ => throw new ArgumentException($"{typeName} has not passed validation.")
            };
        }
        private ICampaign CreateCampaign(string typeName, string brand)
        {
            return typeName switch
            {
                "ProductCampaign" => new ProductCampaign(brand),
                "ServiceCampaign" => new ServiceCampaign(brand),
                _ => throw new ArgumentException($"{typeName} is not a valid campaign in the application.")
            };
        }
    }
}
