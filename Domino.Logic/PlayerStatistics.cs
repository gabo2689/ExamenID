namespace Domino.Logic
{
    public class PlayerStatistics
    {
        public PlayerStatistics(string playerName, int wins, int losses)
        {
            PlayerName = playerName;
            Wins = wins;
            Losses = losses;
        }

        public string PlayerName { get; set; }

        public int Wins { get; set; }

        public int Losses { get; set; }
    }
}