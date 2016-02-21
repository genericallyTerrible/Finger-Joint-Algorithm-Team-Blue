using FingerJointAlgorithm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FingerJointAlgorithmTesting
{
    [TestClass]
    public class BreakpointTesting
    {
        FindingBreakpoints test;

        [TestMethod]
        public void TestCase1()
        {
            //Case1(BoardWidth, EndPinWidth, NumInteriorPins)

            test = new Case1(4, 0.5, 1);

            Assert.AreEqual(0.50, test[0]);
            Assert.AreEqual(1.50, test[1]);
            Assert.AreEqual(2.50, test[2]);
            Assert.AreEqual(3.50, test[3]);
        }

        [TestMethod]
        public void TestCase2()
        {
            //Case2(BoardWidth, EndPinWidth, InteriorPinWidth)

            test = new Case2(4, 0.5, 1);

            Assert.AreEqual(0.50, test[0]);
            Assert.AreEqual(1.50, test[1]);
            Assert.AreEqual(2.50, test[2]);
            Assert.AreEqual(3.50, test[3]);
        }

        [TestMethod]
        public void TestCase3()
        {
            //Case3(BoardWidth, InteriorPinWidth)

            test = new Case3(4, 1);

            Assert.AreEqual(0.50, test[0]);
            Assert.AreEqual(1.50, test[1]);
            Assert.AreEqual(2.50, test[2]);
            Assert.AreEqual(3.50, test[3]);
        }
    }
}
