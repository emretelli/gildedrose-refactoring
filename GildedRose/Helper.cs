
using System;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class Helper
    {
        private readonly Dictionary<string, Type> GildedRoseItems = new Dictionary<string, Type>
        {
            {Utils.AGED, typeof(AgedItem)},
            {Utils.BACKSTAGE, typeof(BackStageItem)},
            {Utils.SULFURAS, typeof(SulfurasItem)},
            {Utils.CONJURED, typeof(ConjuredItem)}
        };

        public GildedRoseItem CreateItemInstance(Item item)
        {
            if (GildedRoseItems.ContainsKey(item.Name))
            {
                var itemType = GildedRoseItems[item.Name];
                return Activator.CreateInstance(itemType, item) as GildedRoseItem;
            }
            else
            {
                return Activator.CreateInstance(typeof(OrdinaryItem), item) as GildedRoseItem;
            }
        }
    }
}
