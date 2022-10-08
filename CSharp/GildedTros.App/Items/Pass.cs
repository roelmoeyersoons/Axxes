using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedTros.App.Items
{
    public class Pass : ItemBase
    {
        public override void UpdateQuality()
        {
            if (IncrementQuality())
            {
                if (SellIn < 11)
                {
                    IncrementQuality();
                }

                if (SellIn < 6)
                {
                    IncrementQuality();
                }
            }

            SellIn = SellIn - 1;

            if (SellIn < 0)
            {
                Quality = 0;
            }
        }
    }
}
