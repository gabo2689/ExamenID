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
            var playerStartPosition = 0;
            var HightTileScorePlayer = new Tile(-1, -1);
            bool isDoublePieces = false;
            
            for (var i = 0; i < Players.Count; i++)
            {
                var tile = Players.ElementAt(i).GetHighestDouble();
                if (tile.IsDouble)
                {
                    if (tile.Head > HightTileScorePlayer.Head && tile.Tail > HightTileScorePlayer.Tail)
                    {
                        playerStartPosition = i;
                        HightTileScorePlayer = tile;
                    }

                    isDoublePieces = true;
                }
                 else
                {
                   if(!isDoublePieces)
                   {
                       var sum1 = tile.Head + tile.Tail;
                       var sum2 = HightTileScorePlayer.Head + HightTileScorePlayer.Tail;

                       if (sum1 > sum2)
                       {
                           playerStartPosition = i;
                           HightTileScorePlayer = tile;
                       }


                   }
                }

                

            }
        }
    }
}
