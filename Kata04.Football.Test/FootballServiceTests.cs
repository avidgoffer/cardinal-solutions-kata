using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
                        Team="Team 1",
                        For=50,
                        Against=40
                    },
                    new FootballStat
                    {
                        Team="Team 2",
                        For=50,
                        Against=45
                    }
                });
            var footballStat = footballService.GetTeamWithSmallestScoringDifference();

            const int expectedTeam = "Team 2";
            Assert.IsNotNull(footballStat);
            Assert.AreEqual(expectedTeam, footballStat.Team);
        }
    }
}
