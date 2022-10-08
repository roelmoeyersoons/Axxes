namespace GildedTros.App
{
    public class ItemBase : Item
    {
        public const int QUALITY_UPPER_BOUND = 50;

        /// <summary>
        /// Increments item quality with a maximum upper bound
        /// </summary>
        /// <returns>DidIncrement</returns>
        public bool IncrementQuality()
        {
            if (Quality < QUALITY_UPPER_BOUND)
            {
                Quality++;
                return true;
            }
            return false;
        }

        public virtual void UpdateQuality()
        {
            if (Quality > 0)
            {
                Quality = Quality - 1;
            }

            SellIn = SellIn - 1;

            if (SellIn < 0)
            {
                if (Quality > 0)
                {
                    Quality = Quality - 1;
                }
            }
        }

        public override string ToString()
        {
            return Name + ", " + SellIn + ", " + Quality;
        }
    }
}
