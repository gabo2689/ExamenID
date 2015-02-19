using System.Collections.Generic;

namespace Domino.Logic.Interfaces
{
    public interface IPlayer
    {
        string Name { set; get; }
        List<Tile> Hand { set; get; }
        int Points { set; get; }
        void AddTileToHand(Tile tile);
        Tile GetHighestDouble();
    }
}