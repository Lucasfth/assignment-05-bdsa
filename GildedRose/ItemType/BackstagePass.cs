namespace GildedRose.ItemType;

public class BackstagePass : Item
{
    public override void Update()
    {
        this.SellIn--;

        int factor = 1;
        if (IsConjured) factor = 2;

        if (this.SellIn < 0){
            this.Quality = 0;
            return;
        } 
        if (this.SellIn < 5) factor *= 3;
        else if (this.SellIn < 10) factor *= 2;
        
        AlterQuality(factor);
    }
}
