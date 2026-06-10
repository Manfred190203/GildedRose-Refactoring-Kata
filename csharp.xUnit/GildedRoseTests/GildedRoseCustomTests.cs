using GildedRoseKata;
using Xunit;

namespace GildedRoseTests;

public class GildedRoseCustomTests
{
    // Quality should degrade twice as fast once the sell by date has passed
    [Fact]
    public void Test1()
    {
        Item[] items = { new Item { Name = "Avocado", SellIn = 0, Quality = 100 }, new Item { Name = "Avocado", SellIn = 1, Quality = 100 } };
        GildedRose app = new GildedRose(items);
        app.UpdateQuality();

        Assert.Equal(98, items[0].Quality);
        Assert.Equal(98, items[0].Quality);
    }

    // Quality should never be negative
    [Fact]
    public void Test2()
    {
        Item[] items = { new Item { Name = "Avocado", SellIn = 0, Quality = 0 } };
        GildedRose app = new GildedRose(items);
        app.UpdateQuality();

        Assert.Equal(0, items[0].Quality);
    }

    // Aged Brie actually increases in Quality the older it gets
    [Fact]
    public void Test3()
    {
        Item[] items = { new Item { Name = "Aged Brie", SellIn = 10, Quality = 10 } };
        GildedRose app = new GildedRose(items);
        app.UpdateQuality();

        Assert.Equal(11, items[0].Quality);
    }

    // The Quality of an item is never more than 50
    [Fact]
    public void Test4()
    {
        Item[] items = { new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 } };
        GildedRose app = new GildedRose(items);
        app.UpdateQuality();

        Assert.Equal(50, items[0].Quality);
    }
}