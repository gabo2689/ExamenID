using System;
using System.Linq;
using System.Runtime.InteropServices;
using Domino.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace ExamTest
{
    [Binding]
    public class GameSteps
    {
        private Game _game;
        private readonly Player _player1 = new Player("Dennis");
        private readonly Player _player2 = new Player("Edward");
        Tile _tile;
        private int _winner = -1;

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

        [When(@"the player one has the next set of tiles")]
        public void WhenThePlayerOneHasTheNextSetOfTiles(Table table)
        {
            _game.GetPlayerAtPosition(0).Hand = TestUtility.ConvertTilesTableToListTiles(table);
            _game.InitializeTurns();
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

        [When(@"the player two has the next set of tiles")]
        public void WhenThePlayerTwoHasTheNextSetOfTiles(Table table)
        {
            _game.GetPlayerAtPosition(1).Hand = TestUtility.ConvertTilesTableToListTiles(table);
            _game.InitializeTurns();
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
        }

        [Given(@"a started board")]
        public void GivenAStartedBoard()
        {
            _game.Board.Tiles.ElementAt(10).Head = 2;
            _game.Board.Tiles.ElementAt(10).Tail = 2;
        }

        [When(@"the player one move a tile to the board")]
        public void WhenThePlayerOneMoveATileToTheBoard()
        {
            _game.Move(5, 9);
        }

        [Then(@"is the turn of the player (.*)")]
        public void ThenIsTheTurnOfThePlayer(int p0)
        {
            Assert.AreEqual(p0, _game.PlayerTurn+1);
        }

        [When(@"the board has just the tile (.*) in head and (.*) in tail in the middle")]
        public void WhenTheBoardHasJustTheTileInHeadAndInTailInTheMiddle(int p0, int p1)
        {
            _game.InitializeBoard();
            _game.Board.Tiles.ElementAt(14).Head = p0;
            _game.Board.Tiles.ElementAt(14).Tail = p1;
        }

        [When(@"the stock is empty")]
        public void WhenTheStockIsEmpty()
        {
            _game.Stock.Tiles.Clear();
        }

        [When(@"the player doesnt has a tile to move")]
        public void WhenThePlayerDoesntHasATileToMove()
        {
            var existMove = _game.VerifyIfGameHasMoreMoves();
            if (!existMove)
                _winner = _game.GetWinner();
        }

        [Then(@"the player (.*) must win")]
        public void ThenThePlayerMustWin(int p0)
        {
            Assert.AreEqual(p0, _winner);
        }

        [Given(@"the tiles list on the  board")]
        public void GivenTheTilesListOnTheBoard()
        {
            _game = new Game();
            _game.AddNewPlayer(_player1);
            _game.AddNewPlayer(_player2);
            var listTites = _game.Board.Tiles.ToList();

            Assert.AreEqual(true, listTites.Any());
        }

        [When(@"Player One has the following tiles")]
        public void WhenPlayerOneHasTheFollowingTiles(Table table)
        {
            _game.GetPlayerAtPosition(0).Hand = TestUtility.ConvertTilesTableToListTiles(table);
        }

        [When(@"Player two has the following tiles")]
        public void WhenPlayerTwoHasTheFollowingTiles(Table table)
        {
            _game.GetPlayerAtPosition(1).Hand = TestUtility.ConvertTilesTableToListTiles(table);
        }

        [When(@"the turn is the player (.*)")]
        public void WhenTheTurnIsThePlayer(int p0)
        {
            Assert.AreEqual(p0, _game.PlayerTurn = 1);
        }

        [When(@"Player one puts his latest tile on the board")]
        public void WhenPlayerOnePutsHisLatestTileOnTheBoard()
        {
            _game.Move(1, 5);
            _game.VerifyPlayerHand();
        }

        [Then(@"player (.*) wins the game")]
        public void ThenPlayerWinsTheGame(int p0)
        {
            _winner = _game.GetWinner();
            Assert.AreEqual(p0, _winner);
        }

    }

}