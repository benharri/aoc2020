using aoc2020;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace aoc.tests
{
    [TestClass]
    public class Day4Test
    {
        private Day4 _day;

        [TestInitialize]
        public void Initialize()
        {
            _day = new Day4();
        }

        [TestMethod]
        public void TestPart1()
        {
            Assert.AreEqual("247", _day.Part1());
        }

        [TestMethod]
        public void TestPart2()
        {
            Assert.AreEqual("145", _day.Part2());
        }
    }
}