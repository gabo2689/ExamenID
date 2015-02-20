using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino.Logic;

namespace Domino.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var player1 = new Player("Dennis");
            var player2 = new Player("Edward");
            var game = new Game();
            game.AddNewPlayer(player1);
            game.AddNewPlayer(player2);

            game.InitializePlayersHand(7);
        }
    }
}
