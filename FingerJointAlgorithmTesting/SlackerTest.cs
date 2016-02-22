using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FingerJointAlgorithm;

namespace SlackerTest
{
    [TestClass]
    public class SlackerTest
    {
        Slacker slacker = new Slacker();

        [TestMethod]
        public void testGetBreakPointsWithSlack1()
        {
            double[] breakPoints = new double[] { 0.25, 1.25, 2.25, 3.25, 3.5 };
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
        [TestMethod]
        public void testGetBreakPointsWithSlack2()
        {
            double[] breakPoints = new double[] { 0.25, 1.25, 2.25, 3.25, 3.5 };
            double slack = 1 / 64;
            double[] newBreakPoints2 = slacker.GetBreakPointsWithSlack2(breakPoints, slack);
            for (int i = 0; i < newBreakPoints2.Length; i++)
            {
                if (i % 2 == 0)
                {
                    // is even
                    Assert.AreEqual(breakPoints[i] - slack, newBreakPoints2[i]);
                }
                else
                {
                    // is odd
                    Assert.AreEqual(breakPoints[i] + slack, newBreakPoints2[i]);
                }
            }
        }
    }
}
