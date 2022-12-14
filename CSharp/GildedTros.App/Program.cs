using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GildedTros.App.Helpers;
using GildedTros.App.Items;

namespace GildedTros.App
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            using (var host = Host
                .CreateDefaultBuilder(args)
                .AddApp()
                .ConfigureLogging((context, builder) =>
                {
                    builder.ClearProviders();
                    builder.AddCustomFormatter();
                })
                .Build())
            {
                var logger = host.Services.GetRequiredService<ILogger<Program>>();

                logger.LogInformation("OMGHAI!");

                IList<ItemBase> Items = new List<ItemBase>{
                new ItemBase {Name = "Ring of Cleansening Code", SellIn = 10, Quality = 20},
                new Wine {Name = "Good Wine", SellIn = 2, Quality = 0},
                new ItemBase {Name = "Elixir of the SOLID", SellIn = 5, Quality = 7},
                new KeyChain {Name = "B-DAWG Keychain", SellIn = 0, Quality = 80},
                new KeyChain {Name = "B-DAWG Keychain", SellIn = -1, Quality = 80},
                new Pass {Name = "Backstage passes for Re:factor", SellIn = 15, Quality = 20},
                new Pass {Name = "Backstage passes for Re:factor", SellIn = 10, Quality = 49},
                new Pass {Name = "Backstage passes for HAXX", SellIn = 5, Quality = 49},
                // these smelly items do not work properly yet
                new ItemBase {Name = "Duplicate Code", SellIn = 3, Quality = 6},
                new ItemBase {Name = "Long Methods", SellIn = 3, Quality = 6},
                new ItemBase {Name = "Ugly Variable Names", SellIn = 3, Quality = 6}
                };

                var app = new GildedTros(Items, logger);

                app.RunApp(31);

                
            }

        }
    }
}
