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
        private const int AmountOfGameTiles = 28;
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
            ResetGame();
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

        public void InitializeBoard()
        {
            Board.Initialize();
            Board.AddTile(AmountOfGameTiles/2, Stock.PopFromStock());
        }

        public int GetPlayerCount()
        {
            return Players.Count;
        }

        public void ResetGame()
        {
            InitializePlayersHand(AmountOfPlayerTiles);
            InitializeTurns();
            InitializeBoard();
        }

        private void InitializeTurns()
        {

            PlayerTurn = GetPlayerInitial();

        }

        public void Move(int positionHand, int positionBoard)
        {
            if (VerifyMove(positionHand, positionBoard))
            {
                Board.AddTile(positionBoard, Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand));
                Players.ElementAt(PlayerTurn).Hand.RemoveAt(positionHand);
                NextPlayerTurn();
            }
        }

        public int GetWinner()
        {
            if (Players.ElementAt(0).Hand.Count < Players.ElementAt(1).Hand.Count)
                return 1;
            if (Players.ElementAt(1).Hand.Count < Players.ElementAt(0).Hand.Count)
                return 2;
            return 0;
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

        public bool VerifyPlayerHand()
        {
            for (var i = 0; i < Board.Tiles.Length; i++)
            {
                if (Board.Tiles.ElementAt(i).Head != -1)
                {
                    for (var j = 0; j < Players.ElementAt(PlayerTurn).Hand.Count; j++)
                    {
                        if (!Board.Tiles.ElementAt(i).HeadTaked &&
                            (Board.Tiles.ElementAt(i).Head ==
                             Players.ElementAt(PlayerTurn).Hand.ElementAt(j).Head ||
                             Board.Tiles.ElementAt(i).Head ==
                             Players.ElementAt(PlayerTurn).Hand.ElementAt(j).Tail))
                        {
                            return true;
                        }
                        if (!Board.Tiles.ElementAt(i).TailTaked &&
                            (Board.Tiles.ElementAt(i).Tail ==
                             Players.ElementAt(PlayerTurn).Hand.ElementAt(j).Head ||
                             Board.Tiles.ElementAt(i).Tail ==
                             Players.ElementAt(PlayerTurn).Hand.ElementAt(j).Tail))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool VerifyIfGameHasMoreMoves()
        {
            var turn = PlayerTurn;
            var playershasMoveCount = 0;
            for (int i = 0; i < Players.Count; i++)
            {
                PlayerTurn = i;
                if (VerifyPlayerHand())
                    playershasMoveCount++;
            }
            PlayerTurn = turn;
            if (playershasMoveCount == 0)
                return false;

            return true;
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
