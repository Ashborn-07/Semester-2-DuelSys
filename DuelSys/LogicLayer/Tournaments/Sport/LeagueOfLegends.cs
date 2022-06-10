﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class LeagueOfLegends : Sport
    {
        public LeagueOfLegends(int id, string name) : base(id, name)
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

            if (player1score == 3 || player2score == 3)
            {
                if (player1score == 3 && player2score == 3)
                {
                    throw new ScoreExceptions("System does not handle ties");
                }

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

            throw new ScoreExceptions("Invalid scores check rules");
        }
    }
}
