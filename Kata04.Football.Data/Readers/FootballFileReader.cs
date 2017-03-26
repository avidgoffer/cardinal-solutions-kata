using System.Collections.Generic;
using Kata04.Football.Data.Entities;
using Kata04.Generic.Data.Readers;

namespace Kata04.Data.Readers
{
    public class FootballFileReader : IFootballReader
    {
        private readonly string _pathToData;

        // is this the best way to do this.  i wanted to enale a way to read the data agnostically
        public FootballFileReader(string pathToData)
        {
            _pathToData = pathToData;
        }

        public IEnumerable<FootballStat> GetAll()
        {
            return new FileReader<FootballStat>().GetAll(_pathToData, x =>
            {
                int goalsFor = -1;
                if (!int.TryParse(x.Substring(42, 3), out goalsFor)) return null;
                int goalsAgainst = -1;
                if (!int.TryParse(x.Substring(49, 3), out goalsAgainst)) return null;
                return new FootballStat
                {
                    TeamName = x.Substring(7, 15),
                    GoalsFor = goalsFor,
                    GoalsAgainst = goalsAgainst
                };
            });
        }
    }
}