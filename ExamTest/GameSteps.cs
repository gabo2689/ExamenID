using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Domino.Logic;
using Microsoft.Win32;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace ExamTest
{
    [Binding]
    public class GameSteps
    {
        private Game _game;
        private readonly Player _player1 = new Player("Dennis");
        private readonly Player _player2 = new Player("Edward");
        Tile _tile;

        

        [Given(@"the players have an empty hand")]
    public void GivenThePlayersHaveAnEmptyHand()
            {
                _game = new Game();
                _game.AddNewPlayer(_player1);
                _game.AddNewPlayer(_player2);
            }

        [When(@"the game begins and the players takes (.*) tiles")]
    public void WhenTheGameBeginsAndThePlayersTakesTiles(int p0)
            {
                _game.InitializePlayersHand(p0);
            }


        [Then(@"the two players must have (.*) tiles each")]
    public void ThenTheTwoPlayersMustHaveTilesEach(int p0)
            {
                var player1Tiles = _game.Players.ElementAt(0).Hand.Count;
                var player2Tiles = _game.Players.ElementAt(1).Hand.Count;
                Assert.AreEqual(p0, player1Tiles, player2Tiles);
            }

        [Given(@"a brand new game is about to start")]
    public void GivenABrandNewGameIsAboutToStart()
            {
                _game = new Game();
                _game.AddNewPlayer(_player1);
                _game.AddNewPlayer(_player2);

            }

        [ When(@"the player one has the next set of tiles")]
    public void WhenThePlayerOneHasTheNextSetOfTiles(Table table)
            {
                _game.GetPlayerAtPosition(0).Hand = TestUtility.ConvertTilesTableToListTiles(table);
            }

        [When(@"the player two has the next set of tiles the highest double")]
    public void WhenThePlayerTwoHasTheNextSetOfTilesTheHighestDouble 
            (Table table)
            {
                _game.GetPlayerAtPosition(1).Hand = TestUtility.ConvertTilesTableToListTiles(table);
            }

        [Then(@"the player ""(.*)"" has to start the game")]
    public void ThenThePlayerHasToStartTheGame(int p0)
            {
                Assert.AreEqual(p0, _game.GetPlayerInitial() + 1);
            }

        [ When(@"the player two has the next set of tiles")]
    public void WhenThePlayerTwoHasTheNextSetOfTiles(Table table)
            {
                _game.GetPlayerAtPosition(1).Hand = TestUtility.ConvertTilesTableToListTiles(table);
            }


        [Given(@"a tile with (.*) in head  and (.*) in tail")]
    public void GivenATileWithInHeadAndInTail(int head, int tail)
            {
                _tile = new Tile(head, tail);
            }

        [When(@"we call swap")]
    public void WhenWeCallSwap()
            {
                _tile.Swap();
            }

        [Then(@"the tile will have (.*) in head and (.*) in tail")]
    public void ThenTheTailWillHaceInHeadAndInTail(int head, int tail)
            {
                bool areEquals = _tile.Head == head && _tile.Tail == tail;
                Assert.AreEqual(areEquals, true);
            }

            [Given(@"a game started")]
            public void GivenAGameStarted()
            {
                _game = new Game();
                _game.AddNewPlayer(_player1);
                _game.AddNewPlayer(_player2);
                _game.Board.Tiles.ElementAt(10).Head = 2;
                _game.Board.Tiles.ElementAt(10).Tail = 2;
            }

            [When(@"the player one move a tile to the board")]
            public void WhenThePlayerOneMoveATileToTheBoard()
            {
               _game.Move(5,9);
            }


            [Then(@"is the turn of the player (.*)")]
            public void ThenIsTheTurnOfThePlayer(int p0)
            {
                Assert.AreEqual(p0,_game.PlayerTurn+1);
            }

            [Given(@"is the turn of player one")]
            public void GivenIsTheTurnOfPlayerOne()
            {
                _game=new Game();
                _game.AddNewPlayer(_player1);
                _game.AddNewPlayer(_player2);
            }

            [When(@"the board has the next set of tiles")]
            public void WhenTheBoardHasTheNextSetOfTiles(Table table)
            {
                _game.Board.Tiles = TestUtility.ConvertTilesTableToListTiles(table).ToArray();
            }

            [When(@"the player has the next hand")]
            public void WhenThePlayerHasTheNextHand(Table table)
            {
                _game.GetPlayerAtPosition(0).Hand = TestUtility.ConvertTilesTableToListTiles(table);
            }

        private Tile tile;
            [When(@"the player place this tile on the board")]
            public void WhenThePlayerPlaceThisTileOnTheBoard(Table table)
            {
                tile = table.CreateInstance<Tile>();
                _game.GetPlayerAtPosition(0).PopTileAtIndex(0);
                _game.Board.AddTile(7,tile);
            }

            [Then(@"the tiles on board must be")]
            public void ThenTheTilesOnBoardMustBe(Table table)
            {
                var listOfTiles = table.CreateSet<Tile>().ToArray();
                Assert.IsTrue(_game.Board.Tiles.Contains(tile));
            }


        }

}

