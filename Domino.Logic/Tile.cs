using System;
using Domino.Logic.Interfaces;

namespace Domino.Logic
{
    public class Tile : ITile
    {
        public Tile(int tileHead, int tileTail)
        {
            this.Head = tileHead;
            this.Tail = tileTail;
            IsDouble = false;
        }
        
        public bool IsDouble { get; set; }
        public int Head { get; set; }
        public int Tail { get; set; }
        public bool HeadTaked { get; set; }
        public bool TailTaked { get; set; }

        public void Swap()
        {
            var temp = Head;
            Head = Tail;
            Tail = temp;
        }

        public int CompareTo(object obj)
        {
            if (obj is Tile)
            {
                var tile = (Tile)obj;
                if (tile.Head == this.Head && tile.Tail == this.Tail)
                    return 0;
                else
                {
                    return -1;
                }
            }
            throw new Exception("No are equals");
        }

        public override bool Equals(object obj)
        {
            return CompareTo(obj) == 0;
        }
    }
}