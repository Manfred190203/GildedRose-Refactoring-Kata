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
}