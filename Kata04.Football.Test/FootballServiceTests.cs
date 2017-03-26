using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kata04.Football.Core.Services;
using Kata04.Football.Data.Entities;
using System.Collections.Generic;

namespace Kata04.Football.Test
{
    [TestClass]
    public class GivenAFootballService
    {
        [TestMethod]
        public void ThenGetTeamWithSmallestScoringDifferenceReturnsTheTeamWithTheSmallestScoringDifference()
        {
            var footballService = new FootballService(new List<FootballStat>
                {
                    new FootballStat
                    {
                        TeamName="Team 1",
                        GoalsFor=50,
                        GoalsAgainst=40
                    },
                    new FootballStat
                    {
                        TeamName="Team 2",
                        GoalsFor=50,
                        GoalsAgainst=45
                    }
                });
            var footballStat = footballService.GetTeamWithSmallestScoringDifference();

            const string expectedTeam = "Team 2";
            Assert.IsNotNull(footballStat);
            Assert.AreEqual(expectedTeam, footballStat.TeamName);
        }
    }
}
