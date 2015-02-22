using System.Collections.Generic;

namespace Domino.Logic.Interfaces
{
    public interface IRandom
    {
        int GetRandomPosition();
        List<Tile> ShufflePit(List<Tile> pitContainer);
    }
}