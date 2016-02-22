using FingerJointAlgorithm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FingerJointAlgorithmTesting
{
    [TestClass]
    public class BreakpointTesting
    {
        FindingBreakpoints test;

        [TestMethod]
        public void BreakpointTestCase1()
        {
            //Case1(BoardWidth, Clearance, EndPinWidth, NumInteriorPins)

            double BoardWidth = 4;
            double Clearance = ((double)1 / 64);
            double EndPinWidth = 0.5;
            int NumInteriorPins = 1;
            test = new Case1(BoardWidth, Clearance, EndPinWidth, NumInteriorPins);
            
            Assert.AreEqual(0, test.breakpoints[0]);
            double testVal = (EndPinWidth + (0.25 *  Clearance));
            Assert.AreEqual(testVal, test.breakpoints[1]);
            for (int i = 1; i <= test.NumInteriorAreas; i++)
            {
                testVal += test.InteriorPinWidth;
                Assert.AreEqual(testVal, test.breakpoints[i + 1]);
            }
            Assert.AreEqual(4, test.breakpoints[5]);
        }

        [TestMethod]
        public void BreakpointTestCase2()
        {
            //Case2(BoardWidth, Clearance, EndPinWidth, InteriorPinWidth)
            double BoardWidth = 4;
            double Clearance = ((double)1 / 64);
            double EndPinWidth = 0.5;
            double InteriorPinWidth = 1;
            test = new Case2(BoardWidth, Clearance, EndPinWidth, InteriorPinWidth);

            Assert.AreEqual(0, test.breakpoints[0]);
            double testVal = (EndPinWidth + (0.25 * Clearance));
            Assert.AreEqual(testVal, test.breakpoints[1]);
            for (int i = 1; i <= test.NumInteriorAreas; i++)
            {
                testVal += test.InteriorPinWidth;
                Assert.AreEqual(testVal, test.breakpoints[i + 1]);
            }
            Assert.AreEqual(4, test.breakpoints[5]);

        }

        [TestMethod]
        public void BreakpointTestCase3()
        {
            //Case3(BoardWidth,  Clearance, InteriorPinWidth)
            double BoardWidth = 4;
            double Clearance = ((double)1 / 64);
            double InteriorPinWidth = 1;
            test = new Case3(BoardWidth, Clearance, InteriorPinWidth);

            Assert.AreEqual(0, test.breakpoints[0]);
            double testVal = (test.EndPinWidth + (0.25 * Clearance));
            Assert.AreEqual(testVal, test.breakpoints[1]);
            for (int i = 1; i <= test.NumInteriorAreas; i++)
            {
                testVal += test.InteriorPinWidth;
                Assert.AreEqual(testVal, test.breakpoints[i + 1]);
            }
            Assert.AreEqual(4, test.breakpoints[5]);

        }

        [TestMethod]
        public void BreakpointTestClearance()
        {
            double BoardWidth = 4;
            double Clearance = ((double)1 / 64);
            double EndPinWidth = 0.5;
            int NumInteriorPins = 1;
            test = new Case1(BoardWidth, Clearance, EndPinWidth, NumInteriorPins);
            double[] pinBoard = test.generatePinBoard();
            double[] socketBoard = test.generateSocketBoard();

            int numItems = test.breakpoints.Length;

            Assert.AreEqual(pinBoard[0], socketBoard[0]);

            double difference = 0;
            for(int i = 2; i < numItems - 2; i++)
            {
                difference = Math.Abs(pinBoard[i] - socketBoard[i]);
                Assert.AreEqual(Clearance / 2, difference);
            }

            Assert.AreEqual(pinBoard[numItems - 1], socketBoard[numItems - 1]);
        }
    }
}
