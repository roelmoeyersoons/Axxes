using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedTros.App.Helpers
{
    public static class AppExtensions
    {
        public static IHostBuilder AddApp(this IHostBuilder builder)
        {
            builder.ConfigureServices(serviceCollection =>
            {
                //serviceCollection.AddTransient<IGildedTros, MyGildedTros>();
                //serviceCollection.AddSingleton<IItemDB, MyItemDB>();
            });
            return builder;
        }

    }
}
