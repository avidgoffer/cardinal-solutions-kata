using System.Collections.Generic;
using System.IO;
using Kata04.Football.Data.Entities;

namespace Kata04.Data.Readers
{
    public class FootballFileReader : IFootballReader
    {
        private readonly string _pathToData;

        // is this the best way to do this.  i wanted to enale a way to read the day agnostically
        public FootballFileReader(string pathToData)
        {
            _pathToData = pathToData;
        }

        public IList<FootballStat> GetAll()
        {
            // todo implement caching maybe?
            // todo recoginize when file changes?
            string[] data = File.ReadAllLines(_pathToData);
            var footballData = new List<FootballStat>();
            for (int i = 0; i < data.Length; ++i)
            {
                int goalsFor = -1;
                if(!int.TryParse(data[i].Substring(42, 3), out goalsFor)) continue;
                int goalsAgainst = -1;
                if(!int.TryParse(data[i].Substring(49, 3), out goalsAgainst)) continue;
                footballData.Add(new FootballStat
                {
                    TeamName = data[i].Substring(7,15),
                    GoalsFor = goalsFor,
                    GoalsAgainst = goalsAgainst
                });
            }
            return footballData;
        }
    }
}