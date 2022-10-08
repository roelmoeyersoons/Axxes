using Microsoft.VisualStudio.TestTools.UnitTesting;
using GildedTros.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Microsoft.Extensions.Logging.Fakes;
using GildedTros.App.Fakes;

namespace GildedTros.App.Tests
{
    [TestClass()]
    public class GildedTrosTests
    {
        //public class MyCustomItemBase : ItemBase { } also possible

        [TestMethod()]
        public void GildedTros_Updates_Quality_Of_All_Items()
        {
            

            var faker = new Faker();
            var totalTimesCalled = 0;
            var days = 5;

            var itemGenerator = new ItemBase[]
            {
                new StubItemBase
                {
                    Name = faker.Random.Word(),
                    SellIn = faker.Random.Int(),
                    Quality = faker.Random.Int(),
                    UpdateQuality01 = () => totalTimesCalled++ } 
            };
            var itemCount = itemGenerator.Length;
            

            var gildedTros = new GildedTros(itemGenerator, new StubILogger());

            gildedTros.RunApp(days);

            Assert.AreEqual(itemCount*days, totalTimesCalled);
        }
    }
}