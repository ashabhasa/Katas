using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

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

    public class AgedBrieItem : Item
    {
        public AgedBrieItem(int sellIn, int quality)
            : base("Aged Brie", sellIn, quality)
        {
           
        }

        public override void Update()
        {
            if (Quality < 50)
            {
                IncrementQuality(1);
            }

            DecrementSellIn(1);

            if (Quality < 50 && SellIn < 0)
            {
                IncrementQuality(1);
            }
        }
    }

    public class BackstageItem : Item
    {
        public BackstageItem(int sellIn, int quality)
            : base("Backstage passes to a TAFKAL80ETC concert", sellIn, quality)
        {
        }

        public override void Update()
        {
            if (Quality < 50)
            {
                IncrementQuality(1);
            }

            if (Quality < 50 && SellIn < 11)
            {
                IncrementQuality(1);
            }

            if (Quality < 50 && SellIn < 6)
            {
                IncrementQuality(1);
            }

            DecrementSellIn(1);

            if (SellIn < 0)
            {
                ResetQuality();
            }
        }
    }

    public class SulfurasItem : Item
    {
        public SulfurasItem(int sellIn, int quality)
            : base("Sulfuras, Hand of Ragnaros", sellIn, quality)
        {
        }

        public override void Update()
        {
            //do nothing
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

	    public void DecrementQuality(int quantity)
	    {
	        Quality = Quality - quantity;
	    }

	    public void IncrementQuality(int quantity)
	    {
	        Quality = Quality + quantity;
	    }

	    public void ResetQuality()
	    {
	        Quality = 0;
	    }

	    public void DecrementSellIn(int quantity)
	    {
	        SellIn = SellIn - quantity;
	    }

	    public virtual void Update()
	    {
	        if (Quality > 0)
	        {
	            DecrementQuality(1);
	        }

	        DecrementSellIn(1);

	        if (Quality > 0 && SellIn < 0)
	        {
	            DecrementQuality(1);
	        }
	    }

	    public override string ToString()
	    {
	        return Name + ", " + SellIn + ", " + Quality;
	    }
	}
}
