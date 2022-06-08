using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace LogicLayer
{
    public class TournamentService
    {
        ITournamentRepository repository;

        public TournamentService(ITournamentRepository repository)
        {
            this.repository = repository;
        }

        public Tournament GetTournamentById(int id)
        {
            if (id != 0)
            {
                return repository.GetTournamentById(id);
            }

            throw new TournamentException("No tournament was found with this id");
        }

        public List<string> GetListOfSports()
        {
            try
            {
                return repository.ListOfSports();
            }
            catch (ConnectionException ex)
            {
                throw new ConnectionException(ex.Message);
            }

        }

        public List<Tournament> GetTournaments()
        {
            List<Tournament> tournaments;

            try
            {
                tournaments = repository.ListOfTournaments();
            }
            catch (ConnectionException ex)
            {
                throw new ConnectionException(ex.Message);
            }


            return tournaments.OrderBy(x => x.Time.Start).ToList();
        }

        public List<Tournament> GetAllStartedTournaments()
        {
            List<Tournament> tournaments;
            List<Tournament> startedTournaments = new List<Tournament>();

            try
            {
                tournaments = repository.ListOfTournaments();
            } catch (ConnectionException ex)
            {
                throw new ConnectionException(ex.Message);
            }

            foreach (var tournament in tournaments)
            {
                if (repository.CheckTournamentStateIfStarted(tournament))
                {
                    startedTournaments.Add(tournament);
                }
            }

            if (startedTournaments.Count > 0)
            {
                return startedTournaments;
            }

            throw new TournamentException("There are no started tournaments currently");
        } 

        public void CreateTournament(Tournament tournament)
        {
            try
            {
                repository.CreateTournament(tournament);
            }
            catch (ConnectionException ex)
            {
                throw new ConnectionException(ex.Message);
            }

        }

        public void RegisterPlayer(int tournamentId, int PlayerId)
        {
            try
            {
                if (!repository.PlayerAlreadyRegistered(tournamentId, PlayerId))
                {
                    repository.RegisterPlayer(tournamentId, PlayerId);
                    return;
                }
            } catch (ConnectionException ex)
            {
                throw new ConnectionException(ex.Message);
            }

            throw new MatchesException("Player already registered");
        }

        public bool PleyerAlreadyRegistered(int tournamentId, int PlayerId)
        {
            try
            {
                return repository.PlayerAlreadyRegistered(tournamentId, PlayerId);
            } catch (ConnectionException ex)
            {
                throw new ConnectionException(ex.Message);
            }
        }

        public void CancelRegistrationTournament(int tournamentId, int playerId)
        {
            try
            {
                repository.CancelRegistrationTournament(tournamentId, playerId);
            } catch (ConnectionException ex)
            {
                throw new ConnectionException(ex.Message);
            }
        }

        public int PlayerCountOfTournament(int tournamentId)
        {
            try
            {
                return repository.CountOfPlayers(tournamentId);
            } catch (ConnectionException ex)
            {
                throw new ConnectionException(ex.Message);
            }
        }

        public List<User> ListOfUsersOfTournament(int tournamentId)
        {
            try
            {
                return repository.ListOfUsers(tournamentId);
            } catch (ConnectionException ex)
            {
                throw new ConnectionException(ex.Message);
            }
        }

        public void UpdateTournament(Tournament tournament)
        {
            try
            {
                repository.UpdateTournament(tournament);
            } catch (ConnectionException ex)
            {
                throw new ConnectionException(ex.Message);
            }
        }

        public void DeleteTournament(int tournamentId)
        {
            try
            {
                repository.DeleteTournament(tournamentId);
            } catch (ConnectionException ex)
            {
                throw new ConnectionException(ex.Message);
            }
        }

        public string GetTournamentStatus(Tournament tournament)
        {
            if (repository.CheckTournamentStateIfStarted(tournament))
            {
                return "started";
            }

            if (tournament.Time.Start < DateTime.Now.AddDays(7))
            {
                return "expired";
            }

            return "participate";
        }

        public List<User> GetLeaderBoardOfTournament(Tournament tournament, IMatchRepository matchRepository)
        {
            if (tournament == null)
            {
                throw new TournamentException("Error occured when recieving tournament");
            }

            List<Match> matches = matchRepository.GetMatches(tournament);
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
