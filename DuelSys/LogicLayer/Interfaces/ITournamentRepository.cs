using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public interface ITournamentRepository
    {
        public abstract List<string> ListOfSports();

        public abstract List<Tournament> ListOfTournaments();

        public abstract int CreateTournament(Tournament tournament);

        public abstract void RegisterPlayer(int tournamentId, int playerId);

        public abstract bool PlayerAlreadyRegistered(int tournamentId, int playerId);

        public abstract void CancelRegistrationTournament(int tournamentId, int playerId);

        public abstract int CountOfPlayers(int tournamentId);

        public abstract List<User> ListOfUsers(int tournamentId);

        public abstract void UpdateTournament(Tournament tournament);

        public abstract void DeleteTournament(int tournamentId);
    }
}
