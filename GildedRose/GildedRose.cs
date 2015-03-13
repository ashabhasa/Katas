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
		        item.Update();
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

	    public void Update()
	    {
	        if (Name != "Aged Brie" && Name != "Backstage passes to a TAFKAL80ETC concert")
	        {
	            if (Quality > 0)
	            {
	                if (Name != "Sulfuras, Hand of Ragnaros")
	                {
	                    DecrementQuality(1);
	                }
	            }
	        }
	        else
	        {
	            if (Quality < 50)
	            {
	                IncrementQuality(1);

	                if (Name == "Backstage passes to a TAFKAL80ETC concert")
	                {
	                    if (SellIn < 11)
	                    {
	                        if (Quality < 50)
	                        {
	                            IncrementQuality(1);
	                        }
	                    }

	                    if (SellIn < 6)
	                    {
	                        if (Quality < 50)
	                        {
	                            IncrementQuality(1);
	                        }
	                    }
	                }
	            }
	        }

	        if (Name != "Sulfuras, Hand of Ragnaros")
	        {
	            DecrementSellIn(1);
	        }

	        if (SellIn < 0)
	        {
	            if (Name != "Aged Brie")
	            {
	                if (Name != "Backstage passes to a TAFKAL80ETC concert")
	                {
	                    if (Quality > 0)
	                    {
	                        if (Name != "Sulfuras, Hand of Ragnaros")
	                        {
	                            DecrementQuality(1);
	                        }
	                    }
	                }
	                else
	                {
	                    ResetQuality();
	                }
	            }
	            else
	            {
	                if (Quality < 50)
	                {
	                    IncrementQuality(1);
	                }
	            }
	        }
	    }
	}
	
}
