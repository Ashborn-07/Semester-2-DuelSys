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
                }
            } catch (ConnectionException ex)
            {
                throw new ConnectionException(ex.Message);
            }
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
    }
}
