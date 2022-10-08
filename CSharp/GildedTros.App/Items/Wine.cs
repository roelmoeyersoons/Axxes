using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedTros.App.Items
{
    internal class Wine : ItemBase
    {
        public override void UpdateQuality()
        {
            IncrementQuality();

            SellIn = SellIn - 1;

            if (SellIn < 0)
            {
                IncrementQuality();
            }
        }
    }
}
