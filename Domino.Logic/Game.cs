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
        
        public Player GetPlayerAtPosition(int position)
        {
            if(position<GetPlayerCount())
                return (Player) Players.ElementAt(position);
            return null;
        }

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

            PlayerTurn = GetPlayerInitial();


        }

        public int GetPlayerInitial()
        {
            var playerInicialStartPosition = 0;
            var hightTileScorePlayer = new Tile(-1, -1);
            var isDoublePieces = false;


            for (var i = 0; i < Players.Count; i++)
            {
                var tile = Players.ElementAt(i).GetHighestDouble();
                if (tile.IsDouble)
                {

                    if (tile.Head > hightTileScorePlayer.Head && tile.Tail > hightTileScorePlayer.Tail)
                    {
                        playerInicialStartPosition = i;
                        hightTileScorePlayer = tile;
                    }

                    isDoublePieces = true;
                }
                else
                {
                    if (!isDoublePieces)
                    {
                        var sum1 = tile.Head + tile.Tail;
                        var sum2 = hightTileScorePlayer.Head + hightTileScorePlayer.Tail;

                        if (sum1 > sum2)
                        {
                            playerInicialStartPosition = i;
                            hightTileScorePlayer = tile;
                        }
                    }

                }
            }
            return playerInicialStartPosition;
        }
    }
}
