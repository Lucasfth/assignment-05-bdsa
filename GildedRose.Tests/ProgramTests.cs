namespace GildedRose.Tests;

public class ProgramTests
{
    [Fact]
    public void Normal_Item_Degrades_By_1_Quality_When_Not_Expired()
    {
        // Arrange
        var np = new Program();
        var item = np.CreateItem("Normal Item", 10, 20);
        np.Items = new List<Item> { item };

        // Act
        np.UpdateItems();

        // Assert
        np.Items[0].Name.Should().Be("Normal Item");
        np.Items[0].SellIn.Should().Be(9);
        np.Items[0].Quality.Should().Be(19);
    }

    [Fact]
    public void Normal_Conjured_Item_Degrades_By_2_Quality_When_Not_Expired()
    {
        // Arrange
        var np = new Program();
        var item = np.CreateItem("Conjured Normal Item", 10, 20);
        np.Items = new List<Item> { item };

        // Act
        np.UpdateItems();

        // Assert
        np.Items[0].Name.Should().Be("Conjured Normal Item");
        np.Items[0].SellIn.Should().Be(9);
        np.Items[0].Quality.Should().Be(18);
    }

    [Fact]
    public void Normal_Item_Degrades_By_2_Quality_When_Expired()
    {
        // Arrange
        var np = new Program();
        var item = np.CreateItem("Normal Item", 0, 20);
        np.Items = new List<Item> { item };

        // Act
        np.UpdateItems();

        // Assert
        np.Items[0].Name.Should().Be("Normal Item");
        np.Items[0].SellIn.Should().Be(-1);
        np.Items[0].Quality.Should().Be(18);
    }

    [Fact]
    public void Normal_Conjured_Item_Degrades_By_4_Quality_When_Expired()
    {
        // Arrange
        var np = new Program();
        var item = np.CreateItem("Conjured Normal Item", 0, 20);
        np.Items = new List<Item> { item };

        // Act
        np.UpdateItems();

        // Assert
        np.Items[0].Name.Should().Be("Conjured Normal Item");
        np.Items[0].SellIn.Should().Be(-1);
        np.Items[0].Quality.Should().Be(16);
    }

    [Fact]
    public void Aged_Brie_Increases_By_1_Quality_When_Not_Expired()
    {
        // Arrange
        var np = new Program();
        var item = np.CreateItem("Aged Brie", 10, 20);
        np.Items = new List<Item> { item };

        // Act
        np.UpdateItems();

        // Assert
        np.Items[0].Name.Should().Be("Aged Brie");
        np.Items[0].SellIn.Should().Be(9);
        np.Items[0].Quality.Should().Be(21);
    }

    [Fact]
    public void Aged_Conjured_Brie_Increases_By_2_Quality_When_Not_Expired()
    {
        // Arrange
        var np = new Program();
        var item = np.CreateItem("Conjured Aged Brie", 10, 20);
        np.Items = new List<Item> { item };

        // Act
        np.UpdateItems();

        // Assert
        np.Items[0].Name.Should().Be("Conjured Aged Brie");
        np.Items[0].SellIn.Should().Be(9);
        np.Items[0].Quality.Should().Be(22);
    }

    [Fact]
    public void Aged_Brie_Increases_By_2_Quality_When_Expired()
    {
        // Arrange
        var np = new Program();
        var item = np.CreateItem("Aged Brie", 0, 20);
        np.Items = new List<Item> { item };

        // Act
        np.UpdateItems();

        // Assert
        np.Items[0].Name.Should().Be("Aged Brie");
        np.Items[0].SellIn.Should().Be(-1);
        np.Items[0].Quality.Should().Be(22);
    }

    [Fact]
    public void Aged_Conjured_Brie_Increases_By_4_Quality_When_Expired()
    {
        // Arrange
        var np = new Program();
        var item = np.CreateItem("Conjured Aged Brie", 0, 20);
        np.Items = new List<Item> { item };

        // Act
        np.UpdateItems();

        // Assert
        np.Items[0].Name.Should().Be("Conjured Aged Brie");
        np.Items[0].SellIn.Should().Be(-1);
        np.Items[0].Quality.Should().Be(24);
    }

    [Fact]
    public void Legendary_Item_Does_Not_Change()
    {
        //Arrange
        var np = new Program();
        var item = np.CreateItem("Sulfuras, Hand of Ragnaros", 0, 80);
        np.Items = new List<Item> { item };
        
        //Act
        np.UpdateItems();
        
        //Assert
        np.Items[0].Name.Should().Be("Sulfuras, Hand of Ragnaros");
        np.Items[0].SellIn.Should().Be(0);
        np.Items[0].Quality.Should().Be(80);
    }

    [Fact]
    public void Legendary_Conjured_Item_Does_Not_Change()
    {
        //Arrange
        var np = new Program();
        var item = np.CreateItem("Conjured Sulfuras, Hand of Ragnaros", 0, 80);
        np.Items = new List<Item> { item };
        
        //Act
        np.UpdateItems();
        
        //Assert
        np.Items[0].Name.Should().Be("Conjured Sulfuras, Hand of Ragnaros");
        np.Items[0].SellIn.Should().Be(0);
        np.Items[0].Quality.Should().Be(80);
    }

    [Fact]
    public void Item_Quality_Cannot_Be_Higher_Than_50()
    {
        // Arrange
        var np = new Program();
        var item = np.CreateItem("Aged Brie", 10, 50);
        np.Items = new List<Item> { item };

        // Act
        np.UpdateItems();

        // Assert
        np.Items[0].Name.Should().Be("Aged Brie");
        np.Items[0].SellIn.Should().Be(9);
        np.Items[0].Quality.Should().Be(50);
    }

    [Fact]
    public void Item_Quality_Cannot_Be_Negative()
    {
        // Arrange
        var np = new Program();
        var item = np.CreateItem("Normal Item", 10, 0);
        np.Items = new List<Item> { item };

        // Act
        np.UpdateItems();

        // Assert
        np.Items[0].Name.Should().Be("Normal Item");
        np.Items[0].SellIn.Should().Be(9);
        np.Items[0].Quality.Should().Be(0);
    }
    
    [Fact]
    public void Backstage_Pass_Increase_By_1_Quality_When_SellIn_More_Than_10()
    {
        // Arrange
        var np = new Program();
        var item = np.CreateItem("Backstage passes to a TAFKAL80ETC concert", 15, 20);
        np.Items = new List<Item> { item };

        // Act
        np.UpdateItems();

        // Assert
        np.Items[0].Name.Should().Be("Backstage passes to a TAFKAL80ETC concert");
        np.Items[0].SellIn.Should().Be(14);
        np.Items[0].Quality.Should().Be(21);
    }

    [Fact]
    public void Conjured_Backstage_Pass_Increase_By_2_Quality_When_SellIn_More_Than_10()
    {
        // Arrange
        var np = new Program();
        var item = np.CreateItem("Conjured Backstage passes to a TAFKAL80ETC concert", 15, 20);
        np.Items = new List<Item> { item };

        // Act
        np.UpdateItems();

        // Assert
        np.Items[0].Name.Should().Be("Conjured Backstage passes to a TAFKAL80ETC concert");
        np.Items[0].SellIn.Should().Be(14);
        np.Items[0].Quality.Should().Be(22);
    }

    [Fact]
    public void Backstage_Pass_Increase_By_2_Quality_When_SellIn_Less_Than_10_Days()
    {
        // Arrange
        var np = new Program();
        var item = np.CreateItem("Backstage passes to a TAFKAL80ETC concert", 9, 20);
        np.Items = new List<Item> { item };

        // Act
        np.UpdateItems();

        // Assert
        np.Items[0].Name.Should().Be("Backstage passes to a TAFKAL80ETC concert");
        np.Items[0].SellIn.Should().Be(8);
        np.Items[0].Quality.Should().Be(22);
    }

    [Fact]
    public void Conjured_Backstage_Pass_Increase_By_4_Quality_When_SellIn_Less_Than_10_Days()
    {
        // Arrange
        var np = new Program();
        var item = np.CreateItem("Conjured Backstage passes to a TAFKAL80ETC concert", 9, 20);
        np.Items = new List<Item> { item };

        // Act
        np.UpdateItems();

        // Assert
        np.Items[0].Name.Should().Be("Conjured Backstage passes to a TAFKAL80ETC concert");
        np.Items[0].SellIn.Should().Be(8);
        np.Items[0].Quality.Should().Be(24);
    }

    [Fact]
    public void Backstage_Pass_Increase_By_3_Quality_When_SellIn_Less_Than_5_Days()
    {
        // Arrange
        var np = new Program();
        var item = np.CreateItem("Backstage passes to a TAFKAL80ETC concert", 4, 20);
        np.Items = new List<Item> { item };

        // Act
        np.UpdateItems();

        // Assert
        np.Items[0].Name.Should().Be("Backstage passes to a TAFKAL80ETC concert");
        np.Items[0].SellIn.Should().Be(3);
        np.Items[0].Quality.Should().Be(23);
    }

    [Fact]
    public void Conjured_Backstage_Pass_Increase_By_6_Quality_When_SellIn_Less_Than_5_Days()
    {
        // Arrange
        var np = new Program();
        var item = np.CreateItem("Conjured Backstage passes to a TAFKAL80ETC concert", 4, 20);
        np.Items = new List<Item> { item };

        // Act
        np.UpdateItems();

        // Assert
        np.Items[0].Name.Should().Be("Conjured Backstage passes to a TAFKAL80ETC concert");
        np.Items[0].SellIn.Should().Be(3);
        np.Items[0].Quality.Should().Be(26);
    }
    
    [Fact]
    public void Backstage_Pass_Quality_0_When_Concert_Done()
    {
        // Arrange
        var np = new Program();
        var item = np.CreateItem("Backstage passes to a TAFKAL80ETC concert", 0, 20);
        np.Items = new List<Item> { item };

        // Act
        np.UpdateItems();

        // Assert
        np.Items[0].Name.Should().Be("Backstage passes to a TAFKAL80ETC concert");
        np.Items[0].SellIn.Should().Be(-1);
        np.Items[0].Quality.Should().Be(0);
    }

    [Fact]
    public void Conjured_Backstage_Pass_Quality_0_When_Concert_Done()
    {
        // Arrange
        var np = new Program();
        var item = np.CreateItem("Conjured Backstage passes to a TAFKAL80ETC concert", 0, 20);
        np.Items = new List<Item> { item };

        // Act
        np.UpdateItems();

        // Assert
        np.Items[0].Name.Should().Be("Conjured Backstage passes to a TAFKAL80ETC concert");
        np.Items[0].SellIn.Should().Be(-1);
        np.Items[0].Quality.Should().Be(0);
    }

    [Fact]
    public void Conjured_Item_Degrades_By_2_Quality_When_Not_Expired()
    {
        // Arrange
        var np = new Program();
        var item = np.CreateItem("Conjured Mana Cake", 10, 20);
        np.Items = new List<Item> { item };

        // Act
        np.UpdateItems();

        // Assert
        np.Items[0].Name.Should().Be("Conjured Mana Cake");
        np.Items[0].SellIn.Should().Be(9);
        np.Items[0].Quality.Should().Be(18);
    }

    [Fact]
    public void Normal_Item_Degrades_By_1_When_Quality_Is_50_And_Not_Expired()
    {
        // Arrange
        var np = new Program();
        var item = np.CreateItem("Normal item",40,50);
        np.Items = new List<Item> { item };

        // Act
        np.UpdateItems();

        // Assert
        np.Items[0].Name.Should().Be("Normal item");
        np.Items[0].SellIn.Should().Be(39);
        np.Items[0].Quality.Should().Be(49);
    }

    [Fact]
    public void No_Item_Should_Not_Be_Updated() 
    {
        // Arrange
        var np = new Program();

        // Act
        np.UpdateItems();

        // Assert
        np.Items.Should().BeNull();
    }
}
