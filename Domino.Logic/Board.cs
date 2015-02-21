using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino.Logic
{
    public class Board
    {
        public static int AmountTiles = 28;
        public Tile[] Tiles = new Tile[AmountTiles];

        public int TilesAmount { set; get; }

        public void AddTile(int position, Tile tile)
        {
            Tiles[position] = tile;
            TilesAmount++;
        }

        public void Initialize()
        {
            for (int i = 0; i < Tiles.Length; i++)
            {
                if (Tiles[i] == null)
                    Tiles[i] = new Tile(-1, -1);
            }
        }
    }
}