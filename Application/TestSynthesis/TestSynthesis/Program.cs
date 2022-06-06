// See https://aka.ms/new-console-template for more information
using TestSynthesis;

List<Match> matches = new List<Match>();
List<User> players = new List<User>() { new User(1, "drago"), new User(2, "miro"), new User(3, "pero")};
Tournament tournament = new Tournament(1, "Perso", "asd", "Eindhoven", new TournamentTime(DateTime.Now, DateTime.Now.AddDays(3)));

if (players.Count < 2 || players == null)
{
    Console.WriteLine("Error tournament cancelled.");
}

User lastPlayer = players[players.Count - 1];

foreach (var player1 in players)
{
    foreach (var player2 in players)
    {
        bool valid = true;
        if (player1 != player2)
        {
            for (int i = 0; i < matches.Count; i++)
            {
                if (matches[i].Player1.Id == player1.Id && matches[i].Player2.Id == player2.Id)
                {
                    valid = false;
                }
                if (matches[i].Player1.Id == player2.Id && matches[i].Player2.Id == player1.Id)
                {
                    valid = false;
                }
            }

            if (valid)
            {
                matches.Add(new Match(tournament, tournament.Time.Start, player1, player2));
            }
        }
    }
}

foreach (var match in matches)
{
    Console.WriteLine($"{match.Player1.UserName} -> {match.Player2.UserName} Date:{match.Date}");
}