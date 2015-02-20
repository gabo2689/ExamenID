using Domino.Logic;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace ExamTest
{
    internal class TestUtility
    {
        public static List<Domino.Logic.Tile> ConvertTilesTableToListTiles(Table table)
        {
            var tiles = new List<Domino.Logic.Tile>();
            foreach (TableRow row in table.Rows)
            {
                tiles.Add(new Domino.Logic.Tile(Convert.ToInt32(row["Tile Head"]), Convert.ToInt32(row["Tile Tail"])));
            }
            return tiles;
        }
    }
}