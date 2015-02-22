using System.Collections.Generic;

namespace Domino.Logic.Interfaces
{
    public interface IDatabase
    {
        void Save(List<PlayerGameStatistics> players);

        PlayerStatistics GetPlayerStatistics(string playerName);

        List<PlayerStatistics> GetAllPlayerStatistics();
    }
}