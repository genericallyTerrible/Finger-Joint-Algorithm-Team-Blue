using FingerJointAlgorithm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FingerJointAlgorithmTesting
{
    [TestClass]
    public class BreakpointTesting
    {
        FindingBreakpoints test;

        [TestMethod]
        public void BreakpointTestCase1()
        {
            //Case1(BoardWidth, EndPinWidth, NumInteriorPins)

            test = new Case1(4, 0.5, 1);

            Assert.AreEqual(0.50, test.breakpoints[0]);
            Assert.AreEqual(1.50, test.breakpoints[1]);
            Assert.AreEqual(2.50, test.breakpoints[2]);
            Assert.AreEqual(3.50, test.breakpoints[3]);
        }

        [TestMethod]
        public void BreakpointTestCase2()
        {
            //Case2(BoardWidth, EndPinWidth, InteriorPinWidth)

            test = new Case2(4, 0.5, 1);

            Assert.AreEqual(0.50, test.breakpoints[0]);
            Assert.AreEqual(1.50, test.breakpoints[1]);
            Assert.AreEqual(2.50, test.breakpoints[2]);
            Assert.AreEqual(3.50, test.breakpoints[3]);
        }

        [TestMethod]
        public void BreakpointTestCase3()
        {
            //Case3(BoardWidth, InteriorPinWidth)

            test = new Case3(4, 1);

            Assert.AreEqual(0.50, test.breakpoints[0]);
            Assert.AreEqual(1.50, test.breakpoints[1]);
            Assert.AreEqual(2.50, test.breakpoints[2]);
            Assert.AreEqual(3.50, test.breakpoints[3]);
        }
    }
}
