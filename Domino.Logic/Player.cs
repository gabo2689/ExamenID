using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino.Logic
{
    class Player
    {
        public string Name { set; get; }
        public List<Tile> Hand { set; get; }

        public Player(string name)
        {
            Hand = new List<Tile>();
            Name = name;
        }

        public void AddPieceToHand(Tile tile)
        {
            Hand.Add(tile);
        }
    }
}
