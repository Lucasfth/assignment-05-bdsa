namespace GildedRose.Tests;

public class ProgramTests
{
    [Fact]
    public void Normal_Item_Degrades_By_1_Quality_When_Not_Expired()
    {
        // Arrange
        var items = new Item { Name = "Normal Item", SellIn = 10, Quality = 20 };
        var np = new Program();
        np.Items = new List<Item> { items };

        // Act
        np.UpdateQuality();

        // Assert
        np.Items[0].Name.Should().Be("Normal Item");
        np.Items[0].SellIn.Should().Be(9);
        np.Items[0].Quality.Should().Be(19);
    }

    [Fact]
    public void Aged_Brie_Increases_By_1_Quality_When_Not_Expired()
    {
        // Arrange
        var items = new Item { Name = "Aged Brie", SellIn = 10, Quality = 20 };
        var np = new Program();
        np.Items = new List<Item> { items };

        // Act
        np.UpdateQuality();

        // Assert
        np.Items[0].Name.Should().Be("Aged Brie");
        np.Items[0].SellIn.Should().Be(9);
        np.Items[0].Quality.Should().Be(21);
    }

    [Fact]
    public void Legendary_Item_Degrades_only_by_SellIn()
    {
        //Arrange
        var items = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };
        var np = new Program();
        np.Items = new List<Item> { items };
        
        //Act
        np.UpdateQuality();
        
        //Assert
        np.Items[0].Name.Should().Be("Sulfuras, Hand of Ragnaros");
        np.Items[0].SellIn.Should().Be(0);
        np.Items[0].Quality.Should().Be(80);

    }

    [Fact]
    public void Item_Quality_Cannot_Be_Higher_Than_50()
    {
        // Arrange
        var items = new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 };
        var np = new Program();
        np.Items = new List<Item> { items };

        // Act
        np.UpdateQuality();

        // Assert
        np.Items[0].Name.Should().Be("Aged Brie");
        np.Items[0].SellIn.Should().Be(9);
        np.Items[0].Quality.Should().Be(50);
    }
    
    [Fact]
    public void Backstage_Pass_Increase_By_1_When_SellIn_More_Than_10()
    {
        // Arrange
        var items = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 };
        var np = new Program();
        np.Items = new List<Item> { items };

        // Act
        np.UpdateQuality();

        // Assert
        np.Items[0].Name.Should().Be("Backstage passes to a TAFKAL80ETC concert");
        np.Items[0].SellIn.Should().Be(14);
        np.Items[0].Quality.Should().Be(21);
    }

    [Fact]
    public void Backstage_Pass_Increase_By_2_When_SellIn_Less_Than_10_Days()
    {
        // Arrange
        var items = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 20 };
        var np = new Program();
        np.Items = new List<Item> { items };

        // Act
        np.UpdateQuality();

        // Assert
        np.Items[0].Name.Should().Be("Backstage passes to a TAFKAL80ETC concert");
        np.Items[0].SellIn.Should().Be(8);
        np.Items[0].Quality.Should().Be(22);
    }

    [Fact]
    public void Backstage_Pass_Increase_By_3_When_SellIn_Less_Than_5_Days()
    {
        // Arrange
        var items = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 20 };
        var np = new Program();
        np.Items = new List<Item> { items };

        // Act
        np.UpdateQuality();

        // Assert
        np.Items[0].Name.Should().Be("Backstage passes to a TAFKAL80ETC concert");
        np.Items[0].SellIn.Should().Be(3);
        np.Items[0].Quality.Should().Be(23);
    }
    
    [Fact]
    public void Backstage_Pass_Quality_0_When_Concert_Done()
    {
        // Arrange
        var items = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 };
        var np = new Program();
        np.Items = new List<Item> { items };

        // Act
        np.UpdateQuality();

        // Assert
        np.Items[0].Name.Should().Be("Backstage passes to a TAFKAL80ETC concert");
        np.Items[0].SellIn.Should().Be(-1);
        np.Items[0].Quality.Should().Be(0);
    }
}
