using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicLayer;

namespace UnitTest
{
    [TestClass]
    public class MatchUnitTests
    {
        [TestMethod]
        public void GetMatchesSuccess()
        {
            // Arrange
            Tournament tournament = new Tournament(1, "Tournament1", "Description", "Location Test", new Football(1, "Soccer"), new TournamentTime(DateTime.Now.AddDays(10),
                DateTime.Now.AddDays(11)), "round-robin", 10, 2);

            MatchMock matchMock = new MatchMock();
            IMatchRepository repository = matchMock;
            MatchService service = new MatchService(repository);

            // Act
            List<Match> matches = service.GetMatches(tournament);

            //Assert
            List<Match> expectedMatches = matchMock.GetMatches(tournament);
            CollectionAssert.AreEquivalent(expectedMatches, matches);
        }

        [TestMethod]
        [ExpectedException(typeof(MatchesException))]
        public void GetMatchesExceptionNoSuchTournament()
        {
            // Arrange
            Tournament tournament = new Tournament(11, "Tournament1", "Description", "Location Test", new Football(1, "Soccer"), new TournamentTime(DateTime.Now.AddDays(10),
                DateTime.Now.AddDays(11)), "round-robin", 10, 2);

            MatchMock matchMock = new MatchMock();
            IMatchRepository repository = matchMock;
            MatchService service = new MatchService(repository);

            // Act
            List<Match> matches = service.GetMatches(tournament);
        }

        [TestMethod]
        public void CreateScheduleSuccess()
        {
            // Arrange
            Tournament tournament = new Tournament(2, "Tournament2", "Something", "Somewhere", new LeagueOfLegends(4, "League Of Legends"), new TournamentTime(DateTime.Now.AddDays(10),
                DateTime.Now.AddDays(11)), "Round-robin", 10, 2);

            MatchMock matchMock = new MatchMock();
            IMatchRepository repository = matchMock;
            MatchService service = new MatchService(repository);

            // Act
            service.CreateSchedule(tournament);

            // Assert
            List<Match> matches = service.GetMatches(tournament);
            Assert.IsNotNull(matches);
        }

        [TestMethod]
        [ExpectedException(typeof(MatchesException))]
        public void CreateScheduleExceptionNoPlayers()
        {
            // Arrange
            Tournament tournament = new Tournament(3, "NoPlayers", "No players", "Nowhere", new LeagueOfLegends(4, "League Of Legends"), new TournamentTime(DateTime.Now.AddDays(10),
                DateTime.Now.AddDays(11)), "Round-robin", 10, 2);

            MatchMock matchMock = new MatchMock();
            IMatchRepository repository = matchMock;
            MatchService service = new MatchService(repository);

            // Act
            service.CreateSchedule(tournament);
        }

        [TestMethod]
        public void UpdateScoreOfMatchFootballSuccess()
        {
            // Arrange
            Tournament tournament = new Tournament(1, "Tournament1", "Description", "Location Test", new Football(1, "Soccer"), new TournamentTime(DateTime.Now.AddDays(10),
                DateTime.Now.AddDays(11)), "round-robin", 10, 2);
            Match match = new Match(1, tournament, tournament.Time.Start,
                    new User(1, "test1", "tester1", "first", 21, Gender.MALE, "asd@gmail.com", new WinRate(0, 0)),
                    new User(2, "test2", "tester2", "second", 23, Gender.FEMALE, "asfas@gmail.nl", new WinRate(0, 0)));
            match.Scores = new int[] { 7, 1 };

            MatchMock matchMock = new MatchMock();
            IMatchRepository repository = matchMock;
            MatchService service = new MatchService(repository);

            // Act
            service.UpdateScore(match, new UserMock());

            // Assert
            List<Match> expectedMatch = service.GetMatches(tournament);
            Assert.AreEqual(expectedMatch[0].Scores[0], match.Scores[0]);
            Assert.AreEqual(expectedMatch[0].Scores[1], match.Scores[1]);
        }

        [TestMethod]
        public void UpdatedScoreOfMatchBadmintonSuccess()
        {
            Tournament tournament = new Tournament(4, "Badminton", "badminton", "Nowhere", new Badminton(1, "Badminton"), new TournamentTime(DateTime.Now.AddDays(10),
                DateTime.Now.AddDays(11)), "Round-robin", 10, 2);
            Match match = new Match(2, tournament, tournament.Time.Start,
                    new User(1, "test1", "tester1", "first", 21, Gender.MALE, "asd@gmail.com", new WinRate(0, 0)),
                    new User(2, "test2", "tester2", "second", 23, Gender.FEMALE, "asfas@gmail.nl", new WinRate(0, 0)));
            match.Scores = new int[] { 21, 1 };

            MatchMock matchMock = new MatchMock();
            IMatchRepository repository = matchMock;
            MatchService service = new MatchService(repository);

            // Act
            service.UpdateScore(match, new UserMock());

            // Assert
            List<Match> expectedMatch = service.GetMatches(tournament);
            Assert.AreEqual(expectedMatch[0].Scores[0], match.Scores[0]);
            Assert.AreEqual(expectedMatch[0].Scores[1], match.Scores[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ScoreExceptions))]
        public void UpdatedScoreOfMatchBadmintonExceptionScoreInvalid()
        {
            Tournament tournament = new Tournament(4, "Badminton", "badminton", "Nowhere", new Badminton(1, "Badminton"), new TournamentTime(DateTime.Now.AddDays(10),
                DateTime.Now.AddDays(11)), "Round-robin", 10, 2);
            Match match = new Match(2, tournament, tournament.Time.Start,
                    new User(1, "test1", "tester1", "first", 21, Gender.MALE, "asd@gmail.com", new WinRate(0, 0)),
                    new User(2, "test2", "tester2", "second", 23, Gender.FEMALE, "asfas@gmail.nl", new WinRate(0, 0)));
            match.Scores = new int[] { 30, 20 };

            MatchMock matchMock = new MatchMock();
            IMatchRepository repository = matchMock;
            MatchService service = new MatchService(repository);

            // Act
            service.UpdateScore(match, new UserMock());

            // Assert
            List<Match> expectedMatch = service.GetMatches(tournament);
            Assert.AreEqual(expectedMatch[0].Scores[0], match.Scores[0]);
            Assert.AreEqual(expectedMatch[0].Scores[1], match.Scores[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ScoreExceptions))]
        public void UpdateScoreExceptionFootballExceptionScoreInvalid()
        {
            // Arrange
            Tournament tournament = new Tournament(1, "Tournament1", "Description", "Location Test", new Football(1, "Soccer"), new TournamentTime(DateTime.Now.AddDays(10),
                DateTime.Now.AddDays(11)), "round-robin", 10, 2);
            Match match = new Match(1, tournament, tournament.Time.Start,
                    new User(1, "test1", "tester1", "first", 21, Gender.MALE, "asd@gmail.com", new WinRate(0, 0)),
                    new User(2, "test2", "tester2", "second", 23, Gender.FEMALE, "asfas@gmail.nl", new WinRate(0, 0)));
            match.Scores = new int[] { 3, 1 };

            MatchMock matchMock = new MatchMock();
            IMatchRepository repository = matchMock;
            MatchService service = new MatchService(repository);

            // Act
            service.UpdateScore(match, new UserMock());
        }

        [TestMethod]
        public void GetLeaderBoardOfTournamentSuccess()
        {
            // Arrange
            Tournament tournament = new Tournament(1, "Tournament1", "Description", "Location Test", new Football(1, "Soccer"), new TournamentTime(DateTime.Now.AddDays(10),
                DateTime.Now.AddDays(11)), "round-robin", 10, 2);

            MatchMock matchMock = new MatchMock();
            IMatchRepository repository = matchMock;
            MatchService service = new MatchService(repository);

            // Act
            List<User> usres = service.GetLeaderBoardOfTournament(tournament);

            // Assert
            Assert.IsNotNull(usres);
        }

        [TestMethod]
        [ExpectedException(typeof(TournamentException))]
        public void GetLeaderBoardOfTournamentExceptionNullTournament()
        {
            // Arrange
            Tournament tournament = null;

            MatchMock matchMock = new MatchMock();
            IMatchRepository repository = matchMock;
            MatchService service = new MatchService(repository);

            // Act
            List<User> usres = service.GetLeaderBoardOfTournament(tournament);
        }
    }
}
