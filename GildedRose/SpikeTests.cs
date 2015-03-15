using System;
using System.IO;
using NUnit.Framework;

namespace GildedRose
{
    [TestFixture]
    public class SpikeTests
    {
       [Test]
        public void Test()
        {
            var goldenMaster = ReadGoldenMaster();

            var actualOutput = ReadActualOutput();

            Assert.AreEqual(goldenMaster, actualOutput);
        }

        private static string ReadActualOutput()
        {
            var sb = new StringWriter();
            Console.SetOut(sb);
            Program.Main(new[] {""});
            return sb.ToString();
        }

        private static String ReadGoldenMaster()
        {
            var file = new FileInfo(@"..\..\golden-master.txt");
            using (var sr = file.OpenText())
            {
                return sr.ReadToEnd();
            }
        }
    }
}