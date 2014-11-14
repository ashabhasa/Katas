using NUnit.Framework;

namespace TeapartyKata
{
    [TestFixture]
    public class TeapartyKataTests
    {
        private TeaPartyKata _teaparty;

        [SetUp]
        public void SetUp()
        {
            _teaparty = new TeaPartyKata();
        }

        [Test]
        public void GreetAWoman()
        {
            Assert.That(_teaparty.Welcome("Austen", true, false), Is.EqualTo("Hello Ms. Austen"));
        }

        [Test]
        public void GreetANonKnightedMan()
        {
            Assert.That(_teaparty.Welcome("Orwell", false, false), Is.EqualTo("Hello Mr. Orwell"));
        }

        [Test]
        public void GreetAKnight()
        {
            Assert.That(_teaparty.Welcome("Newton", false, true), Is.EqualTo("Hello Sir Newton"));
        }
    }
}