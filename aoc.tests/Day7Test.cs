using aoc2020;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace aoc.tests
{
    [TestClass]
    public class Day7Test
    {
        private Day7 _day;

        [TestInitialize]
        public void Initialize()
        {
            _day = new Day7();
        }

        [TestMethod]
        public void TestPart1()
        {
            Assert.AreEqual("169", _day.Part1());
        }

        [TestMethod]
        public void TestPart2()
        {
            Assert.AreEqual("82372", _day.Part2());
        }
    }
}