using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace UnitTest
{
    [TestClass]
    public class TournamentUnitTest
    {
        [TestMethod]
        public void CreateTournamentSuccess()
        {
            // Arrange
            Tournament tournament = new Tournament(6, "success", "dexription", "somewhere", new LeagueOfLegends(4, "Esports"), new TournamentTime(DateTime.Now.AddDays(9), DateTime.Now.AddDays(10)), "Round-robin", 10, 2);

            TournamentMock tournamentMock = new TournamentMock();
            ITournamentRepository repository = tournamentMock;
            TournamentService service = new TournamentService(repository);

            // Act
            service.CreateTournament(tournament);

            // Assert
            List<Tournament> tournamentList = tournamentMock.ListOfTournaments();
            Assert.AreEqual(tournament.Id, tournamentList.Last().Id);
        }

        [TestMethod]
        [ExpectedException(typeof(TournamentException))]
        public void CreateTournamentExceptionName()
        {
            // Arrange
            Tournament tournament = new Tournament(6, "asdsadasdasdasdsadasdasdasdasdasdasdasdasdasdasdasd", "dexription", "somewhere", new LeagueOfLegends(4, "Esports"), new TournamentTime(DateTime.Now.AddDays(9), DateTime.Now.AddDays(10)), "Round-robin", 10, 2);

            TournamentMock tournamentMock = new TournamentMock();
            ITournamentRepository repository = tournamentMock;
            TournamentService service = new TournamentService(repository);

            // Act
            service.CreateTournament(tournament);
        }

        [TestMethod]
        [ExpectedException(typeof(TournamentException))]
        public void CreateTournamentExceptionLocation()
        {
            // Arrange
            Tournament tournament = new Tournament(6, "test2fail", "dexription", "asdsadasdasdasdsadasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasd", new LeagueOfLegends(4, "Esports"), new TournamentTime(DateTime.Now.AddDays(9), DateTime.Now.AddDays(10)), "Round-robin", 10, 2);

            TournamentMock tournamentMock = new TournamentMock();
            ITournamentRepository repository = tournamentMock;
            TournamentService service = new TournamentService(repository);

            // Act
            service.CreateTournament(tournament);
        }

        [TestMethod]
        [ExpectedException(typeof(TournamentException))]
        public void CreateTournamentExceptionDate()
        {
            // Arrange
            Tournament tournament = new Tournament(6, "test2fail", "dexription", "1223", new LeagueOfLegends(4, "Esports"), new TournamentTime(DateTime.Now.AddDays(19), DateTime.Now.AddDays(10)), "Round-robin", 10, 2);

            TournamentMock tournamentMock = new TournamentMock();
            ITournamentRepository repository = tournamentMock;
            TournamentService service = new TournamentService(repository);

            // Act
            service.CreateTournament(tournament);
        }

        [TestMethod]
        public void UpdateTournamentSuccess()
        {
            // Arrange
            Tournament tournament = new Tournament(1, "test21", "kilogore", "svetiluna", new Football(1, "Soccer"), new TournamentTime(DateTime.Now.AddDays(10), DateTime.Now.AddDays(11)), "round-robin", 10, 2);

            TournamentMock tournamentMock = new TournamentMock();
            ITournamentRepository repository = tournamentMock;
            TournamentService service = new TournamentService(repository);

            // Act
            service.UpdateTournament(tournament);

            // Assert
            List<Tournament> tournaments = tournamentMock.ListOfTournaments();
            Assert.AreEqual(tournament.Name, tournaments[0].Name);
            Assert.AreEqual(tournament.Location, tournaments[0].Location);
        }

        [TestMethod]
        [ExpectedException(typeof(TournamentException))]
        public void UpdateTournamentExceptionName()
        {
            // Arrange
            Tournament tournament = new Tournament(1, "asdsadasdasdasdsadasdasdasdasdasdasdasdasdasdasdasd", "kilogore", "svetiluna", new Football(1, "Soccer"), new TournamentTime(DateTime.Now.AddDays(10), DateTime.Now.AddDays(11)), "round-robin", 10, 2);

            TournamentMock tournamentMock = new TournamentMock();
            ITournamentRepository repository = tournamentMock;
            TournamentService service = new TournamentService(repository);

            // Act
            service.UpdateTournament(tournament);
        }

        [TestMethod]
        [ExpectedException(typeof(TournamentException))]
        public void UpdateTournamentExceptionLocation()
        {
            // Arrange
            Tournament tournament = new Tournament(1, "test21", "kilogore", "asdsadasdasdasdsadasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasd", new Football(1, "Soccer"), new TournamentTime(DateTime.Now.AddDays(10), DateTime.Now.AddDays(11)), "round-robin", 10, 2);

            TournamentMock tournamentMock = new TournamentMock();
            ITournamentRepository repository = tournamentMock;
            TournamentService service = new TournamentService(repository);

            // Act
            service.UpdateTournament(tournament);
        }

        [TestMethod]
        [ExpectedException(typeof(MatchesException))]
        public void RegisterPlayerTournamentExceptionAlreadyRegistered()
        {
            // Arrange
            int tournamentId = 1;
            int playerId = 2;

            TournamentMock tournamentMock = new TournamentMock();
            ITournamentRepository repository = tournamentMock;
            TournamentService service = new TournamentService(repository);

            // Act
            service.RegisterPlayer(tournamentId, playerId);
        }

        [TestMethod]
        public void GetTournamentByIdSuccess()
        {
            // Arrange
            int tournamentId = 1;

            TournamentMock tournamentMock = new TournamentMock();
            ITournamentRepository repository = tournamentMock;
            TournamentService service = new TournamentService(repository);

            // Act
            Tournament tournament = service.GetTournamentById(tournamentId);
            Assert.AreEqual(tournamentId, tournament.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(TournamentException))]
        public void GetTournamentByIdException()
        {
            // Arrange
            int tournamentId = -1;

            TournamentMock tournamentMock = new TournamentMock();
            ITournamentRepository repository = tournamentMock;
            TournamentService service = new TournamentService(repository);

            // Act
            Tournament tournament = service.GetTournamentById(tournamentId);
        }
    }
}
