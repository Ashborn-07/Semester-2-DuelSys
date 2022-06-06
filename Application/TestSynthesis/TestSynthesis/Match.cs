using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSynthesis
{
    public class Match
    {
        private int id;
        private Tournament tournament;
        private DateTime date;
        private User player1;
        private User player2;
        private int[] scores;
        private int winner;

        public int Id { get { return this.id; } }
        public Tournament Tournament { get { return this.tournament; } }
        public DateTime Date { get { return this.date; } }
        public User Player1 { get { return this.player1; } }
        public User Player2 { get { return this.player2; } }
        public int[] Scores { get { return this.scores; } set { this.scores = value; } }
        public int Winner { get { return this.winner; } set { this.winner = value; } }

        public Match(int id, Tournament tournament, DateTime date, User player1, User player2)
        {
            this.id = id;
            this.tournament = tournament;
            this.date = date;
            this.player1 = player1;
            this.player2 = player2;
        }

        public Match(Tournament tournament, DateTime date, User player1, User player2)
        {
            this.tournament = tournament;
            this.date = date;
            this.player1 = player1;
            this.player2 = player2;
        }
    }
}
