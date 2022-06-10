using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class MatchService
    {
        private IMatchRepository repository;

        public MatchService(IMatchRepository repository)
        {
            this.repository = repository;
        }

        public void CreateSchedule(Tournament tournament)
        {
            List<User> players = new List<User>();
            try
            {
                players = repository.GetTournamentPlayers(tournament.Id);
            }
            catch (ConnectionException)
            {
                throw new ConnectionException("Can't connect to database check Cisco.");
            }
            catch (Exception)
            {
                throw new MatchesException("Error in getting players for the tournament.");
            }

            List<Match> matches = CreateRoundRobinSchedule(players, tournament);

            if (matches != null)
            {
                //repository. write into database all the matches
                try
                {
                    repository.WriteMatchesIntoDataBase(matches);
                }
                catch (ConnectionException)
                {
                    throw new ConnectionException("Can't connect to database check Cisco.");
                }
                catch (Exception)
                {
                    throw new MatchesException("Error in writing into database.");
                }
            }
        }


        private List<Match> CreateRoundRobinSchedule(List<User> players, Tournament tournament)
        {
            List<Match> matches = new List<Match>();

            if (players.Count < tournament.Min_players || players == null)
            {
                throw new MatchesException($"Not enough players. You need {tournament.Min_players}");
            }

            User lastPlayer = players[players.Count - 1];

            foreach (var player1 in players)
            {
                foreach (var player2 in players)
                {
                    bool valid = true;
                    if (player1 != player2)
                    {
                        for (int i = 0; i < matches.Count; i++)
                        {
                            if (matches[i].Player1.Id == player1.Id && matches[i].Player2.Id == player2.Id)
                            {
                                valid = false;
                            }
                            if (matches[i].Player1.Id == player2.Id && matches[i].Player2.Id == player1.Id)
                            {
                                valid = false;
                            }
                        }

                        if (valid)
                        {
                            matches.Add(new Match(tournament, tournament.Time.Start, player1, player2));
                        }
                    }
                }
            }

            return matches;
        }

        public List<Match> GetMatches(Tournament tournament)
        {
            List<Match> matches = repository.GetMatches(tournament);

            if (matches == null || matches.Count < 1)
            {
                throw new MatchesException("Matches were not found");
            }

            return matches;
        }

        public void UpdateScore(Match match, IUserRepository userRepository)
        {
            Match updatedMatch = match.Tournament.Sport.MatchResultValidation(match);

            repository.UpdateScoreOfMatch(updatedMatch);

            User player1 = updatedMatch.Player1;
            User player2 = updatedMatch.Player2;
            bool valid = false;

            if (updatedMatch.Winner == updatedMatch.Player1.Id)
            {
                player1.WinRate = new WinRate(player1.WinRate.Wins + 1, player1.WinRate.Loses);
                player2.WinRate = new WinRate(player2.WinRate.Wins, player2.WinRate.Loses + 1);
                valid = true;
            }
            else if (updatedMatch.Winner == updatedMatch.Player2.Id)
            {
                player1.WinRate = new WinRate(player1.WinRate.Wins, player1.WinRate.Loses + 1);
                player2.WinRate = new WinRate(player2.WinRate.Wins + 1, player2.WinRate.Loses);
                valid = true;
            }

            if (valid)
            { 
                userRepository.UpdateUsersWinrate(new List<User> { player1, player2 });
            }
        }

        public List<User> GetLeaderBoardOfTournament(Tournament tournament)
        {
            if (tournament == null)
            {
                throw new TournamentException("Error occured when recieving tournament");
            }

            List<Match> matches = repository.GetMatches(tournament);
            List<User> players = GetPlayersOfTournament(matches);

            foreach (var match in matches)
            {
                foreach (var player in players)
                {
                    if (match.Winner == player.Id)
                    {
                        player.WinRate.Wins += 1;
                    }
                }
            }

            return players.OrderByDescending(x => x.WinRate.Wins).ThenBy(x => x.UserName).ToList();
        }

        private List<User> GetPlayersOfTournament(List<Match> matches)
        {
            List<User> players = new List<User>();

            foreach (var match in matches)
            {
                int index = players.FindIndex(item => item.Id == match.Player1.Id);
                if (index == -1)
                {
                    User newPlayer = match.Player1;
                    newPlayer.WinRate = new WinRate(0, 0);
                    players.Add(newPlayer);
                }

                int index1 = players.FindIndex(item => item.Id == match.Player2.Id);
                if (index1 == -1)
                {
                    User newPlayer = match.Player2;
                    newPlayer.WinRate = new WinRate(0, 0);
                    players.Add(match.Player2);
                }
            }

            if (players.Count > 0)
            {
                return players;
            }

            throw new TournamentException("Error in retrieving players for leaderboard");
        }
    }
}
