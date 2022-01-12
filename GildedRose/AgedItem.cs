
namespace GildedRoseKata
{
    public class AgedItem : GildedRoseItem
    {
        public AgedItem(Item item) : base(item)
        {

        }

        public override void Execute()
        {
            base.DecreaseSellInDay();
            int qualityChange = base.GetQualityDecreaseOfOrdinaryItem();
            base.UpdateQuality(qualityChange*-1);
        }
    }
}
