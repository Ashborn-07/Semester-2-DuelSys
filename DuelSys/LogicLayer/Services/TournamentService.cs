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
    }
}
