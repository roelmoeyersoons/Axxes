using Microsoft.VisualStudio.TestTools.UnitTesting;
using GildedTros.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;

namespace GildedTros.App.Tests
{
    [TestClass()]
    public class ItemBaseTests
    {
        

        [TestMethod()]
        public void IncrementQuality_Increments_Quality_When_Under_Upperbound()
        {
            var faker = new Faker();

            var generatedQuality = faker.Random.Int(1, ItemBase.QUALITY_UPPER_BOUND);
            var item = new ItemBase
            {
                Quality = generatedQuality
            };

            var didIncrement = item.IncrementQuality();

            Assert.AreEqual(generatedQuality + 1, item.Quality);
            Assert.IsTrue(didIncrement);
        }

        //could be split up into 2 unit tests for better readability when test would fail
        [TestMethod()]
        public void IncrementQuality_Does_Not_Increment_Quality_When_Equal_Or_Over_Upperbound()
        {
            var faker = new Faker();
            var qualitiesToCheck = new int[] { ItemBase.QUALITY_UPPER_BOUND, faker.Random.Int(ItemBase.QUALITY_UPPER_BOUND) };

            foreach(var generatedQuality in qualitiesToCheck)
            {
                var item = new ItemBase
                {
                    Quality = generatedQuality
                };

                var didIncrement = item.IncrementQuality();

                Assert.AreEqual(generatedQuality, item.Quality);
                Assert.IsFalse(didIncrement);
            }
            
        }

        [TestMethod()]
        public void UpdateQuality_Lowers_Quality_Once_Before_Sellin()
        {
            var faker = new Faker();

            var generatedSellIn = faker.Random.Int(1, 100);
            var generatedQuality = faker.Random.Int(1, ItemBase.QUALITY_UPPER_BOUND);

            var item = new ItemBase
            {
                SellIn = generatedSellIn,
                Quality = generatedQuality
            };

            item.UpdateQuality();

            Assert.AreEqual(generatedQuality - 1, item.Quality);
        }

        [TestMethod()]
        public void UpdateQuality_Lowers_Quality_Twice_After_Sellin()
        {
            var faker = new Faker();

            var generatedSellIn = faker.Random.Int(-100, 0);
            var generatedQuality = faker.Random.Int(1, ItemBase.QUALITY_UPPER_BOUND);

            var item = new ItemBase
            {
                SellIn = generatedSellIn,
                Quality = generatedQuality
            };

            item.UpdateQuality();

            Assert.AreEqual(generatedQuality - 2, item.Quality);
        }

        [TestMethod()]
        public void UpdateQuality_Always_Lowers_Sellin()
        {
            var faker = new Faker();

            var generatedSellIn = faker.Random.Int(1, 100);

            var item = new ItemBase
            {
                SellIn = generatedSellIn,
            };

            item.UpdateQuality();

            Assert.AreEqual(generatedSellIn - 1, item.SellIn);
        }
    }
}