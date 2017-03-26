using Kata04.Football.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata04.Football.Core.Services
{
    public class FootballService
    {
        private IList<FootballStat> _footballStats;

        public FootballService(IList<FootballStat> footballStats)
        {
            _footballStats = footballStats;
        }

        public FootballStat GetTeamWithSmallestScoringDifference()
        {
            // When it says difference does it care which side the difference is on?  if it doesn't then i need to take the Abs of this right?
            return _footballStats
                .FirstOrDefault(x => Math.Abs(x.GoalsFor - x.GoalsAgainst) == _footballStats.Min(y => Math.Abs(y.GoalsFor - y.GoalsAgainst)));
        }
    }
}