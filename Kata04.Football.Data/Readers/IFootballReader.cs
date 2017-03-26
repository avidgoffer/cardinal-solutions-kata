using Kata04.Football.Data.Entities;
using System.Collections.Generic;

namespace Kata04.Data.Readers
{
    // is this the best way to do this.  i wanted to enale a way to read the day agnostically
    public interface IFootballReader
    {
        IList<FootballStat> GetAll();
    }
}