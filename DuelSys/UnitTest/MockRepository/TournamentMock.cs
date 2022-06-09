using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer;

namespace UnitTest
{
    public class TournamentMock : ITournamentRepository
    {
        private List<Tournament> tournamentList = new List<Tournament>() { 
            new Tournament(1, "Tournament1", "Description", "Location Test", new Football(1, "Soccer"), new TournamentTime(DateTime.Now.AddDays(10), DateTime.Now.AddDays(11)),"round-robin", 10, 2),
            new Tournament(2, "Tester", "Descriptionsss", "Location 29", new LeagueOfLegends(2, "League of Legends"), new TournamentTime(DateTime.Now.AddDays(10), DateTime.Now.AddDays(11)), "round-robin", 10, 2)};

        private List<int> tournamentsid = new List<int>() { 1, 1, 2, 2};
        private List<int> contestantsid = new List<int>() { 2, 3, 2, 1};

        public List<string> ListOfSports()
        {
            // need database and no logic to be tested
            throw new NotImplementedException();
        }

        public List<Tournament> ListOfTournaments()
        {
            return tournamentList;
        }

        public int CreateTournament(Tournament tournament)
        {
            tournamentList.Add(tournament);

            return 1;
        }

        public void RegisterPlayer(int tournamentId, int playerId)
        {
            
        }

        public bool PlayerAlreadyRegistered(int tournamentId, int playerId)
        {
            bool valid = false;

            for (int i = 0; i < tournamentsid.Count; i++)
            {
                if (tournamentsid[i] == tournamentId)
                {
                    if (contestantsid[i] == playerId)
                    {
                        valid = true;
                    }
                }
            }

            return valid;
        }

        public void CancelRegistrationTournament(int tournamentId, int playerId)
        {
            throw new NotImplementedException();
        }

        public int CountOfPlayers(int tournamentId)
        {
            throw new NotImplementedException();
        }

        public List<User> ListOfUsers(int tournamentId)
        {
            throw new NotImplementedException();
        }

        public void UpdateTournament(Tournament tournament)
        {
            foreach (var tourne in tournamentList)
            {
                if (tourne.Id == tournament.Id)
                {
                    tourne.Name = tournament.Name;
                    tourne.Location = tournament.Location;
                }
            }
        }

        public void DeleteTournament(int tournamentId)
        {
            for (int i = 0; i < tournamentList.Count; i++)
            {
                if (tournamentList[i].Id == tournamentId)
                {
                    tournamentList.RemoveAt(i);
                }
            }
        }

        public bool CheckTournamentStateIfStarted(Tournament tournament)
        {
            throw new NotImplementedException();
        }

        public Tournament GetTournamentById(int id)
        {
            Tournament tournament = null;

            foreach (var tourne in tournamentList)
            {
                if (tourne.Id == id)
                {
                     tournament = tourne;
                }
            }

            return tournament;
        }
    }
}
