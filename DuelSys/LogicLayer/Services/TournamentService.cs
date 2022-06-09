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
                Tournament tournament = repository.GetTournamentById(id);

                if (tournament != null)
                {
                    return tournament;
                }
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
            if (CreateTournamentDataValidation(tournament))
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
            if (UpdateTournamentDataValidation(tournament))
            {
                try
                {
                    repository.UpdateTournament(tournament);
                }
                catch (ConnectionException ex)
                {
                    throw new ConnectionException(ex.Message);
                }
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

        private bool CreateTournamentDataValidation(Tournament tournament)
        {
            if (tournament.Name.Length <= 40 && tournament.Location.Length <= 60)
            {
                if (tournament.Time.Start <= tournament.Time.End)
                {
                    if (tournament.Max_players >= tournament.Min_players)
                    {
                        return true;
                    }

                    throw new TournamentException("Invalid max and min players");
                }

                throw new TournamentException("Invalid start and end dates");
            }

            throw new TournamentException("Tornament name/location are too long");
        }

        private bool UpdateTournamentDataValidation(Tournament tournament)
        {
            if (tournament.Name.Length <= 40)
            {
                if (tournament.Location.Length <= 60)
                {
                    return true;
                }

                throw new TournamentException("Location is too long");
            }

            throw new TournamentException("Name is too long");
        }
    }
}
