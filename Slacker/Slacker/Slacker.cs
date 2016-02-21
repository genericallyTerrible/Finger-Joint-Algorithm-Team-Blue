using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slacker
{
    public class Slacker
    {
        public static Double[] GetBreakPointsWithSlack1(Double[] breakPoints, Double slack)
        {
            Double[] newBreakPoints = new Double[breakPoints.Length];
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
        public static Double[] GetBreakPointsWithSlack2(Double[] breakPoints, Double slack)
        {
            Double[] newBreakPoints = new Double[breakPoints.Length];
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
