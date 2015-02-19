using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino.Logic.Interfaces;

namespace Domino.Logic
{
    class RandomNumber : IRandom
    {
        public int GetRandomPosition()
        {
            return 0;
        }

        public List<Tile> ShufflePit(List<Tile> pitContainer)
        {
            var Random = new Random();
            var list = pitContainer.Select(d => new KeyValuePair<int, Tile>(Random.Next(), d)).ToList();
            var temporalList = from item in list
                               orderby item.Key
                               select item;
            var sortedList = new List<Tile>();
            var index = 0;
            foreach (var pair in temporalList)
            {
                sortedList.Add(pair.Value);
                index++;
            }
            return sortedList;
        }
    }
}
