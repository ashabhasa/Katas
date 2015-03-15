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

                var expectedQuality = Quality - 2*day;
                Assert.AreEqual(expectedQuality > 0 ? expectedQuality : 0, conjuredItem.Quality);
                Assert.AreEqual(SellIn - day, conjuredItem.SellIn);
            }
        }
    }
}