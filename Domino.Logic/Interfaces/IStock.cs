using System.Collections.Generic;

namespace Domino.Logic.Interfaces
{
    public interface IStock
    {
        List<Tile> Tiles { get; set; }
        void Shuffle(int swapsAmount);
        Tile PopFromStock();
        void SwapTilesRandomly();
    }
}