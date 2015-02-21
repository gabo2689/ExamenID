using Domino.Logic;
using Domino.Logic.Interfaces;
using System.Collections.Generic;

namespace Domino.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var player1 = new Player("Dennis");
            var player2 = new Player("Edward");
            var game = new Game();
            game.AddNewPlayer(player1);
            game.AddNewPlayer(player2);

            game.InitializePlayersHand(7);

            IDatabase binary = new BinaryFile();
            binary.Save(new List<PlayerGameStatistics>
            {
                new PlayerGameStatistics("Erick", false),
                new PlayerGameStatistics("Juan", false),
                new PlayerGameStatistics("Pedro", true),
                new PlayerGameStatistics("Elias", false)
            });
            System.Console.Write("-------------------Tabla-------------------\n");
            PlayerStatistics Erick = binary.GetPlayerStatistics("Erick");
            PlayerStatistics Pedro = binary.GetPlayerStatistics("Pedro");
            PlayerStatistics Elias = binary.GetPlayerStatistics("Elias");
            System.Console.Write(Erick.PlayerName + " ah ganado " + Erick.Wins + " veces\n ");
            System.Console.Write(Erick.PlayerName + " ah perdido " + Erick.Losses + " veces\n ");
            System.Console.Write(Pedro.PlayerName + " ah ganado " + Pedro.Wins + " veces\n ");
            System.Console.Write(Pedro.PlayerName + " ah perdido " + Pedro.Losses + " veces\n ");
            System.Console.Write(Elias.PlayerName + " ah ganado " + Elias.Wins + " veces\n ");
            System.Console.Write(Elias.PlayerName + " ah perdido " + Elias.Losses + " veces\n ");
            System.Console.Read();
        }
    }
}