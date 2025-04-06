using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HighwayToPeak.Core.Contracts;
using HighwayToPeak.Models;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories;

namespace HighwayToPeak.Core
{
    public class Controller : IController
    {
        private PeakRepository peaks = new PeakRepository();
        private ClimberRepository climbers = new ClimberRepository();
        private BaseCamp baseCamp = new BaseCamp();

        private List<string> difficultyLevels = new List<string>()
        {
            "Extreme",
            "Hard",
            "Moderate"
        };

        public string AddPeak(string name, int elevation, string difficultyLevel)
        {
            IPeak checkPeak = peaks.Get(name);

            if (checkPeak != null) 
                return $"{name} is already added as a valid mountain destination.";

            if (!difficultyLevels.Contains(difficultyLevel))
                return $"{difficultyLevel} peaks are not allowed for international climbers.";

            peaks.Add(new Peak(name, elevation, difficultyLevel));
            return $"{name} is allowed for international climbing. See details in {nameof(PeakRepository)}.";
        }

        public string NewClimberAtCamp(string name, bool isOxygenUsed)
        {
            IClimber checkClimber = climbers.Get(name);

            if (checkClimber != null)
                return $"{name} is a participant in {nameof(ClimberRepository)} and cannot be duplicated.";

            IClimber climber;
            if (isOxygenUsed)
                climber = new OxygenClimber(name);
            else
                climber = new NaturalClimber(name);

            climbers.Add(climber);
            baseCamp.ArriveAtCamp(name);
            return $"{name} has arrived at the BaseCamp and will wait for the best conditions.";
        }

        public string AttackPeak(string climberName, string peakName)
        {
            IClimber climber = climbers.Get(climberName);
            IPeak peak = peaks.Get(peakName);

            if (climber == null)
                return $"Climber - {climberName}, has not arrived at the BaseCamp yet.";

            if (peak == null)
                return $"{peakName} is not allowed for international climbing.";

            if (!baseCamp.Residents.Contains(climberName))
                return
                    $"{climberName} not found for gearing and instructions. The attack of {peakName} will be postponed.";

            if (peak.DifficultyLevel == difficultyLevels[0] && climber.GetType().Name == nameof(NaturalClimber))
                return $"{climberName} does not cover the requirements for climbing {peakName}.";

            baseCamp.LeaveCamp(climberName);
            climber.Climb(peak);
            if (climber.Stamina <= 0)
                return $"{climberName} did not return to BaseCamp.";

            baseCamp.ArriveAtCamp(climberName);
            return $"{climberName} successfully conquered {peakName} and returned to BaseCamp.";

        }

        public string CampRecovery(string climberName, int daysToRecover)
        {
            if(!baseCamp.Residents.Contains(climberName))
                return $"{climberName} not found at the BaseCamp.";

            IClimber climber = climbers.Get(climberName);

            if (climber.Stamina == 10)
                return $"{climberName} has no need of recovery.";

            climber.Rest(daysToRecover);
            return $"{climberName} has been recovering for {daysToRecover} days and is ready to attack the mountain.";
        }

        public string BaseCampReport()
        {
            if (baseCamp.Residents.Count == 0)
                return "BaseCamp is currently empty.";

            List<IClimber> campClimbers = new List<IClimber>();
            foreach (var climberName in baseCamp.Residents)
            {
                IClimber climber = climbers.Get(climberName);

                campClimbers.Add(climber);
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("BaseCamp residents:");
            foreach (IClimber climber in campClimbers.OrderBy(c => c.Name))
            {
                sb.AppendLine($"Name: {climber.Name}, Stamina: {climber.Stamina}, Count of Conquered Peaks: {climber.ConqueredPeaks.Count}");
            }

            return sb.ToString().Trim();
        }

        public string OverallStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("***Highway-To-Peak***");
            foreach (var climber in climbers.All.OrderByDescending(c => c.ConqueredPeaks.Count)
                                                .ThenBy(c => c.Name))
            {
                sb.AppendLine(climber.ToString());

                List<IPeak> climbedPeaks = new List<IPeak>();
                foreach (var peakName in climber.ConqueredPeaks)
                {
                    IPeak getPeak = peaks.Get(peakName);
                    climbedPeaks.Add(getPeak);
                }

                foreach (IPeak peak in climbedPeaks.OrderByDescending(p => p.Elevation))
                {
                    sb.AppendLine(peak.ToString());
                }
            }

            return sb.ToString().Trim();
        }
    }
}
