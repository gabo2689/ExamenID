using Domino.Logic;
using Domino.Logic.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace ExamTest
{
    [Binding]
    public class StackSteps
    {
        private int _amountTiles;

        private Stock _stock;

        [Given(@"the following tiles")]
        public void GivenTheFollowingTiles(Table table)
        {
            _amountTiles = table.RowCount;
        }

        [Given(@"the following Random Stack exist")]
        public void GivenTheFollowingRandomStackExist(Table table)
        {
            var random = MockRepository.GenerateMock<IRandom>();
            var randomSerie = new[] { 0, 1, 2, 3, 4, 5 };
            int randomSerieIndex = 0;

            RandomPositionDelegate randomFunction = () =>
            {
                int value = randomSerie[randomSerieIndex];
                randomSerieIndex++;
                return value;
            };

            random.Stub(x => x.GetRandomPosition()).Do((randomFunction));

            //_stock = new Stock(random, TestUtility.ConvertTilesTableToListTiles(table));
        }

        [When(@"Randoms tiles are generated")]
        public void WhenRandomsTilesAreGenerated()
        {
            _stock.Shuffle(3);
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            Assert.AreEqual(p0, _amountTiles);
        }

        [Then(@"the following tiles appear")]
        public void ThenTheFollowingTilesAppear(Table table)
        {
            List<Tile> expectedTiles = TestUtility.ConvertTilesTableToListTiles(table);
            CollectionAssert.AreEqual(expectedTiles, _stock.Tiles);
        }

        private delegate int RandomPositionDelegate();
    }
}