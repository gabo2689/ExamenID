using Domino.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domino.Logic
{
    public class Game : IGame
    {
        private const int AmountOfPlayerTiles = 7;
        private const int AmountOfGameTiles = 28;

        public Game()
        {
            var random = new Random();
            Board = new Board();
            Stock = new Stock(new RandomNumber());
            Stock.Shuffle(56);
            Players = new List<IPlayer>();

            InitializeBoard();
        }

        public List<IPlayer> Players { get; set; }

        public IDatabase Database { get; set; }

        public int PlayerTurn { get; set; }

        public Board Board { get; set; }

        public Stock Stock { get; set; }

        public Player GetPlayerAtPosition(int position)
        {
            if (position < GetPlayerCount())
                return (Player)Players.ElementAt(position);
            return null;
        }

        public void AddNewPlayer(IPlayer newPlayer)
        {
            Players.Add(newPlayer);
            InitializeTurns();
        }

        public void InitializePlayersHand(int amountOfTilesForEachPlayer)
        {
            foreach (IPlayer player in Players)
            {
                for (int i = 0; i < amountOfTilesForEachPlayer; i++)
                {
                    player.AddTileToHand(Stock.PopFromStock());
                }
            }
        }

        public void InitializeBoard()
        {
            Board.Initialize();
            Board.AddTile(AmountOfGameTiles / 2, Stock.PopFromStock());
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

        public void InitializeTurns()
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
            int highestNumber = -1;
            int position = -1;
            int EqualsCount = 0;

            for (int i = 0; i < Players.Count; i++)
            {
                if (Players.ElementAt(i).Hand.Count > highestNumber)
                {
                    highestNumber = Players.ElementAt(i).Hand.Count;
                    position = i;
                }
                else if (Players.ElementAt(i).Hand.Count == highestNumber)
                {
                    EqualsCount++;
                }
            }
            if (EqualsCount == Players.Count - 1)
                return 0;
            return position;
        }

        public bool VerifyMove(int positionHand, int positionBoard)
        {
            bool move = true;
            if (Board.Tiles[positionBoard].Head == -1)
            {
                if (positionBoard == 27)
                {
                    if (Board.Tiles[positionBoard - 1].Head ==
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Tail &&
                        !Board.Tiles[positionBoard - 1].HeadTaked)
                    {
                        Board.Tiles[positionBoard - 1].HeadTaked = true;
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).TailTaked = true;
                    }
                    else if (Board.Tiles[positionBoard - 1].Head ==
                             Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Head &&
                             !Board.Tiles[positionBoard - 1].HeadTaked)
                    {
                        Board.Tiles[positionBoard - 1].HeadTaked = true;
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Swap();
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).TailTaked = true;
                    }
                    else
                        move = false;
                }
                else if (positionBoard == 0)
                {
                    if (Board.Tiles[positionBoard + 1].Tail ==
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Head &&
                        !Board.Tiles[positionBoard + 1].TailTaked)
                    {
                        Board.Tiles[positionBoard + 1].TailTaked = true;
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).HeadTaked = true;
                    }
                    else if (Board.Tiles[positionBoard + 1].Tail ==
                             Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Tail &&
                             !Board.Tiles[positionBoard + 1].TailTaked)
                    {
                        Board.Tiles[positionBoard + 1].TailTaked = true;
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Swap();
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).HeadTaked = true;
                    }
                    else
                        move = false;
                }
                else if (positionBoard > 0 && positionBoard < 27)
                {
                    if (Board.Tiles[positionBoard - 1].Head ==
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Tail &&
                        !Board.Tiles[positionBoard - 1].HeadTaked)
                    {
                        Board.Tiles[positionBoard - 1].HeadTaked = true;
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).TailTaked = true;
                    }
                    else if (Board.Tiles[positionBoard - 1].Tail ==
                             Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Head &&
                             !Board.Tiles[positionBoard - 1].TailTaked)
                    {
                        Board.Tiles[positionBoard - 1].TailTaked = true;
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).HeadTaked = true;
                    }
                    else if (Board.Tiles[positionBoard + 1].Tail ==
                             Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Head &&
                             !Board.Tiles[positionBoard + 1].TailTaked)
                    {
                        Board.Tiles[positionBoard + 1].TailTaked = true;
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).HeadTaked = true;
                    }
                    else if (Board.Tiles[positionBoard + 1].Head ==
                             Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Tail &&
                             !Board.Tiles[positionBoard + 1].HeadTaked)
                    {
                        Board.Tiles[positionBoard + 1].HeadTaked = true;
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).TailTaked = true;
                    }
                    else if (Board.Tiles[positionBoard - 1].Head ==
                             Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Head &&
                             !Board.Tiles[positionBoard - 1].HeadTaked)
                    {
                        Board.Tiles[positionBoard - 1].HeadTaked = true;
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Swap();
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).TailTaked = true;
                    }
                    else if (Board.Tiles[positionBoard + 1].Tail ==
                             Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Tail &&
                             !Board.Tiles[positionBoard + 1].TailTaked)
                    {
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Swap();
                        Board.Tiles[positionBoard + 1].TailTaked = true;
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).HeadTaked = true;
                    }
                    else if (Board.Tiles[positionBoard + 1].Head ==
                             Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Head &&
                             !Board.Tiles[positionBoard + 1].HeadTaked)
                    {
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Swap();
                        Board.Tiles[positionBoard + 1].HeadTaked = true;
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).TailTaked = true;
                    }
                    else if (Board.Tiles[positionBoard - 1].Tail ==
                             Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Tail &&
                             !Board.Tiles[positionBoard - 1].TailTaked)
                    {
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Swap();
                        Board.Tiles[positionBoard - 1].TailTaked = true;
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).HeadTaked = true;
                    }
                    else
                        move = false;
                }
            }
            return move;
        }

        public bool VerifyPlayerHand()
        {
            for (int i = 0; i < Board.Tiles.Length; i++)
            {
                if (Board.Tiles.ElementAt(i).Head != -1)
                {
                    for (int j = 0; j < Players.ElementAt(PlayerTurn).Hand.Count; j++)
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
            int turn = PlayerTurn;
            int playershasMoveCount = 0;
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

        public void NextPlayerTurn()
        {
            PlayerTurn++;
            if (PlayerTurn > Players.Count - 1)
                PlayerTurn = 0;
        }

        public int GetPlayerInitial()
        {
            int playerInicialStartPosition = 0;
            var hightTileScorePlayer = new Tile(-1, -1);
            bool isDoublePieces = false;

            for (int i = 0; i < Players.Count; i++)
            {
                Tile tile = Players.ElementAt(i).GetHighestDouble();
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
                        int sum1 = tile.Head + tile.Tail;
                        int sum2 = hightTileScorePlayer.Head + hightTileScorePlayer.Tail;

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

        public void SaveStatistics(int winner)
        {
            Database = new BinaryFile();
            if (winner == -1) return;
            var gameStatistics = new List<IPlayerGameStatistics>();
            for (int i = 0; i < Players.Count; i++)
            {
                gameStatistics.Add(i == winner
                    ? new PlayerGameStatistics(Players[i].Name, true)
                    : new PlayerGameStatistics(Players[i].Name, false));
            }
            Database.Save(gameStatistics);
        }
    }
}