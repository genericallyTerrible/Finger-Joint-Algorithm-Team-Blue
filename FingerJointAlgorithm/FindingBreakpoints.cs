using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerJointAlgorithm
{
    //Assumes correct input
    public abstract class FindingBreakpoints
    {

        public double[] breakpoints
        {
            get
            {
                return _breakpoints.ToArray();
            }
        }
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine("Count: " + _breakpoints.Count);
            output.Append("[");
            for (int i = 0; i < _breakpoints.Count - 1; i++)
            {
                output.Append(_breakpoints[i] + ", ");
            }
            output.Append(_breakpoints[_breakpoints.Count - 1] + "]");
            return output.ToString();
        }
        #region Accessors for Testing
        public double Clearance
        {
            get
            {
                return _halfClearance;
            }
        }
        public double BoardWidth
        {
            get
            {
                return _boardWidth;
            }
        }
        public double EndPinWidth
        {
            get
            {
                return _endPinWidth;
            }
        }
        public double InteriorBoardWidth
        {
            get
            {
                return _interiorBoardWidth;
            }
        }
        public double InteriorPinWidth
        {
            get
            {
                return _interiorPinWidth;
            }
        }
        public int NumInteriorAreas
        {
            get
            {
                return _numInteriorAreas;
            }
        }
        #endregion


        protected List<double> _breakpoints = null;
        protected double _halfClearance;
        protected double _boardWidth;
        protected double _endPinWidth;
        protected double _interiorBoardWidth;
        protected double _interiorPinWidth;
        protected int _numInteriorAreas;

        protected void generateBreakpoints(){
            _breakpoints = new List<double>();
            int _numBreakPoints = (_numInteriorAreas / 2) + 1;
            double offset = _endPinWidth + (0.5 * _halfClearance);
            _breakpoints.Add(0);
            _breakpoints.Add(offset);   
            for (int i = 0; i <= _numBreakPoints; i++)
            {
                offset += _interiorPinWidth;
                _breakpoints.Add(offset);
            }
            _breakpoints.Add(_boardWidth);
        }

        public double[] generatePinBoard()
        {
            generateBreakpoints();
            int numItems = _breakpoints.Count;
            double[] newBreakPoints = new double[numItems];
            newBreakPoints[0] = _breakpoints[0]; //First spot fixed - begining of board
            for (int i = 1; i < numItems - 1; i++)
            {
                if (i % 2 == 0)
                {
                    // is even
                    newBreakPoints[i] = _breakpoints[i] + (_halfClearance / 2);
                }
                else
                {
                    // is odd
                    newBreakPoints[i] = _breakpoints[i] - (_halfClearance / 2);
                }
            }
            newBreakPoints[numItems - 1] = _breakpoints[numItems - 1]; //last spot fixed - end of board
            return newBreakPoints;
        }

        public double[] generateSocketBoard()
        {
            generateBreakpoints();
            int numItems = _breakpoints.Count;
            double[] newBreakPoints = new double[numItems];
            newBreakPoints[0] = _breakpoints[0]; //First spot fixed - begining of board
            for (int i = 1; i < numItems - 1; i++)
            {
                if (i % 2 == 0)
                {
                    // is even
                    newBreakPoints[i] = _breakpoints[i] - (_halfClearance / 2);
                }
                else
                {
                    // is odd
                    newBreakPoints[i] = _breakpoints[i] + (_halfClearance / 2);
                }
            }
            newBreakPoints[numItems - 1] = _breakpoints[numItems - 1]; //Last spot fixed - end of board and
            return newBreakPoints;
        }

    }

    public class Case1 : FindingBreakpoints
    {
        public Case1(double boardWidth, double clearance, double endPinWidth, int numInteriorPins)
        {
            _halfClearance = clearance / 2;
            _boardWidth = boardWidth;
            _endPinWidth = endPinWidth;
            _numInteriorAreas = (numInteriorPins * 2) + 1;
            //Find width of interior pins
            _interiorBoardWidth = _boardWidth - ((2 * _endPinWidth) + _halfClearance);
            _interiorPinWidth = _interiorBoardWidth / _numInteriorAreas;
            generateBreakpoints();
        }
    }

    public class Case2 : FindingBreakpoints
    {
        //Assumes interiorBoardWidth is evenly divisible
        public Case2(double boardWidth, double clearance, double endPinWidth, double interiorPinWidth)
        {
            _halfClearance = clearance / 2;
            _boardWidth = boardWidth;
            _endPinWidth = endPinWidth;
            _interiorPinWidth = interiorPinWidth;
            //Find number of interior pins
            _interiorBoardWidth = _boardWidth - ((2 * _endPinWidth) + _halfClearance);
            _numInteriorAreas = (int)Math.Round(_interiorBoardWidth / _interiorPinWidth);
            //Recalculate Interior pin size to adjust for clearance
            _interiorPinWidth = _interiorBoardWidth / _numInteriorAreas;
            generateBreakpoints();
        }
    }

    public class Case3 : FindingBreakpoints
    {
        //Case 3: User provides only Width of Interior Pins
        public Case3(double boardWidth, double clearance, double interiorPinWidth)
        {
            _halfClearance = clearance / 2;
            _boardWidth = boardWidth;
            _interiorPinWidth = interiorPinWidth;
            int pinsAndSockets = (int)(_boardWidth / _interiorPinWidth);
            _interiorBoardWidth = pinsAndSockets * _interiorPinWidth;
            if (pinsAndSockets % 2 != 0 || _interiorBoardWidth == _boardWidth)
            {
                //Number of pins and sockets are odd or whole board is taken up from interior pins/sockets
                pinsAndSockets--;
                _interiorBoardWidth = pinsAndSockets * _interiorPinWidth;
            }
            _numInteriorAreas = (int)(_interiorBoardWidth / _interiorPinWidth);
            _endPinWidth = (_boardWidth - _interiorBoardWidth) / 2;
            _interiorPinWidth -= _halfClearance / _numInteriorAreas; //Adjustment from ideal
            generateBreakpoints();
        }
    }
}
