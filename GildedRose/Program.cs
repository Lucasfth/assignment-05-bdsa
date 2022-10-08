using System;
using System.Collections.Generic;

namespace GildedRose
{
    public class Program
    {
        public IList<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
                          {
                              Items = new List<Item>
                                          {
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
				// this conjured item does not work properly yet
				new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
                                          }

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
                app.UpdateQuality();
            }

        }

        public void AlterQuality(Item item, int qualityChange)
        {
            item.Quality += qualityChange;
            if (item.Quality > 50) item.Quality = 50;
            if (item.Quality < 0) item.Quality = 0;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                var legendary = item.Name =="Sulfuras, Hand of Ragnaros";
                if (legendary) continue;

                item.SellIn--;
                var expired = item.SellIn<0;
                switch (item.Name)
                {
                    case "Aged Brie":
                        AlterQuality(item, expired ? 2 : 1);
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        if (expired) item.Quality = 0;
                        else
                        {
                            var qualityChange = 1;
                            if (item.SellIn < 5) qualityChange = 3;
                            else if (item.SellIn < 10) qualityChange = 2;
                            AlterQuality(item, qualityChange);
                        }
                    break;
                    case "Conjuring Mana Cake":
                        AlterQuality(item, expired ? -4 : -2);
                    break;
                    default:
                        AlterQuality(item, expired ? -2 : -1);
                    break;
                    
                }
            }
        }

    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}
