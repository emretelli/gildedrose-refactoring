
namespace GildedRoseKata
{
    public class BackStageItem : GildedRoseItem
    {
        public BackStageItem(Item item) : base(item)
        {

        }

        public override void Execute()
        {
            base.DecreaseSellInDay();
            int qualityChange = GetQualityBySellInDay();
            base.UpdateQuality(qualityChange);
        }

        private int GetQualityBySellInDay()
        {
            if(Item.SellIn > 10)
            {
                return 1;
            }
            else if(Item.SellIn > 5)
            {
                return 2;
            }
            else if (Item.SellIn > 0)
            {
                return 3;
            }
            else
            {
                return Item.Quality*-1;
            }
        }
    }
}
