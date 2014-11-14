using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata
{
    public class Scanner
    {
        private readonly IDictionary<string, int> _priceList = new Dictionary<string, int>
        {
            {"A", 50},
            {"B", 30},
            {"C", 20},
            {"D", 15},
        };

        private readonly List<Promotion> _promotions = new List<Promotion>
        {
            new Promotion
            {
                Sku = "A",
                SpecialCount = 3,
                SpecialPrice = 130
            },
            new Promotion
            {
                Sku = "B",
                SpecialCount = 2,
                SpecialPrice = 45
            }
        };

        private int _total;
        private readonly List<string> _items = new List<string>();

        public void Scann(string sku)
        {
            _items.Add(sku);
        }

        public int GetTotal()
        {
            var items = _items.GroupBy(x => x).Select(g => new { Sku = g.Key, Count = g.Count() });

            foreach (var item in items)
            {
                var promotion = _promotions.Find(x => x.Sku == item.Sku);
                _total += promotion != null
                    ? GetSpecialPrice(promotion, item.Sku, item.Count)
                    : GetPrice(item.Sku, item.Count);
            }

            return _total;
        }

        private int GetPrice(string sku, int count)
        {
            return _priceList[sku] * count;
        }

        private int GetSpecialPrice(Promotion promotion, string sku, int count)
        {
            return (promotion.SpecialPrice * (count / promotion.SpecialCount)) + (_priceList[sku] * (count % promotion.SpecialCount));
        }
    }
}