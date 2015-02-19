using System;
using System.Runtime.InteropServices;
using Domino.Logic;
using TechTalk.SpecFlow;

namespace ExamTest
{
    [Binding]
    public class GameSteps
    {
        private Game _game;


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
    ScenarioContext.Current.Pending();
}

        [Then(@"the two players must have (.*) tiles each")]
public void ThenTheTwoPlayersMustHaveTilesEach(int p0)
{
    ScenarioContext.Current.Pending();
}
    }
}
