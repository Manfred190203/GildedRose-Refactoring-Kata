using System;
using System;
using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private const string AgedBrie = "Aged Brie";
    private const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
    private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
    private const string ConjuredPrefix = "Conjured";

    private const int MinQuality = 0;
    private const int MaxQuality = 50;

    IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        foreach (var item in Items)
        {
            UpdateItem(item);
        }
    }

    private static void UpdateItem(Item item)
    {
        switch (item.Name)
        {
            case Sulfuras:
                // Legendary item: never changes.
                break;
            case AgedBrie:
                UpdateAgedBrie(item);
                break;
            case BackstagePasses:
                UpdateBackstagePasses(item);
                break;
            default:
                if (item.Name.StartsWith(ConjuredPrefix, StringComparison.OrdinalIgnoreCase))
                {
                    UpdateConjuredItem(item);
                }
                else
                {
                    UpdateNormalItem(item);
                }
                break;
        }
    }

    private static void UpdateNormalItem(Item item)
    {
        DecreaseQuality(item);
        item.SellIn--;

        if (item.SellIn < 0)
        {
            DecreaseQuality(item);
        }
    }

    private static void UpdateConjuredItem(Item item)
    {
        DecreaseQuality(item);
        DecreaseQuality(item);
        item.SellIn--;

        if (item.SellIn < 0)
        {
            DecreaseQuality(item);
            DecreaseQuality(item);
        }
    }

    private static void UpdateAgedBrie(Item item)
    {
        IncreaseQuality(item);
        item.SellIn--;

        if (item.SellIn < 0)
        {
            IncreaseQuality(item);
        }
    }

    private static void UpdateBackstagePasses(Item item)
    {
        IncreaseQuality(item);

        if (item.SellIn < 11)
        {
            IncreaseQuality(item);
        }

        if (item.SellIn < 6)
        {
            IncreaseQuality(item);
        }

        item.SellIn--;

        if (item.SellIn < 0)
        {
            item.Quality = MinQuality;
        }
    }

    private static void IncreaseQuality(Item item)
    {
        if (item.Quality < MaxQuality)
        {
            item.Quality++;
        }
    }

    private static void DecreaseQuality(Item item)
    {
        if (item.Quality > MinQuality)
        {
            item.Quality--;
        }
    }
}
