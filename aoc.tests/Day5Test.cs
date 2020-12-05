using aoc2020;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace aoc.tests
{
    [TestClass]
    public class Day5Test
    {
        private Day5 _day;

        [TestInitialize]
        public void Initialize()
        {
            _day = new Day5();
        }

        [TestMethod]
        public void TestPart1()
        {
            Assert.AreEqual("878", _day.Part1());
        }

        [TestMethod]
        public void TestPart2()
        {
            Assert.AreEqual("504", _day.Part2());
        }
    }
}