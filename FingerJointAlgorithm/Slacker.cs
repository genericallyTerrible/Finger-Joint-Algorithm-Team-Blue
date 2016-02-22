using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerJointAlgorithm
{
    public class Slacker
    {
        public double[] GetBreakPointsWithSlack1(double[] breakPoints, double slack)
        {
            double[] newBreakPoints = new double[breakPoints.Length];
            for (int i = 0; i < breakPoints.Length; i++)
            {
                if (i % 2 == 0)
                {
                    // is even
                    newBreakPoints[i] = breakPoints[i] - slack;
                }
                else
                {
                    // is odd
                    newBreakPoints[i] = breakPoints[i] + slack;
                }
            }
            return newBreakPoints;
        }
        public double[] GetBreakPointsWithSlack2(double[] breakPoints, double slack)
        {
            double[] newBreakPoints = new double[breakPoints.Length];
            for (int i = 0; i < breakPoints.Length; i++)
            {
                if (i % 2 == 0)
                {
                    // is even
                    newBreakPoints[i] = breakPoints[i] + slack;
                }
                else
                {
                    // is odd
                    newBreakPoints[i] = breakPoints[i] - slack;
                }
            }
            return newBreakPoints;
        }
    }
}
