using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }
        
        private void DecreaseQuality(int i)
        {
            Items[i].Quality = Items[i].Quality - 1;
        }
        
        private void IncreaseQuality(int i)
        {
            Items[i].Quality = Items[i].Quality + 1;
        }
        
        private void SellInDecrease(int i)
        {
            Items[i].SellIn = Items[i].SellIn - 1;
        }
        
        private bool IsBackstage(int i)
        {
            return Items[i].Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        private bool IsNotSulfuras(int i)
        {
            return Items[i].Name != "Sulfuras, Hand of Ragnaros";
        }
        
        private void ResetQualityToZero(int i)
        {
            Items[i].Quality = Items[i].Quality - Items[i].Quality;
        }
        
        private bool isAgedBrie(int i)
        {
            return Items[i].Name == "Aged Brie";
        }
        

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (IsNotSulfuras(i))
                {
                    if (Items[i].Name is "Aged Brie" or "Backstage passes to a TAFKAL80ETC concert") 
                    {
                        if (Items[i].Quality < 50)
                        {
                            IncreaseQuality(i);

                            if (IsBackstage(i))
                            { 
                                if (Items[i].SellIn < 11) 
                                { 
                                    if (Items[i].Quality < 50) 
                                    { 
                                        IncreaseQuality(i); 
                                    } 
                                }
                                if (Items[i].SellIn < 6) 
                                { 
                                    if (Items[i].Quality < 50) 
                                    { 
                                        IncreaseQuality(i); 
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (Items[i].Quality > 0)
                        {
                            DecreaseQuality(i);
                        }
                        
                    }
                    
                    SellInDecrease(i);
                    
                    if (Items[i].SellIn < 0)
                    {
                        
                        switch (isAgedBrie(i))
                        {
                            
                            case true :
                                if (Items[i].Quality < 50)
                                {
                                    IncreaseQuality(i);
                                }
                                break;
                            
                            case false :
                                if (IsBackstage(i))
                                {
                                    ResetQualityToZero(i);
                                }
                                else
                                {
                                    if (Items[i].Quality > 0)
                                    {
                                        DecreaseQuality(i);
                                    }
                                }
                                break;


                        }
                        
                    } 
                }
                
            }
        }

        
    }
}
