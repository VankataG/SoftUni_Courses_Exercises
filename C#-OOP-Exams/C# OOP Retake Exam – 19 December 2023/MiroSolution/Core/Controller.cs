using System.Text;
using HighwayToPeak.Core.Contracts;
using HighwayToPeak.Models;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories;
using HighwayToPeak.Utilities.Messages;

namespace HighwayToPeak.Core;

public class Controller : IController
{
    private PeakRepository _peaks;
    private ClimberRepository _climbers;
    private BaseCamp _baseCamp;

    private string[] _difficultyLevels = new string[]
    {
        "Extreme",
        "Moderate",
        "Hard"
    };

    public Controller()
    {
        _peaks = new PeakRepository();
        _climbers = new ClimberRepository();
        _baseCamp = new BaseCamp();
    }

    public string AddPeak(string name, int elevation, string difficultyLevel)
    {
        IPeak? peak = _peaks.Get(name);
        if (peak is not null)
        {
            return String.Format(OutputMessages.PeakAlreadyAdded, name);
        }

        if (!this._difficultyLevels.Contains(difficultyLevel))
        {
            return String.Format(OutputMessages.PeakDiffucultyLevelInvalid, difficultyLevel);
        }

        this._peaks.Add(new Peak(name, elevation, difficultyLevel));
        return String.Format(OutputMessages.PeakIsAllowed, name, nameof(PeakRepository));
    }

    public string NewClimberAtCamp(string name, bool isOxygenUsed)
    {
        IClimber? climber = _climbers.Get(name);
        if (climber is not null)
        {
            return String.Format(OutputMessages.ClimberCannotBeDuplicated, name, nameof(ClimberRepository));
        }

        IClimber climberToAdd = isOxygenUsed switch
        {
            true => new OxygenClimber(name),
            _ => new NaturalClimber(name)
        };

        this._climbers.Add(climberToAdd);
        this._baseCamp.ArriveAtCamp(name);
        return String.Format(OutputMessages.ClimberArrivedAtBaseCamp, name);
    }

    public string AttackPeak(string climberName, string peakName)
    {
        IClimber? climber = _climbers.Get(climberName);
        if (climber is null)
        {
            return String.Format(OutputMessages.ClimberNotArrivedYet, climberName);
        }

        IPeak? peak = _peaks.Get(peakName);
        if (peak is null)
        {
            return String.Format(OutputMessages.PeakIsNotAllowed, peakName);
        }

        if (!this._baseCamp.Residents.Contains(climberName))
        {
            return String.Format(OutputMessages.ClimberNotFoundForInstructions, climberName, peakName);
        }

        if (peak.DifficultyLevel == "Extreme" && climber is NaturalClimber)
        {
            return String.Format(OutputMessages.NotCorrespondingDifficultyLevel, climberName, peakName);
        }

        this._baseCamp.LeaveCamp(climberName);
        climber.Climb(peak);
        if (climber.Stamina <= 0)
        {
            return String.Format(OutputMessages.NotSuccessfullAttack, climberName);
        }

        this._baseCamp.ArriveAtCamp(climberName);
        return String.Format(OutputMessages.SuccessfulAttack, climberName, peakName);
    }

    public string CampRecovery(string climberName, int daysToRecover)
    {
        if (!this._baseCamp.Residents.Contains(climberName))
        {
            return String.Format(OutputMessages.ClimberIsNotAtBaseCamp, climberName);
        }

        IClimber? climber = this._climbers.Get(climberName);
        if (climber.Stamina == 10)
        {
            return String.Format(OutputMessages.NoNeedOfRecovery, climberName);
        }

        climber.Rest(daysToRecover);
        return String.Format(OutputMessages.ClimberRecovered, climberName, daysToRecover);
    }

    public string BaseCampReport()
    {
        StringBuilder sb = new StringBuilder();

        if (_baseCamp.Residents.Count > 0)
        {
            sb.AppendLine("BaseCamp residents:");
        }
        else
        {
            sb.AppendLine("BaseCamp is currently empty.");
        }

        foreach (var baseCampClimber in this._baseCamp.Residents)
        {
            IClimber? climber = this._climbers.Get(baseCampClimber);
            if (climber is not null)
            {
                sb.AppendLine(climber.ToString());
            }
        }

        return sb.ToString().Trim();
    }

    public string OverallStatistics()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("***Highway-To-Peak***");

        foreach (var baseCampClimber in this._climbers.All
                     .OrderByDescending(c => c.ConqueredPeaks.Count)
                     .ThenBy(c => c.Name))
        {
            IEnumerable<IPeak> peaksConquered = this._peaks.All
                .Where(p => baseCampClimber.ConqueredPeaks.Contains(p.Name))
                .OrderByDescending(p => p.Elevation);

            sb.AppendLine(
                $"{baseCampClimber.GetType().Name} - Name: {baseCampClimber.Name}, Stamina: {baseCampClimber.Stamina}");
                if (peaksConquered.Count() > 0)
                {
                    sb.AppendLine($"Peaks conquered: {peaksConquered.Count()}");
                }
            foreach (var peak in this._peaks.All
                         .Where(p => baseCampClimber.ConqueredPeaks.Contains(p.Name))
                         .OrderByDescending(p => p.Elevation))
            {

                sb.AppendLine(peak.ToString());
            }
        }

        return sb.ToString().Trim();
    }
}