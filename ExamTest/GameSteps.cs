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
        private Tile _tile;

        [Given(@"the players have an empty hand")]
        public void GivenThePlayersHaveAnEmptyHand()
        {
                    var player1 =  new Player("Dennis");
                    var player2 = new Player("Edward");
                    _game = new Game();
                    _game.AddNewPlayer(player1);
                    _game.AddNewPlayer(player2);


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
            Assert.AreEqual(p0,player1Tiles,player2Tiles);
        }

        [Given(@"a tile with (.*) in head  and (.*) in tail")]
        public void GivenATileWithInHeadAndInTail(int head, int tail)
        {
            _tile=new Tile(head,tail);
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
            Assert.AreEqual(areEquals,true);
        }

        
    }
}
