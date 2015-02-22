using System.Collections.Generic;

namespace Domino.Logic.Interfaces
{
    public interface IDatabase
    {
        void Save(List<IPlayerGameStatistics> players);

        PlayerStatistics GetPlayerStatistics(string playerName);

        List<PlayerStatistics> GetAllPlayerStatistics();
    }
}