using System.Linq;
using NUnit.Framework;

namespace CheckoutKata
{
    [TestFixture]
    public class PriceTests
    {
        [TestCase("A", 50)]
        [TestCase("B", 30)]
        [TestCase("C", 20)]
        [TestCase("D", 15)]
        public void ScannItem(string sku, int expectedTotal)
        {
            var scanner = new Scanner();
            scanner.Scann(sku);
            Assert.AreEqual(expectedTotal, scanner.GetTotal());
        }

        [TestCase(new[] { "A", "C", "B", "D" }, 115)]
        [TestCase(new[] { "A", "C" }, 70)]
        [TestCase(new[] { "A", "B", "D" }, 95)]
        [TestCase(new[] { "D", "C", "B", "A" }, 115)]
        public void ScannMultipleItem(string[] skus, int expectedTotal)
        {
            var scanner = new Scanner();
            skus.ToList().ForEach(scanner.Scann);
            Assert.AreEqual(expectedTotal, scanner.GetTotal());
        }


        [TestCase(new[] { "A", "A", "B", "A" }, 160)]
        [TestCase(new[] { "A", "A", "A" }, 130)]
        [TestCase(new[] { "A", "A", "A", "A" }, 180)]
        [TestCase(new[] { "B", "B" }, 45)]
        [TestCase(new[] { "B", "B", "B" }, 75)]
        [TestCase(new[] { "A", "B", "A", "B", "A" }, 175)]
        [TestCase(new[] { "B", "B", "B", "B" }, 90)]
        [TestCase(new[] { "A", "A", "A", "A", "A", "A" }, 260)]
        [TestCase(new[] { "A", "A", "A", "C", "A", "D", "A", "A", "B", "B" }, 340)]
        public void ApplySpecialPrice(string[] skus, int expectedTotal)
        {
            var scanner = new Scanner();
            skus.ToList().ForEach(scanner.Scann);
            Assert.AreEqual(expectedTotal, scanner.GetTotal());
        }
    }


    public class Promotion
    {
        public string Sku { get; set; }
        public int SpecialCount { get; set; }
        public int SpecialPrice { get; set; }
    }
}