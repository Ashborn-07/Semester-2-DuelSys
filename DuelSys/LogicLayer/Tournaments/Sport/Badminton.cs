using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Badminton : Sport
    {
        public Badminton(int id, string name) : base(id, name)
        {
        }

        public override Match MatchResultValidation(Match match)
        {
            if (match == null)
            {
                throw new ScoreExceptions("Error occured while retrieving the information of the match.");
            }

            int player1Score = match.Scores[0];
            int player2Score = match.Scores[1];
            bool valid = false;

            if (player1Score >= 21 || player2Score >= 21)
            {
                if (player1Score >= 21 && player2Score >= 21)
                {
                    if (player1Score == 30 && player2Score == 30)
                    {
                        throw new ScoreExceptions("System does not handle ties.");
                    }
                    
                    if (player1Score == 30 && player2Score < 30 && player2Score >= 28)
                    {
                        match.Winner = match.Player1.Id;
                        valid = true;
                    }

                    if (player2Score == 30 && player1Score < 30 && player1Score >= 28)
                    {
                        match.Winner = match.Player2.Id;
                        valid = true;
                    }

                    if (player1Score - player2Score == 2)
                    {
                        match.Winner = match.Player1.Id;
                        valid = true;
                    }

                    if (player2Score - player1Score == 2)
                    {
                        match.Winner = match.Player2.Id;
                        valid = true;
                    }
                } else
                {
                    if (player1Score == 21 || player2Score == 21)
                    {
                        if (player1Score - player2Score >= 2)
                        {
                            match.Winner = match.Player1.Id;
                            valid = true;
                        }

                        if (player2Score - player1Score >= 2)
                        {
                            match.Winner = match.Player2.Id;
                            valid = true;
                        }
                    }
                }
            }

            if (valid)
            {
                return match;
            }

            throw new ScoreExceptions("Invalid scores please read the rules.");
        }
    }
}
