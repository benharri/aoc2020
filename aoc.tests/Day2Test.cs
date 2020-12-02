using aoc2020;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace aoc.tests
{
    [TestClass]
    public class Day2Test
    {
        private Day2 _day2;

        [TestInitialize]
        public void Initialize()
        {
            _day2 = new Day2();
        }

        [TestMethod]
        public void TestPart1()
        {
            Assert.AreEqual("556", _day2.Part1());
        }

        [TestMethod]
        public void TestPart2()
        {
            Assert.AreEqual("605", _day2.Part2());
        }
    }
}