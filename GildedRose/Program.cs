using System.Collections.Generic;

namespace GildedRose
{
	class Program
	{
		public static void Main(string[] args)
		{
			System.Console.WriteLine("OMGHAI!");

		    IList<Item> items = new List<Item>
		    {
		        new Item("+5 Dexterity Vest", 10, 20),
		        new AgedBrieItem(2, 0),
		        new Item("Elixir of the Mongoose", 5, 7),
                new SulfurasItem(0, 80),
                new SulfurasItem(-1, 80),
		        new BackstageItem(15, 20),
		        new BackstageItem(10, 49),
		        new BackstageItem(5, 49),
		        // this conjured item does not work properly yet
		        new Item("Conjured Mana Cake", 3, 6)
		    };

			var app = new GildedRose(items);

			
			for (var i = 0; i < 31; i++)
			{
				System.Console.WriteLine("-------- day " + i + " --------");
				System.Console.WriteLine("name, sellIn, quality");
				
                foreach (var item in items)
                {
                    System.Console.WriteLine(item.ToString());
                }
			    System.Console.WriteLine("");
				app.UpdateQuality();
			}
		}
	}
}
