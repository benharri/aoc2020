using aoc2020;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace aoc.tests
{
    [TestClass]
    public class Day1Test
    {
        private Day1 _day;

        [TestInitialize]
        public void Initialize()
        {
            _day = new Day1();
        }

        [TestMethod]
        public void TestPart1()
        {
            Assert.AreEqual("751776", _day.Part1());
        }

        [TestMethod]
        public void TestPart2()
        {
            Assert.AreEqual("42275090", _day.Part2());
        }
    }
}