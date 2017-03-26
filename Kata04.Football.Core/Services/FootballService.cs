using Kata04.Football.Data.Entities;
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
            return _footballStats
                .FirstOrDefault(x => x.GoalsFor - x.GoalsAgainst == _footballStats.Min(y => y.GoalsFor - y.GoalsAgainst));
        }
    }
}