using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino.Logic.Interfaces;

namespace Domino.Logic
{
    public class Player : IPlayer
    {
        public string Name { set; get; }
        public List<Tile> Hand { set; get; }
        public int Points { set; get; }

        public Player(string name)
        {
            Hand = new List<Tile>();
            Name = name;
        }

        public void AddTileToHand(Tile tile)
        {
            Hand.Add(tile);
        }

        public Tile GetHighestDouble()
        {
            var higherTile = new Tile(-1, -1);
            var sumTile = higherTile;
            int sum1;
            int sum2;
            foreach (var tile in Hand)
            {
                if (tile.IsDouble)
                {
                    if (tile.Head > higherTile.Head)
                        higherTile = tile;
                }
                else
                {
                    sum1 = tile.Head + tile.Tail;
                    sum2 = sumTile.Head + sumTile.Tail;
                    if (sum1 > sum2)
                        sumTile = tile;
                }
                
            }
            if(higherTile.IsDouble)
                return higherTile;
            return sumTile;
        }

        public Tile PopTileAtIndex(int index)
        {
            var tile = Hand.ElementAt(index);
            Hand.RemoveAt(index);
            return tile;

        }
    }
}
