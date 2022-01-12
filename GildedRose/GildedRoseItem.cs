
namespace GildedRoseKata
{
    public abstract class GildedRoseItem
    {
        protected readonly Item Item;

        protected GildedRoseItem(Item item)
        {
            this.Item = item;
        }

        public abstract void Execute();

        public void DecreaseQuality()
        {
            int qualityChange = GetQualityDecreaseOfOrdinaryItem();
            UpdateQuality(qualityChange);
        }

        public void UpdateQuality(int qualityChange)
        {
            Item.Quality += qualityChange;
            ValidateMinMaxQuality();
        }

        public void DecreaseSellInDay()
        {
            Item.SellIn -= 1;
        }

        public void ValidateMinMaxQuality()
        {
            if(Item.Quality < 0)
            {
                Item.Quality = 0;
            }
            else if(Item.Quality > GetPossibleMaxQualityValue())
            {
                Item.Quality = GetPossibleMaxQualityValue();
            }
        }

        private int GetPossibleMaxQualityValue()
        {
            return Item.Name.Equals(Utils.SULFURAS) ? 80 : 50;
        }

        public int GetQualityDecreaseOfOrdinaryItem()
        {
            if (Item.SellIn >= 0)
                return -1;
            else
                return -2;
        }
    }
}
