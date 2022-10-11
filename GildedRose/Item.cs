namespace GildedRose
{
    /* 
        Item has been changed to work with inheritance. 
        The reason is that each Item type has different rules for updating its quality
        and by doing it this way, we can have a single UpdateQuality method in Program.cs
        which only call the specified Item's Update method.
        This results in cleaner code and less if statements.

        Item has also been made abstract to ensure that no Item is created without a being a specific type.

        The downside is that we have to create a new class for each Item type.
    */
    public abstract class Item
    {
        protected bool IsConjured = false;
        public string? Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public abstract void Update();

        public virtual void AlterQuality(int amount)
        {
            Quality += amount;
            if (50 < Quality) Quality = 50;
            if (Quality < 0) Quality = 0;
        }

        public void SetConjured(bool isConjured = true) => IsConjured = isConjured;
    }
}