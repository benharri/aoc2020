using aoc2020;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace aoc.tests
{
    [TestClass]
    public class Day3Test
    {
        private Day3 _day3;

        [TestInitialize]
        public void Initialize()
        {
            _day3 = new Day3();
        }

        [TestMethod]
        public void TestPart1()
        {
            Assert.AreEqual("189", _day3.Part1());
        }

        [TestMethod]
        public void TestPart2()
        {
            Assert.AreEqual("1718180100", _day3.Part2());
        }
    }
}
