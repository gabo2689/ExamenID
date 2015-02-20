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

        public void Move(int positionHand, int positionBoard)
        {
            if (VerifyMove(positionHand, positionBoard))
            {
                Board.AddTile(positionBoard, Players.ElementAt(PlayerTurn - 1).Hand.ElementAt(positionHand));
                Players.ElementAt(PlayerTurn - 1).Hand.RemoveAt(positionHand);
                NextPlayerTurn();
            }
        }

        public bool VerifyMove(int positionHand, int positionBoard)
        {
            var move = true;
            if (Board.Tiles[positionBoard].Head == -1)
            {
                if (positionBoard == 27)
                {
                    if (Board.Tiles[positionBoard - 1].Head ==
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Tail)
                        Board.Tiles[positionBoard - 1].HeadTaked = true;
                    else if (Board.Tiles[positionBoard - 1].Head ==
                             Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Head)
                    {
                        Board.Tiles[positionBoard - 1].HeadTaked = true;
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Swap();
                    }
                    else
                        move = false;
                }
                else if (positionBoard == 0)
                {
                    if (Board.Tiles[positionBoard + 1].Tail ==
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Head)
                        Board.Tiles[positionBoard + 1].TailTaked = true;
                    else if (Board.Tiles[positionBoard + 1].Tail ==
                             Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Tail)
                    {
                        Board.Tiles[positionBoard + 1].TailTaked = true;
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Swap();
                    }
                    else
                        move = false;
                }
                else if (positionBoard > 0 && positionBoard < 27)
                {
                    if (Board.Tiles[positionBoard - 1].Head == Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Tail)
                        Board.Tiles[positionBoard - 1].HeadTaked = true;

                    else if (Board.Tiles[positionBoard - 1].Tail == Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Head)
                        Board.Tiles[positionBoard - 1].TailTaked = true;

                    else if (Board.Tiles[positionBoard + 1].Tail == Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Head)
                        Board.Tiles[positionBoard + 1].TailTaked = true;

                    else if (Board.Tiles[positionBoard + 1].Head == Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Tail)
                        Board.Tiles[positionBoard + 1].HeadTaked = true;

                    else if (Board.Tiles[positionBoard - 1].Head == Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Head)
                    {
                        Board.Tiles[positionBoard - 1].HeadTaked = true;
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Swap();
                    }
                    else if (Board.Tiles[positionBoard + 1].Tail == Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Tail)
                    {
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Swap();
                        Board.Tiles[positionBoard + 1].TailTaked = true;
                    }
                    else if (Board.Tiles[positionBoard + 1].Head == Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Head)
                    {
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Swap();
                        Board.Tiles[positionBoard + 1].HeadTaked = true;
                    }
                    else if (Board.Tiles[positionBoard - 1].Tail == Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Tail)
                    {
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Swap();
                        Board.Tiles[positionBoard - 1].TailTaked = true;
                    }
                    else
                        move = false;

                }
            }
            return move;
        }


        private void NextPlayerTurn()
        {
            PlayerTurn++;
            if (PlayerTurn > Players.Count)
                PlayerTurn = 1;
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
