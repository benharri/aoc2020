using aoc2020;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace aoc.tests
{
    [TestClass]
    public class Day4Test
    {
        private Day4 _day4;

        [TestInitialize]
        public void Initialize()
        {
            _day4 = new Day4();
        }

        [TestMethod]
        public void TestPart1()
        {
            Assert.AreEqual("", _day4.Part1());
        }

        [TestMethod]
        public void TestPart2()
        {
            Assert.AreEqual("", _day4.Part2());
        }
    }
}