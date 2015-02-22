using Domino.Logic.Interfaces;

namespace Domino.Logic
{
    public class PlayerGameStatistics : IPlayerGameStatistics
    {
        public PlayerGameStatistics(string playerName, bool isWinner)
        {
            PlayerName = playerName;
            IsWinner = isWinner;
        }

        public string PlayerName { get; set; }

        public bool IsWinner { get; set; }

        public PlayerStatistics GetInitialPlayerStatistics()
        {
            return IsWinner ? new PlayerStatistics(this.PlayerName, 1, 0) : new PlayerStatistics(this.PlayerName, 0, 1);
        }
    }
}