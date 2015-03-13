using System;
using System.Collections.Generic;

namespace GildedRose
{
	class GildedRose
	{
		IList<Item> Items;
		public GildedRose(IList<Item> Items) 
		{
			this.Items = Items;
		}
		
		public void UpdateQuality()
		{
		    foreach (var item in Items)
		    {
		        UpdateItem(item);
		    }
		}

	    private static void UpdateItem(Item item)
	    {
	        if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
	        {
	            if (item.Quality > 0)
	            {
	                if (item.Name != "Sulfuras, Hand of Ragnaros")
	                {
	                    item.DecrementQuality(1);
	                }
	            }
	        }
	        else
	        {
	            if (item.Quality < 50)
	            {
	                item.IncrementQuality(1);

	                if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
	                {
	                    if (item.SellIn < 11)
	                    {
	                        if (item.Quality < 50)
	                        {
	                            item.IncrementQuality(1);
	                        }
	                    }

	                    if (item.SellIn < 6)
	                    {
	                        if (item.Quality < 50)
	                        {
	                            item.IncrementQuality(1);
	                        }
	                    }
	                }
	            }
	        }

	        if (item.Name != "Sulfuras, Hand of Ragnaros")
	        {
	            item.DecrementSellIn(1);
	        }

	        if (item.SellIn < 0)
	        {
	            if (item.Name != "Aged Brie")
	            {
	                if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
	                {
	                    if (item.Quality > 0)
	                    {
	                        if (item.Name != "Sulfuras, Hand of Ragnaros")
	                        {
	                            item.DecrementQuality(1);
	                        }
	                    }
	                }
	                else
	                {
	                    item.ResetQuality();
	                }
	            }
	            else
	            {
	                if (item.Quality < 50)
	                {
	                    item.IncrementQuality(1);
	                }
	            }
	        }
	    }
	}
	
	public class Item
	{
	    public Item(string name, Int32 sellIn, Int32 quality)
	    {
	        Name = name;
	        SellIn = sellIn;
	        Quality = quality;
	    }

	    public string Name { get; private set; }
		
		public int SellIn { get; private set; }
		
		public int Quality { get; private set; }

	    public void DecrementQuality(int i)
	    {
	        Quality = Quality - i;
	    }

	    public void IncrementQuality(int i)
	    {
	        Quality = Quality + i;
	    }

	    public void ResetQuality()
	    {
	        Quality = 0;
	    }

	    public void DecrementSellIn(int i)
	    {
	        SellIn = SellIn - i;
	    }
	}
	
}
