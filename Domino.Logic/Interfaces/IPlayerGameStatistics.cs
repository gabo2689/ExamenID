namespace Domino.Logic.Interfaces
{
    public interface IPlayerGameStatistics
    {
        string PlayerName { get; set; }
        bool IsWinner { get; set; }
        PlayerStatistics GetInitialPlayerStatistics();
    }
}