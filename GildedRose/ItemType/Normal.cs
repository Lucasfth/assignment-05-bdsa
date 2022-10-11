namespace GildedRose.ItemType;

public class Normal : Item
{
    public override void Update()
    {
        this.SellIn--;

        int factor = -1;
        if (IsConjured) factor = -2;

        if (this.SellIn < 0) AlterQuality(2 * factor);
        else AlterQuality(factor);
    }
}