using System.Collections.Generic;

namespace GildedTros.App
{
    public class GildedTros
    {
        IList<ItemBase> Items;
        public GildedTros(IList<ItemBase> Items)
        {
            this.Items = Items;
        }

        //https://github.com/NotMyself/GildedRose
        /*
            - apparently you are not allowed to modify the Item class. 
            - since IList is not covariant unlike IEnumerable
         */


        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                item.UpdateQuality();
            }
        }

        /*
        notes:
        
        Backstage passes for Re:factor
        Backstage passes for HAXX

        gaat eerst quality bepalen zommar + op basis van sellin, daarna sellin verlagen, daarna if sellin <0 quality op 0 zetten

        B-DAWG Keychain

        gaat quality verhogen zomaar, dan NOOIT sellin verlagen, mocht sellin vanaf begin <0 zijn dan ook niks, doet gewoon niks

        Good wine

        gaat quality verhogen zomaar, dan sellin verlagen, if <0 dan quality gewoon weer verhogen naar max 50

        Rest:

        gaat altijd quality verlagen, dan sellin verlagen, if <0 dan quality weer verlagen, ondergrens is 0
         */
    }
}
