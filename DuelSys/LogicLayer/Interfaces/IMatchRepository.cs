using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public interface IMatchRepository
    {
        public abstract List<User> GetTournamentPlayers(int tournamentId);

        public abstract void WriteMatchesIntoDataBase(List<Match> matches);
         
        public abstract List<Match> GetMatches(Tournament tournament);

        public abstract void UpdateScoreOfMatch(Match match);
    }
}
