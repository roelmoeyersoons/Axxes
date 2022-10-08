using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedTros.App
{
    public class GildedTros
    {
        IList<ItemBase> Items;
        private readonly ILogger _logger;

        public GildedTros(IList<ItemBase> Items, ILogger logger)
        {
            this.Items = Items;
            _logger = logger ?? throw new ArgumentNullException($"GildedTros: {nameof(logger)} null");
        }

        public void UpdateQuality()
        {
            foreach (var item in Items ?? Enumerable.Empty<ItemBase>())
            {
                item.UpdateQuality();
            }
        }

        public void RunApp()
        {
            for (var i = 0; i < 31; i++)
            {
                _logger.LogInformation("-------- day " + i + " --------");
                _logger.LogInformation("name, sellIn, quality");
                foreach (var item in Items ?? Enumerable.Empty<ItemBase>())
                {
                    _logger.LogInformation(item.ToString());
                }
                _logger.LogInformation("");
                UpdateQuality();
            }
        }

        /*
        notes:
        
        Backstage passes for Re:factor
        Backstage passes for HAXX

        gaat eerst quality bepalen zommar + op basis van sellin, daarna sellin verlagen, daarna if sellin <0 quality op 0 zetten

        B-DAWG Keychain

        gaat quality verhogen zomaar, dan NOOIT sellin verlagen, mocht sellin vanaf begin <0 zijn dan ook niks, doet gewoon niks

        Good wine

        gaat quality verhogen zomaar, dan sellin verlagen, if <0 dan quality gewoon weer verhogen naar max 50

        Rest:

        gaat altijd quality verlagen, dan sellin verlagen, if <0 dan quality weer verlagen, ondergrens is 0
         */
    }
}
