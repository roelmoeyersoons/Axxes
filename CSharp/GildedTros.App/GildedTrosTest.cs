using System.Collections.Generic;
using Xunit;

namespace GildedTros.App
{
    public class GildedTrosTest
    {
        [Fact]
        public void foo()
        {
            IList<ItemBase> Items = new List<ItemBase> { new ItemBase { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedTros app = new GildedTros(Items, null);
            app.UpdateQuality();
            Assert.Equal("fixme", Items[0].Name);
        }
    }
}