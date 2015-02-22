using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using Domino.Logic;
using Domino.Logic.Interfaces;
using IContainer = Autofac.IContainer;

namespace Domino.Console
{
    public class IocConfig
    {
        public static IContainer RegisterDependences()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Game>().As<IGame>();
            builder.RegisterType<Player>().As<IPlayer>();
            builder.RegisterType<Random>().As<IRandom>();
            builder.RegisterType<Stock>().As<IStock>();
            builder.RegisterType<Board>().As<IBoard>();
            builder.RegisterType<BinaryFile>().As<IDatabase>();
            builder.RegisterType<PlayerGameStatistics>().As<IPlayerGameStatistics>();
            builder.RegisterType<Tile>().As<ITile>();

            IContainer con = builder.Build();
            return con;

        }

        
    }


}
