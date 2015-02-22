using System;
using Domino.Logic;
using Domino.Logic.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino.Logic;
using Autofac;
using Domino.Logic.Interfaces;

namespace Domino.Console
{
    internal class Program
    {
        private static IContainer _container;
        public static IGame _game;

        static void Main(string[] args)
        {
            var HandPosition = 0;
            var BoardPosition = 0;
            _container = IocConfig.RegisterDependences();

            _game = _container.Resolve<IGame>();
            var continueGame = false;

            System.Console.WriteLine("Nombre del Player1? :  ");

            _game.AddNewPlayer(new Player(System.Console.ReadLine()));
            System.Console.WriteLine("Nombre del Player2? : ");
            _game.AddNewPlayer(new Player(System.Console.ReadLine()));
            _game.ResetGame();

            while (!continueGame)
            {
                System.Console.Clear();
                DrawBoard();

                if (_game.VerifyPlayerHand())
                {
                    System.Console.WriteLine("Turno de:" + _game.Players.ElementAt(_game.PlayerTurn).Name);
                    System.Console.WriteLine();
                    DrawPlayersHand();
                    System.Console.WriteLine();
                    System.Console.WriteLine("Posicion de la pieza a colocar: ");
                    HandPosition = Convert.ToInt32(System.Console.ReadLine());
                    System.Console.WriteLine("Posicion del tablero a colocar la pieza: ");
                    BoardPosition = Convert.ToInt32(System.Console.ReadLine());
                    _game.Move(HandPosition, BoardPosition);
                }
                else
                {
                    if (_game.Stock.Tiles.Count != 0)
                        _game.Players.ElementAt(_game.PlayerTurn).AddTileToHand(_game.Stock.PopFromStock());
                    else
                        continueGame = false;
                }

                var winner = _game.GetWinner();
            }

            /*IDatabase binary = new BinaryFile();
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
            System.Console.Read();*/
        }
        public static void DrawBoard()
        {
            for (int i = 0; i < _game.Board.Tiles.Count(); i++)
            {
                if (_game.Board.Tiles.ElementAt(i).Head == -1)
                {
                    System.Console.WriteLine("---");
                    System.Console.WriteLine("   |" + i);
                    System.Console.WriteLine("___");
                }
                else
                {
                    System.Console.WriteLine("---");
                    System.Console.WriteLine(_game.Board.Tiles.ElementAt(i).Head);
                    System.Console.WriteLine(_game.Board.Tiles.ElementAt(i).Tail + "  |" + i);
                    System.Console.WriteLine("---");
                }
            }
            System.Console.WriteLine("");
        }

        public static void DrawPlayersHand()
        {

            for (int i = 0; i < _game.Players.ElementAt(_game.PlayerTurn).Hand.Count; i++)
            {
                System.Console.Write("| " + _game.Players.ElementAt(_game.PlayerTurn).Hand.ElementAt(i).Head + " |");
                System.Console.Write("  ");
            }
            System.Console.WriteLine();
            for (int i = 0; i < _game.Players.ElementAt(_game.PlayerTurn).Hand.Count; i++)
            {
                System.Console.Write("| " + _game.Players.ElementAt(_game.PlayerTurn).Hand.ElementAt(i).Tail + " |");
                System.Console.Write("  ");
            }
            System.Console.WriteLine();
            System.Console.WriteLine();
            for (int i = 0; i < _game.Players.ElementAt(_game.PlayerTurn).Hand.Count; i++)
            {
                System.Console.Write("  " + i + "  ");
                System.Console.Write("  ");
            }

        }
    }
}
