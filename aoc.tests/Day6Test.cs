using aoc2020;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace aoc.tests
{
    [TestClass]
    public class Day6Test
    {
        private Day6 _day;

        [TestInitialize]
        public void Initialize()
        {
            _day = new Day6();
        }

        [TestMethod]
        public void TestPart1()
        {
            Assert.AreEqual("6273", _day.Part1());
        }

        [TestMethod]
        public void TestPart2()
        {
            Assert.AreEqual("", _day.Part2());
        }
    }
}