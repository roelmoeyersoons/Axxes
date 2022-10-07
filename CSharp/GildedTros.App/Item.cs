namespace GildedTros.App
{
    public class Item
    {
        public const int QUALITY_UPPER_BOUND = 50;

        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        /// <summary>
        /// Increments quality with a maximum upper bound
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
    }
}
