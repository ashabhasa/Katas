using NUnit.Framework;

namespace GildedRose
{
    [TestFixture]
    public class ConjuredItemTests
    {
        private const int SellIn = 10;
        private const int Quality = 20;


        [Test]
        public void Update()
        {
            var conjuredItem = new ConjuredItem(SellIn, Quality);

            for (var day = 1; day < 31; day++)
            {
                conjuredItem.Update();

                var expectedQuality = Quality - 2 * day;
                Assert.AreEqual(expectedQuality > 0 ? expectedQuality : 0, conjuredItem.Quality);
                Assert.AreEqual(SellIn - day, conjuredItem.SellIn);
            }
        }


        [TestCase(1, 46)]
        [TestCase(2, 47)]
        [TestCase(3, 48)]
        [TestCase(4, 49)]
        [TestCase(5, 50)]
        [TestCase(6, 50)]
        [TestCase(7, 50)]
        public void IncrementQuality(int quantity, int expectedQuality)
        {
            var item = new DummyItem("Item1", 5, 45);

            item.Increment(quantity);

            Assert.AreEqual(expectedQuality, item.Quality);
        }
    }

    public class DummyItem : Item
    {
        public DummyItem(string name, int sellIn, int quality)
            : base(name, sellIn, quality)
        {
        }

        public void Increment(int quantity)
        {
            IncrementQuality(quantity);
        }
    }
}