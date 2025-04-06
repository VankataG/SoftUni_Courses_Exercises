using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Models.DiverTypes;
using NauticalCatchChallenge.Models.FishTypes;
using NauticalCatchChallenge.Repositories;

namespace NauticalCatchChallenge.Core
{
    public class Controller : IController
    {
        private DiverRepository divers = new DiverRepository();
        private FishRepository fish = new FishRepository();

        private List<string> diverTypes = new List<string>()
        {
            nameof(FreeDiver),
            nameof(ScubaDiver)
        };

        private List<string> fishTypes = new List<string>()
        {
            nameof(ReefFish),
            nameof(DeepSeaFish),
            nameof(PredatoryFish)
        };

        public string DiveIntoCompetition(string diverType, string diverName)
        {
            if (!diverTypes.Contains(diverType))
                return $"{diverType} is not allowed in our competition.";

            IDiver diver = divers.GetModel(diverName);
            if (diver != null)
                return $"{diverName} is already a participant -> {nameof(DiverRepository)}.";

            diver = CreateDiver(diverType, diverName);
            divers.AddModel(diver);
            return $"{diverName} is successfully registered for the competition -> {nameof(DiverRepository)}.";
        }


        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            if (!fishTypes.Contains(fishType))
                return $"{fishType} is forbidden for chasing in our competition.";

            IFish newFish = fish.GetModel(fishName);
            if (newFish != null)
                return $"{fishName} is already allowed -> {nameof(FishRepository)}.";

            newFish = CreateFish(fishType, fishName, points);
            fish.AddModel(newFish);
            return $"{fishName} is allowed for chasing.";
        }

        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            IDiver curDiver = divers.GetModel(diverName);
            IFish curFish = fish.GetModel(fishName);

            if (curDiver == null)
                return $"{nameof(DiverRepository)} has no {diverName} registered for the competition.";

            if (curFish == null)
                return $"{fishName} is not allowed to be caught in this competition.";

            if (curDiver.HasHealthIssues)
                return $"{diverName} will not be allowed to dive, due to health issues.";

            if (curDiver.OxygenLevel < curFish.TimeToCatch)
            {
                curDiver.Miss(curFish.TimeToCatch);
                CheckOxygen(curDiver);
                return $"{diverName} missed a good {fishName}.";
            }

            if (curDiver.OxygenLevel == curFish.TimeToCatch)
            {
                if (isLucky)
                {
                    curDiver.Hit(curFish);
                    CheckOxygen(curDiver);
                    return $"{diverName} hits a {curFish.Points}pt. {fishName}.";
                }

                curDiver.Miss(curFish.TimeToCatch);
                CheckOxygen(curDiver);
                return $"{diverName} missed a good {fishName}.";
            }

            curDiver.Hit(curFish);
            CheckOxygen(curDiver);
            return $"{diverName} hits a {curFish.Points}pt. {fishName}.";
        }

        private static void CheckOxygen(IDiver diver)
        {
            if (diver.OxygenLevel <= 0)
                if (!diver.HasHealthIssues)
                    diver.UpdateHealthStatus();
        }
        public string HealthRecovery()
        {
            int count = 0;
            foreach (IDiver diver in divers.Models)
            {
                if (diver.HasHealthIssues)
                {
                    diver.UpdateHealthStatus();
                    diver.RenewOxy();
                    count++;
                }
            }

            return $"Divers recovered: {count}";
        }

        public string DiverCatchReport(string diverName)
        {
            StringBuilder sb = new StringBuilder();

            IDiver diver = divers.GetModel(diverName);

            sb.AppendLine(diver.ToString());
            sb.AppendLine("Catch Report:");

            foreach (string name in diver.Catch)
            {
                IFish getFish = fish.GetModel(name);
                sb.AppendLine(getFish.ToString());
            }

            return sb.ToString().Trim();
        }

        public string CompetitionStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("**Nautical-Catch-Challenge**");

            foreach (IDiver diver in divers.Models
                         .Where(d => d.HasHealthIssues == false)
                         .OrderByDescending(d => d.CompetitionPoints)
                         .ThenByDescending(d => d.Catch.Count))
            {
                sb.AppendLine(diver.ToString());
            }

            return sb.ToString().Trim();
        }

        private static IDiver CreateDiver(string diverType, string diverName)
        {
            return diverType switch
            {
                nameof(FreeDiver) => new FreeDiver(diverName),
                nameof(ScubaDiver) => new ScubaDiver(diverName)
            };
        }

        private static IFish CreateFish(string fishType, string fishName, double points)
        {
            return fishType switch
            {
                nameof(ReefFish) => new ReefFish(fishName, points),
                nameof(DeepSeaFish) => new DeepSeaFish(fishName, points),
                nameof(PredatoryFish) => new PredatoryFish(fishName, points)
            };
        }
    }
}
