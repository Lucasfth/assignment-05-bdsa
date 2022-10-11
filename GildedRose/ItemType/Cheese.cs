namespace GildedRose.ItemType;

public class Cheese : Item
{
    public override void Update()
    {
        SellIn--;
        
        int factor = 1;
        if (IsConjured) factor = 2;

        if (SellIn < 0) AlterQuality(2 * factor);
        else AlterQuality(factor);
    }
}
