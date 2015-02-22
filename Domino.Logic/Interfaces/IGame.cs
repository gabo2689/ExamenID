using System.Collections.Generic;

namespace Domino.Logic.Interfaces
{
    public interface IGame
    {
        List<IPlayer> Players { get; set; }
        int PlayerTurn { get; set; }
        Board Board { get; set; }
        Stock Stock { get; set; }
        Player GetPlayerAtPosition(int position);
        void AddNewPlayer(IPlayer newPlayer);
        void InitializePlayersHand(int amountOfTilesForEachPlayer);
        void InitializeBoard();
        int GetPlayerCount();
        void ResetGame();
        void InitializeTurns();
        void Move(int positionHand, int positionBoard);
        int GetWinner();
        bool VerifyMove(int positionHand, int positionBoard);
        bool VerifyPlayerHand();
        bool VerifyIfGameHasMoreMoves();
        void NextPlayerTurn();
        int GetPlayerInitial();
    }
}