using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using Domino.Logic;
using Domino.Logic.Interfaces;

namespace Domino.Console
{
    public class IocConfig
    {
        public static IContainer RegisterDependences()
        {
            var builder = new ContainerBuilder();

            //build.RegisterType<Board>().As<Ibo>()
            builder.RegisterType<Game>().As<IGame>();
            //builder.RegisterType<Player>().As<IPlayer>();
            //builder.RegisterType<Random>().As<IRandom>();
            //builder.RegisterType<Stock>().As<IStock>();

            IContainer con = builder.Build();
            return con;

        }

        
    }


}
