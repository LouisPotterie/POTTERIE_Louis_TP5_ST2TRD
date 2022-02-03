namespace csharp
{
    public class ItemUpdate
    {
        private Item item;

        public ItemUpdate(Item item)
        {
            this.item = item;
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
        
        private bool isConjured(Item item)
        {
            var s = item.Name;
            var subs = s.Split(' ');
            return subs[0] == "Conjured";
        }
        
        private bool IsAgedBrieOrConcertTicket(Item item)
        {
            return item.Name is "Aged Brie" or "Backstage passes to a TAFKAL80ETC concert";
        }
        
        public void UpdateItem()
        {
            
                if (IsNotSulfuras(item))
                {
                    if (IsAgedBrieOrConcertTicket(item)) 
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
                    else if (isConjured(item))
                    {
                        DecreaseQuality(item);
                        DecreaseQuality(item);
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
                                else if (isConjured(item))
                                {
                                    if (item.Quality > 0)
                                    {
                                        DecreaseQuality(item);
                                        DecreaseQuality(item);
                                    }
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