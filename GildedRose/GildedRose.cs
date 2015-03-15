using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;

namespace GildedRose
{
	class GildedRose
	{
	    readonly IList<Item> _items;
		public GildedRose(IList<Item> items) 
		{
			_items = items;
		}
		
		public void UpdateQuality()
		{
		    foreach (var item in _items)
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
            DecrementSellIn(1);
            var qualityIncrement = (SellIn < 0) ? 2 : 1;
            IncrementQuality(qualityIncrement);
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
            var incrementQuality = 1;
            
            if (SellIn < 6)
                incrementQuality = 3;
            else if (SellIn < 11)
                incrementQuality = 2;
            
            IncrementQuality(incrementQuality);
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

    public class ConjuredItem : Item
    {
        public ConjuredItem(int sellIn, int quality)
            : base("Conjured Mana Cake", sellIn, quality)
        {
        }

        public override void Update()
        {
            DecrementQuality(2);
            DecrementSellIn(1);
        }
    }
	
	public class Item
	{
	    private const int MaxQualityValue = 50;
	    private const int MinQualityValue = 0;

	    public Item(string name, Int32 sellIn, Int32 quality)
	    {
	        Name = name;
	        SellIn = sellIn;
	        Quality = quality;
	    }

	    public string Name { get; private set; }
		
		public int SellIn { get; private set; }
		
		public int Quality { get; private set; }

	    protected void DecrementQuality(int quantity)
	    {
	        if (Quality - quantity >= MinQualityValue)
	            Quality = Quality - quantity;
	        else
	            Quality = MinQualityValue;
	    }

	    protected void IncrementQuality(int quantity)
	    {
	        if (Quality + quantity <= MaxQualityValue)
	            Quality = Quality + quantity;
	        else
                Quality = MaxQualityValue;
	    }

	    protected void ResetQuality()
	    {
	        Quality = MinQualityValue;
	    }

	    protected void DecrementSellIn(int quantity)
	    {
	        SellIn = SellIn - quantity;
	    }

	    public virtual void Update()
	    {
	        var decrementQuality = 1;
	        DecrementSellIn(1);

	        if (SellIn < 0) 
                decrementQuality = 2;

	        DecrementQuality(decrementQuality);
	    }

	    public override string ToString()
	    {
	        return Name + ", " + SellIn + ", " + Quality;
	    }
	}
}
