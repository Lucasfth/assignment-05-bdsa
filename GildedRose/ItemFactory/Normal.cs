namespace GildedRose;

public class Normal : Item
{
    public override void Update()
    {
        this.SellIn--;

        if (50 <= this.Quality) {
            this.Quality = 50;
            return;
        }
        else if (this.Quality <= 0) {
            this.Quality = 0;
            return;
        }

        int factor = 1;
        if (_IsConjured) factor = 2;

        if (this.SellIn < 0) this.Quality -= 2 * factor;
        else this.Quality -= 1 * factor;
    }
}