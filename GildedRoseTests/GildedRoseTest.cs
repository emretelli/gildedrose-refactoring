using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void foo()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            //Act
            app.UpdateQuality();
            //Assert
            Assert.Equal("foo", Items[0].Name);
        }

        [Fact]
        public void AnyItemDecreaseSellInDayByOne()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Any Item", SellIn = 5, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            //Act
            app.UpdateQuality();
            //Assert
            Assert.Equal(4, Items[0].SellIn);
        }

        [Fact]
        public void OrdinaryItem_WhenSellInDayGreaterThanZero_DecreaseQualityByOne()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Ordinary Item", SellIn = 5, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            //Act
            app.UpdateQuality();
            //Assert
            Assert.Equal(4, Items[0].Quality);
        }

        [Fact]
        public void OrdinaryItem_WhenSellInDayLessThanZero_DecreaseQualityTwice()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Any Item", SellIn = -1, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            //Act
            app.UpdateQuality();
            //Assert
            Assert.Equal(8, Items[0].Quality);
        }

        [Fact]
        public void AgedItem_WhenSellInDayGreaterThanZero_IncreaseQualityByOne()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = Utils.AGED, SellIn = 1, Quality = 1 } };
            GildedRose app = new GildedRose(Items);
            //Act
            app.UpdateQuality();
            //Assert
            Assert.Equal(2, Items[0].Quality);
        }

        [Fact]
        public void AgedItem_WhenSellInDayLessThanZero_IncreaseQualityByTwo()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = Utils.AGED, SellIn = -1, Quality = 1 } };
            GildedRose app = new GildedRose(Items);
            //Act
            app.UpdateQuality();
            //Assert
            Assert.Equal(3, Items[0].Quality);
        }

        [Fact]
        public void AnyItemQualityCannotBeNegative()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Any Item", SellIn = -1, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            //Act
            app.UpdateQuality();
            //Assert
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void AnyItemExceptSulfurasCannotHaveQualityMoreThanFifty()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Any Item", SellIn = 4, Quality = 60 } };
            GildedRose app = new GildedRose(Items);
            //Act
            app.UpdateQuality();
            //Assert
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void SulfurasItemCannotBeAltered()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = Utils.SULFURAS, SellIn = 10, Quality = 60 } };
            GildedRose app = new GildedRose(Items);
            //Act
            app.UpdateQuality();
            //Assert
            Assert.Equal(60, Items[0].Quality);
            Assert.Equal(10, Items[0].SellIn);
        }

        [Fact]
        public void SulfurasItemQualityCannotBeGreaterThanEighty()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = Utils.SULFURAS, SellIn = 10, Quality = 80 } };
            GildedRose app = new GildedRose(Items);
            //Act
            app.UpdateQuality();
            //Assert
            Assert.Equal(80, Items[0].Quality);
        }

        [Fact]
        public void BackStageItem_WhenSellInDayGreaterThanTen_IncreaseQualityByOne()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = Utils.BACKSTAGE, SellIn = 15, Quality = 20 } };
            GildedRose app = new GildedRose(Items);
            //Act
            app.UpdateQuality();
            //Assert
            Assert.Equal(21, Items[0].Quality);
        }

        [Fact]
        public void BackStageItem_WhenSellInDayGreaterThanFiveLessThanTen_IncreaseQualityByTwo()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = Utils.BACKSTAGE, SellIn = 10, Quality = 20 } };
            GildedRose app = new GildedRose(Items);
            //Act
            app.UpdateQuality();
            //Assert
            Assert.Equal(22, Items[0].Quality);
        }

        [Fact]
        public void BackStageItem_WhenSellInDayGreaterThanZeroLessThanFive_IncreaseQualityByThree()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = Utils.BACKSTAGE, SellIn = 5, Quality = 20 } };
            GildedRose app = new GildedRose(Items);
            //Act
            app.UpdateQuality();
            //Assert
            Assert.Equal(23, Items[0].Quality);
        }

        [Fact]
        public void BackStageItem_WhenSellInDayLessOrEqualZero_DropQualityToZero()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = Utils.BACKSTAGE, SellIn = 0, Quality = 20 } };
            GildedRose app = new GildedRose(Items);
            //Act
            app.UpdateQuality();
            //Assert
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void ConjuredItem_WhenSellInDayGreaterThanZero_DecreaseQualityByTwiceAsOrdinaryItems()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = Utils.CONJURED, SellIn = 5, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            //Act
            app.UpdateQuality();
            //Assert
            Assert.Equal(8, Items[0].Quality);
        }

        [Fact]
        public void ConjuredItem_WhenSellInDayLessThanZero_DecreaseQualityByTwiceAsOrdinaryItems()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = Utils.CONJURED, SellIn = 0, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            //Act
            app.UpdateQuality();
            //Assert
            Assert.Equal(6, Items[0].Quality);
        }
    }
}
