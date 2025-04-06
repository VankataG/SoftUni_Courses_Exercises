using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Championship.Tests
{
    public class Tests
    {
        private League league;
        private Team team;
        private Team team2;

        [SetUp]
        public void Setup()
        {
            league = new League();
            team = new Team("team");
            team2 = new Team("team2");
        }

        [Test]
        public void Constructor_ShouldCreateInstance()
        {

            League leagueTest = new League();
            Assert.AreEqual(10, leagueTest.Capacity);
            Assert.AreEqual(0, leagueTest.Teams.Count);
            Assert.IsNotNull(league);
        }

        [Test]
        public void AddingTeamWhenFull_Throws()
        {
            for (int i = 1; i <= 10; i++)
            {
                league.AddTeam(new Team($"Team{i}"));
            }

            Assert.Throws<InvalidOperationException>(
                () => league.AddTeam(team));
        }

        [Test]
        public void AddingExistingTeam_Throws()
        {
            league.AddTeam(team);
            Assert.Throws<InvalidOperationException>(
                () => league.AddTeam(team));
        }

        [Test]
        public void AddingTeam_Works()
        {
            league.AddTeam(team);
            Assert.AreEqual(1, league.Teams.Count);
            Assert.AreEqual("team", league.Teams[0].Name);
        }

        [Test]
        public void RemoveTeam_Works()
        {
            Assert.IsFalse(league.RemoveTeam("team"));
            league.AddTeam(team);
            Assert.IsTrue(league.RemoveTeam("team"));
            Assert.AreEqual(0, league.Teams.Count);
        }

        [Test]
        public void PlayMatch_NotExistingTeam_Throws()
        {
            Assert.Throws<InvalidOperationException>(
                () => league.PlayMatch("team", "team2", 0, 0));

            league.AddTeam(team);
            Assert.Throws<InvalidOperationException>(
                () => league.PlayMatch("team", "team2", 1, 1));
        }

        [Test]
        public void PlayMatch_WorksCorrectly()
        {
            league.AddTeam(team);
            league.AddTeam(team2);

            league.PlayMatch("team", "team2", 1,1);
            Assert.AreEqual(1,team.Draws);
            Assert.AreEqual(1, team2.Draws);

            league.PlayMatch("team", "team2", 2, 1);
            Assert.AreEqual(1, team.Wins);
            Assert.AreEqual(0, team.Loses);
            Assert.AreEqual(1, team2.Loses);
            Assert.AreEqual(0, team2.Wins);

            league.PlayMatch("team", "team2", 1, 2);
            Assert.AreEqual(1, team.Loses);
            Assert.AreEqual(1, team2.Wins);
            Assert.AreEqual(1, team.Wins);
            Assert.AreEqual(1, team2.Loses);
        }

        [Test]
        public void GetTeamInfo_NotExistingTeam_Throws()
        {
            Assert.Throws<InvalidOperationException>(
                () => league.GetTeamInfo("team"));
        }

        [Test]
        public void GetTeamInfo_WorksCorrectly()
        {
            league.AddTeam(team);
            string result = league.GetTeamInfo("team");
            string expected = "team - 0 points (0W 0D 0L)";

            Assert.AreEqual(expected, result);
        }

    }
}