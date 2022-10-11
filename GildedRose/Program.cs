using System;
using System.Collections.Generic;
using GildedRose.ItemType;

namespace GildedRose;

public class Program
{
    public IList<Item>? Items;
    static void Main(string[] args)
    {
        System.Console.WriteLine("OMGHAI!");

        var app = new Program();
                        
        app.Items = new List<Item>
            {
            app.CreateItem( "+5 Dexterity Vest", 10, 20),
            app.CreateItem( "Aged Brie",2, 0 ),
            app.CreateItem( "Elixir of the Mongoose", 5, 7 ),
            app.CreateItem( "Sulfuras, Hand of Ragnaros", 0, 80 ),
            app.CreateItem( "Sulfuras, Hand of Ragnaros", -1, 80 ),
            app.CreateItem( "Backstage passes to a TAFKAL80ETC concert", 15, 20 ),
            app.CreateItem( "Backstage passes to a TAFKAL80ETC concert", 10, 49 ),
            app.CreateItem( "Backstage passes to a TAFKAL80ETC concert", 5, 49 ),
            app.CreateItem( "Conjured Mana Cake", 3, 6 )
            };

        for (var i = 0; i < 31; i++)
        {
            Console.WriteLine("-------- day " + i + " --------");
            Console.WriteLine("name, sellIn, quality");
            for (var j = 0; j < app.Items.Count; j++)
            {
                Console.WriteLine(app.Items[j].Name + ", " + app.Items[j].SellIn + ", " + app.Items[j].Quality);
            }
            Console.WriteLine("");
            app.UpdateItems();
        }

    }

    public void UpdateItems() => Items?.ToList().ForEach(x => x.Update());

    public Item CreateItem(String name, int sellIn, int quality)
    {
        Item item;
        var nameLower = name.ToLower();
        
        if (nameLower.Contains("aged"))
            item = new Cheese() { Name = name, SellIn = sellIn, Quality = quality };
        else if (nameLower.Contains("backstage"))
            item = new BackstagePass() { Name = name, SellIn = sellIn, Quality = quality };
        else if (nameLower.Contains("sulfuras"))
            item = new Legendary() { Name = name, SellIn = sellIn, Quality = quality };
        else
            item = new Normal() { Name = name, SellIn = sellIn, Quality = quality };
        
        if (nameLower.Contains("conjured")) item.SetConjured();
        
        return item;
    }

}