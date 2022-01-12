
namespace GildedRoseKata
{
    public class OrdinaryItem : GildedRoseItem
    {
        public OrdinaryItem(Item item) : base(item)
        {

        }

        public override void Execute()
        {
            base.DecreaseSellInDay();
            base.DecreaseQuality();
        }
    }
}
