using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer;

namespace UnitTest
{
    public class MatchMock : IMatchRepository
    {
        private List<User> users = new List<User>() {
            new User(1, "test1", "tester1", "first", 21, Gender.MALE, "asd@gmail.com", new WinRate(0, 0)),
            new User(2, "test2", "tester2", "second", 23, Gender.FEMALE, "asfas@gmail.nl", new WinRate(0, 0)),
            new User(3, "test3", "tester3", "thirs", 27, Gender.UNSPECIFIED, "kgkdkgd@gmail.com", new WinRate(0, 0))};

        public List<Tournament> tournaments = new List<Tournament>() {
            new Tournament(1, "Tournament1", "Description", "Location Test", new Football(3, "Soccer"), new TournamentTime(DateTime.Now.AddDays(10),
                DateTime.Now.AddDays(11)),"round-robin", 10, 2),
            new Tournament(2, "Tournament2", "Something", "Somewhere", new LeagueOfLegends(4, "League Of Legends"), new TournamentTime(DateTime.Now.AddDays(10),
                DateTime.Now.AddDays(11)), "Round-robin", 10, 2),
            new Tournament(3, "NoPlayers", "No players", "Nowhere", new LeagueOfLegends(4, "League Of Legends"), new TournamentTime(DateTime.Now.AddDays(10),
                DateTime.Now.AddDays(11)), "Round-robin", 10, 2),
            new Tournament(4, "Badminton", "badminton", "Nowhere", new Badminton(1, "Badminton"), new TournamentTime(DateTime.Now.AddDays(10),
                DateTime.Now.AddDays(11)), "Round-robin", 10, 2)
        };

        private Dictionary<Tournament, List<User>> matchups;
        private List<Match> matches;

        public MatchMock()
        {
            matchups = new Dictionary<Tournament, List<User>>()
            {
                { tournaments[0], new List<User>() { users[0], users[1] } },
                { tournaments[1], new List<User>() { users[0], users[1], users[2] } },
                { tournaments[2], new List<User>() },
                { tournaments[3], new List<User>() { users[0], users[1], users[2]} }
            };

            matches = new List<Match>()
            {
                new Match(1, tournaments[0], tournaments[0].Time.Start, users[0], users[1]),
                new Match(2, tournaments[3], tournaments[3].Time.Start, users[0], users[1]),
                new Match(2, tournaments[3], tournaments[3].Time.Start, users[0], users[2]),
                new Match(2, tournaments[3], tournaments[3].Time.Start, users[1], users[2])
            };
        }

        public List<User> GetTournamentPlayers(int tournamentId)
        {
            List<User> users = new List<User>();

            foreach (var match in matchups)
            {
                if (match.Key.Id == tournamentId)
                {
                    foreach (var players in match.Value)
                    {
                        users.Add(players);
                    }
                }
            }

            return users;
        }

        public void WriteMatchesIntoDataBase(List<Match> matches)
        {
            foreach (var match in matches)
            {
                this.matches.Add(match);
            }
        }

        public List<Match> GetMatches(Tournament tournament)
        {
            List<Match> specificMatches = new List<Match>();

            foreach (var match in matches)
            {
                if (match.Tournament.Id == tournament.Id)
                {
                    specificMatches.Add(match);
                }
            }

            return specificMatches;
        }

        public void UpdateScoreOfMatch(Match updatedMatch)
        {
            foreach (var match in matches)
            {
                if (match.Id == updatedMatch.Id)
                {
                    match.Scores = updatedMatch.Scores;
                }
            }
        }
    }
}
