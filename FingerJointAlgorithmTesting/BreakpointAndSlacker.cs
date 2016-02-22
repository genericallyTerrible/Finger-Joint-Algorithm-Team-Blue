using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FingerJointAlgorithm;

namespace FingerJointAlgorithmTesting
{
    /// <summary>
    /// Summary description for BreakpointAndSlacker
    /// </summary>
    [TestClass]
    public class BreakpointAndSlacker
    {
        FindingBreakpoints test;
        Slacker slacker = new Slacker();

        [TestMethod]
        public void TestBreakpointAndSlacker()
        {
            test = new Case1(4, 0.5, 1);

            Assert.AreEqual(0.50, test.breakpoints[0]);
            Assert.AreEqual(1.50, test.breakpoints[1]);
            Assert.AreEqual(2.50, test.breakpoints[2]);
            Assert.AreEqual(3.50, test.breakpoints[3]);

            double[] breakPoints = test.breakpoints;
            double slack = 1 / 64;
            double[] newBreakPoints1 = slacker.GetBreakPointsWithSlack1(breakPoints, slack);
            for (int i = 0; i < newBreakPoints1.Length; i++)
            {
                if (i % 2 == 0)
                {
                    // is even
                    Assert.AreEqual(breakPoints[i] + slack, newBreakPoints1[i]);
                }
                else
                {
                    // is odd
                    Assert.AreEqual(breakPoints[i] - slack, newBreakPoints1[i]);
                }
            }
        }
    }
}
