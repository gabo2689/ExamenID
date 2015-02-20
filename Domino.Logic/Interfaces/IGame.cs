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

        void Move(int positionHand, int positionBoard);
        bool VerifyMove(int positionHand, int positionBoard);
    }
}