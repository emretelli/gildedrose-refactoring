
namespace GildedRoseKata
{
    public class SulfurasItem : GildedRoseItem
    {
        public SulfurasItem(Item item) : base(item)
        {

        }

        public override void Execute()
        {
            base.ValidateMinMaxQuality();
        }
    }
}
