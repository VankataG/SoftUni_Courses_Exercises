using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;

namespace InfluencerManagerApp.Models.Base
{
    public abstract class Campaign : ICampaign
    {
        private string brand;
        private List<string> contributors;

        protected Campaign(string brand, double budget)
        {
            this.Brand = brand;
            this.Budget = budget;
            this.contributors = new List<string>();
        }
        public string Brand
        {
            get => brand;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.BrandIsrequired);
                brand = value;
            }
        }
        public double Budget { get; private set; }
        public IReadOnlyCollection<string> Contributors => contributors.AsReadOnly();
        public void Gain(double amount)
        {
            this.Budget += amount;
        }

        public void Engage(IInfluencer influencer)
        {
            this.contributors.Add(influencer.Username);
            int campaignPrice = influencer.CalculateCampaignPrice();
            this.Budget -= campaignPrice;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} - Brand: {Brand}, Budget: {Budget}, Contributors: {contributors.Count}";
        }


    }
}
