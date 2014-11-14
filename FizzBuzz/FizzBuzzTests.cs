using System.Linq;
using System.Text;
using NUnit.Framework;

namespace FizzBuzzKata
{
    [TestFixture]
    public class FizzBuzzTests
    {
        private FizzBuzz _fb;

        [SetUp]
        public void SetUp()
        {
            _fb = new FizzBuzz();
        }

        [TestCase(3)]
        [TestCase(6)]
        [TestCase(9)]
        [TestCase(12)]
        public void IsDivisibleByThree(int i)
        {
            Assert.That(_fb.IsDivisibleByThree(i), Is.True);
        }

        [TestCase(5)]
        [TestCase(10)]
        [TestCase(20)]
        public void IsDivisibleByFive(int i)
        {
            Assert.That(_fb.IsDivisibleByFive(i), Is.True);
        }

        [TestCase(3)]
        [TestCase(6)]
        [TestCase(9)]
        [TestCase(12)]
        public void PrintFizzForNumberDivisibleByThree(int i)
        {
            Assert.That(_fb.Print(i), Is.EqualTo("Fizz"));
        }

        [TestCase(5)]
        [TestCase(10)]
        [TestCase(20)]
        public void PrintBuzzIfDivisibleByFive(int i)
        {
            Assert.That(_fb.Print(i), Is.EqualTo("Buzz"));
        }

        [TestCase(15)]
        [TestCase(30)]
        [TestCase(90)]
        public void PrintFizzBuzzIfDivisibleByThreeAndFive(int i)
        {
            Assert.That(_fb.Print(i), Is.EqualTo("FizzBuzz"));
        }

        [TestCase(4)]
        [TestCase(7)]
        [TestCase(11)]
        public void PrintNumberIfNeitherDivisibleByThreeNorByFive(int i)
        {
            Assert.That(_fb.Print(i), Is.EqualTo(i.ToString()));
        }

        [Test]
        public void PrintAllNumbersUpTo15()
        {
            Assert.That(_fb.PrintAllUpTo(15), Is.EqualTo("1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 FizzBuzz"));
        }
    }

    public class FizzBuzz
    {
        private const string Fizz = "Fizz";
        private const string Buzz = "Buzz";
        private const string FizzBuzzC = "FizzBuzz";

        public bool IsDivisibleByThree(int i)
        {
            return i % 3 == 0;
        }

        public bool IsDivisibleByFive(int i)
        {
            return i % 5 == 0;
        }

        public string Print(int i)
        {
            if (IsDivisibleByFive(i) && IsDivisibleByThree(i)) return FizzBuzzC;
            if (IsDivisibleByThree(i)) return Fizz;
            if (IsDivisibleByFive(i)) return Buzz;
            
            return i.ToString();
        }

        public string PrintAllUpTo(int upperLimit)
        {
            var sb = new StringBuilder();
            Enumerable.Range(1, upperLimit).ToList().ForEach(i => sb.AppendFormat("{0} ",Print(i)));
            return sb.ToString().TrimEnd();
        }
    }
}
