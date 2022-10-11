namespace GildedRose.ItemType;

public class BackstagePass : Item
{
    public override void Update()
    {
        SellIn--;

        int factor = 1;
        if (IsConjured) factor = 2;

        if (SellIn < 0){
            Quality = 0;
            return;
        } 
        if (SellIn < 5) factor *= 3;
        else if (SellIn < 10) factor *= 2;
        
        AlterQuality(factor);
    }
}
