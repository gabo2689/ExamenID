using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino.Logic;
using Autofac;
using Domino.Logic.Interfaces;

namespace Domino.Console
{
    class Program
    {
        private static IContainer _container;
        static void Main(string[] args)
        {

            _container = IocConfig.RegisterDependences();

            var _game = _container.Resolve<IGame>();

            
            
            var player1 = new Player("Dennis");
            var player2 = new Player("Edward");
            var game = new Game();
            game.AddNewPlayer(player1);
            game.AddNewPlayer(player2);

            game.InitializePlayersHand(7);
        }
    }
}
