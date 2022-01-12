using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata
{
    public class ConjuredItem : GildedRoseItem
    {
        public ConjuredItem(Item item) : base(item)
        {

        }

        public override void Execute()
        {
            base.DecreaseSellInDay();
            //twice to normal items
            base.DecreaseQuality();
            base.DecreaseQuality();
        }
    }
}
