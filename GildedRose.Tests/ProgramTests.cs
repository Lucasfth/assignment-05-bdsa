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
}