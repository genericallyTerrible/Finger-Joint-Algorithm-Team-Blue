using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerJointAlgorithm
{
    public class CutArea
    {
        public double xStart
        {
            get
            {
                return _xStart;
            }
        }
        public double xStop
        {
            get
            {
                return _xStop;
            }
        }
        public double yStart
        {
            get
            {
                return _yStart;
            }
        }
        public double yStop
        {
            get
            {
                return _yStop;
            }
        }
        public double CutDepth
        {
            get
            {
                return _cutDepth;
            }
        }

        private double _xStart;
        private double _xStop;
        private double _yStart;
        private double _yStop;
        private double _cutDepth;

        public CutArea(double xStart, double xStop, double yStart, double yStop, double CutDepth)
        {
            _xStart = xStart;
            _xStop = xStop;
            _yStart = yStart;
            _yStop = yStop;
            _cutDepth = CutDepth;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine("X-Start: " + _xStart);
            output.AppendLine("X-Stop: " + _xStop);
            output.AppendLine("Y-Start: " + _yStart);
            output.AppendLine("Y-Stop: " + _yStop);
            output.AppendLine("Cut Depth: " + _cutDepth);
            return output.ToString();
        }
    }
}
