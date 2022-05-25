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
    }
}
