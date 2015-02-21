using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ExamTest
{
    [Binding]
    public class PlayerSteps
    {
        //internal Table TileFromStock;
        // TableRow TileGetting;
        ///private Tile _tile = new Tile();
        //private List<Tile> TileFromStock = new List<Tile>();
        //private List<Tile> TileGiven = new List<Tile>();
        //private List<Tile> PlayerTile = new List<Tile>();
            
            
        [Given(@"the list from stock exist from board")]
        public void GivenTheListFromStockExistFromBoard(Table table)
        {

            //TileFromStock = table.CreateSet<Tile>().ToList();

        }

        [Given(@"the player get (.*) tile from stock")]
        public void GivenThePlayerGetTileFromStock(int p0)
        {
            //for (int i = 0; i < p0; i++)
            //{
            //    TileGiven.Add(TileFromStock.FirstOrDefault());
            //}

        }

        [Then(@"remove (.*) tile from stock")]
        public void ThenRemoveTileFromStock(int p0)
        {
            //for (int i = 0; i < p0; i++)
            //{
            //    TileFromStock.RemoveAt(0);
            //}

        }

        [Then(@"add (.*) tile to player list")]
        public void ThenAddTileToPlayerList(int p0, Table table)
        {
            //PlayerTile = table.CreateSet<Tile>().ToList();

            //for (int i = 0; i < p0; i++)
            //{
            //    PlayerTile.Add(TileGiven.FirstOrDefault());
            //}

           
        }


       

    }

     //internal class Tile
     //   {
     //       public int head { get; set; }
     //       public int tail { get; set; }
     //   }



}


    


