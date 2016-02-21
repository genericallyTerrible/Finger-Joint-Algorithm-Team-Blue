using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SlackerTest
{
    [TestClass]
    public class SlackerTest
    {
        [TestMethod]
        public void testGetBreakPointsWithSlack1()
        {
            Double[] breakPoints = new Double[] { 0.25, 1.25, 2.25, 3.25, 3.5 };
            Double slack = 1 / 64;
            Double[] newBreakPoints1 = Slacker.Slacker.GetBreakPointsWithSlack1(breakPoints, slack);
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
            Double[] breakPoints = new Double[] { 0.25, 1.25, 2.25, 3.25, 3.5 };
            Double slack = 1 / 64;
            Double[] newBreakPoints2 = Slacker.Slacker.GetBreakPointsWithSlack2(breakPoints, slack);
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
