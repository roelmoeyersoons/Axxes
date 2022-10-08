using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedTros.App.Items
{
    internal class KeyChain : ItemBase
    {
        public override void UpdateQuality()
        {
            IncrementQuality();
        }
    }
}
