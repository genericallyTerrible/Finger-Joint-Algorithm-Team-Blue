using FingerJointAlgorithm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FingerJointAlgorithmTesting
{
    [TestClass]
    public class BreakpointTesting
    {
        Breakpoints testPoints;

        [TestMethod]
        public void BreakpointTestCase1()
        {
            //Case1(BoardWidth, Clearance, EndPinWidth, NumInteriorPins)
            #region Inputs
            double BoardWidth = 7;
            double Clearance = ((double)1 / 64);
            double EndPinWidth = 0.5;
            int NumInteriorPins = 2;
            #endregion

            #region Assignment
            testPoints = new Breakpoints(BoardWidth, Clearance, EndPinWidth, NumInteriorPins);
            #endregion

            #region Testing
            Assert.AreEqual(0, testPoints[0]);
            double testVal = (EndPinWidth + (0.5 *  Clearance));
            Assert.AreEqual(testVal, testPoints[1]);
            for (int i = 1; i <= testPoints.NumInteriorAreas; i++)
            {
                testVal += testPoints.InteriorPinWidth;
                Assert.AreEqual(testVal, testPoints[i + 1]);
            }
            Assert.AreEqual(BoardWidth, testPoints[testPoints.NumInteriorAreas + 2]);
            #endregion
        }

        [TestMethod]
        public void BreakpointTestCase2()
        {
            //Case2(BoardWidth, Clearance, EndPinWidth, InteriorPinWidth)
            #region Inputs
            double BoardWidth = 4;
            double Clearance = ((double)1 / 64);
            double EndPinWidth = 0.5;
            double InteriorPinWidth = 1;
            #endregion

            #region Assignment
            testPoints = new Breakpoints(BoardWidth, Clearance, EndPinWidth, InteriorPinWidth);
            #endregion

            #region Testing
            Assert.AreEqual(0, testPoints[0]);
            double testVal = (EndPinWidth + (0.5 * Clearance));
            Assert.AreEqual(testVal, testPoints[1]);
            for (int i = 1; i <= testPoints.NumInteriorAreas; i++)
            {
                testVal += testPoints.InteriorPinWidth;
                Assert.AreEqual(testVal, testPoints[i + 1]);
            }
            Assert.AreEqual(BoardWidth, testPoints[testPoints.NumInteriorAreas + 2]);
            #endregion
        }

        [TestMethod]
        public void BreakpointTestCase3()
        {
            //Case3(BoardWidth,  Clearance, InteriorPinWidth)
            #region Inputs
            double BoardWidth = 4;
            double Clearance = ((double)1 / 64);
            double InteriorPinWidth = 1;
            #endregion

            #region Assignment
            testPoints = new Breakpoints(BoardWidth, Clearance, InteriorPinWidth);
            #endregion

            #region Testing
            Assert.AreEqual(0, testPoints[0]);
            double testVal = (testPoints.EndPinWidth + (0.5 * Clearance));
            Assert.AreEqual(testVal, testPoints[1]);
            for (int i = 1; i <= testPoints.NumInteriorAreas; i++)
            {
                testVal += testPoints.InteriorPinWidth;
                Assert.AreEqual(testVal, testPoints[i + 1]);
            }
            Assert.AreEqual(BoardWidth, testPoints[testPoints.NumInteriorAreas + 2]);
            #endregion
        }

        [TestMethod]
        public void BreakpointTestClearance()
        {
            #region Inputs
            double BoardWidth = 7;
            double Clearance = ((double)1 / 64);
            double EndPinWidth = 0.5;
            int NumInteriorPins = 1;
            #endregion

            #region Assignment
            testPoints = new Breakpoints(BoardWidth, Clearance, EndPinWidth, NumInteriorPins);
            double[] pinBoard = testPoints.generatePinBoard();
            double[] socketBoard = testPoints.generateSocketBoard();
            int numItems = testPoints.Count;
            double difference = 0;
            #endregion

            #region Testing
            Assert.AreEqual(pinBoard[0], socketBoard[0]);
            for(int i = 2; i < numItems - 2; i++)
            {
                difference = Math.Abs(pinBoard[i] - socketBoard[i]);
                Assert.AreEqual(Clearance, difference);
            }

            Assert.AreEqual(pinBoard[numItems - 1], socketBoard[numItems - 1]);
            #endregion
        }
    }
}
