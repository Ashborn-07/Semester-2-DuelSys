using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Football : Sport
    {
        public Football(int id, string name) : base(id, name)
        {
        }

        public override Match MatchResultValidation(Match match)
        {
            if (match == null)
            {
                throw new ScoreExceptions("Error when retrieving match");
            }

            int player1score = match.Scores[0];
            int player2score = match.Scores[1];
            bool valid = false;

            if (player1score == 7 || player2score == 7)
            {
                if (player1score - player2score >= 1)
                {
                    match.Winner = match.Player1.Id;
                    valid = true;
                }

                if (player2score - player1score >= 1)
                {
                    match.Winner = match.Player2.Id;
                    valid = true;
                }
            }

            if (valid)
            {
                return match;
            }

            throw new ScoreExceptions("Invalid scores");
        }
    }
}
