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
        
        private void DecreaseQuality(Item item)
        {
            item.Quality -= 1;
        }
        
        private void IncreaseQuality(Item item)
        {
            item.Quality += 1;
        }
        
        private void SellInDecrease(Item item)
        {
            item.SellIn -= 1;
        }
        
        private bool IsBackstage(Item item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }
        
        private bool IsNotSulfuras(Item item)
        {
            return item.Name != "Sulfuras, Hand of Ragnaros";
        }
        
        private void ResetQualityToZero(Item item)
        { 
            item.Quality -= item.Quality;
        }
        
        private bool isAgedBrie(Item item)
        {
            return item.Name == "Aged Brie";
        }
        

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                if (IsNotSulfuras(item))
                {
                    if (item.Name is "Aged Brie" or "Backstage passes to a TAFKAL80ETC concert") 
                    {
                        if (item.Quality < 50)
                        {
                            IncreaseQuality(item);

                            if (IsBackstage(item))
                            { 
                                if (item.SellIn < 11) 
                                { 
                                    if (item.Quality < 50) 
                                    { 
                                        IncreaseQuality(item); 
                                    } 
                                }
                                if (item.SellIn < 6) 
                                { 
                                    if (item.Quality < 50) 
                                    { 
                                        IncreaseQuality(item); 
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (item.Quality > 0)
                        {
                            DecreaseQuality(item);
                        }
                        
                    }
                    
                    SellInDecrease(item);
                    
                    if (item.SellIn < 0)
                    {
                        
                        switch (isAgedBrie(item))
                        {
                            
                            case true :
                                if (item.Quality < 50)
                                {
                                    IncreaseQuality(item);
                                }
                                break;
                            
                            case false :
                                if (IsBackstage(item))
                                {
                                    ResetQualityToZero(item);
                                }
                                else
                                {
                                    if (item.Quality > 0)
                                    {
                                        DecreaseQuality(item);
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
