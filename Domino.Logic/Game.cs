using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino.Logic.Interfaces;

namespace Domino.Logic
{
    public class Game : IGame
    {
        private const int AmountOfPlayerTiles = 7;
        public List<IPlayer> Players { get; set; }
        public int PlayerTurn { get; set; }
        public Board Board { get; set; }
        public Stock Stock { get; set; }

        public Game()
        {
            var random = new Random();
            Board=new Board();
            Stock=new Stock(new RandomNumber());
            Players=new List<IPlayer>();
        }
        public void AddNewPlayer(IPlayer newPlayer)
        {
            Players.Add(newPlayer);
        }

        public void InitializePlayersHand(int amountOfTilesForEachPlayer)
        {
            foreach (var player in Players)
            {
                for (var i = 0; i < amountOfTilesForEachPlayer; i++)
                {
                    player.AddTileToHand(Stock.PopFromStock());
                }
            }
            
        }

        public int GetPlayerCount()
        {
            return Players.Count;
        }

        public void ResetGame(IPlayer player)
        {
            InitializePlayersHand(AmountOfPlayerTiles);
            InitializeTurns();
        }

        private void InitializeTurns()
        {
            var turn = 0;
            var highestTile = new Tile(-1,-1);
            
            for (var i = 0; i < Players.Count; i++)
            {
                var tile = Players.ElementAt(i).GetHighestDouble();
                if (tile.IsDouble)
                {
                    if(tile.Head>highestTile.Head)
                        highestTile = tile;
                }
                else
                {
                    
                }
            }
        }
    }
}
