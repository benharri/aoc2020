using aoc2020;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace aoc.tests
{
    [TestClass]
    public class Day8Test
    {
        private Day8 _day;

        [TestInitialize]
        public void Initialize()
        {
            _day = new Day8();
        }

        [TestMethod]
        public void TestPart1()
        {
            Assert.AreEqual("1654", _day.Part1());
        }

        [TestMethod]
        public void TestPart2()
        {
            Assert.AreEqual("833", _day.Part2());
        }
    }
}