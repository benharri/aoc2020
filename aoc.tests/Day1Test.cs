using aoc2020;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace aoc.tests
{
    [TestClass]
    public class Day1Test
    {
        private Day1 _day1;

        [TestInitialize]
        public void Initialize()
        {
            _day1 = new Day1();
        }

        [TestMethod]
        public void TestPart1()
        {
            Assert.AreEqual("751776", _day1.Part1());
        }

        [TestMethod]
        public void TestPart2()
        {
            Assert.AreEqual("42275090", _day1.Part2());
        }
    }
}