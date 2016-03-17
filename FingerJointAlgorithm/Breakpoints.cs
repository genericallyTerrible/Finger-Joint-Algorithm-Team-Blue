using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerJointAlgorithm
{
    //Assumes correct input
    public class Breakpoints
    {
        public double this[int index]
        {
            get
            {
                return _breakpoints[index];
            }
        }
        public int Count
        {
            get
            {
                return _breakpoints.Count;
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
        public List<double> IdealBreakpoints
        {
            get
            {
                return _breakpoints;
            }
        }
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


        private List<double> _breakpoints;
        private double _halfClearance;
        private double _boardWidth;
        private double _endPinWidth;
        private double _interiorBoardWidth;
        private double _interiorPinWidth;
        private int _numInteriorAreas;

        //Case 1
        public Breakpoints(double BoardWidth, double Clearance, double EndPinWidth, int NumInteriorPins)
        {
            _halfClearance = Clearance / 2;
            _boardWidth = BoardWidth;
            _endPinWidth = EndPinWidth;
            _numInteriorAreas = (NumInteriorPins * 2) + 1;
            //Find width of interior pins
            _interiorBoardWidth = _boardWidth - ((2 * _endPinWidth) + Clearance);
            _interiorPinWidth = _interiorBoardWidth / _numInteriorAreas;
            generateBreakpoints();
        }

        //Case 2
        public Breakpoints(double BoardWidth, double Clearance, double EndPinWidth, double InteriorPinWidth)
        {
            _halfClearance = Clearance / 2;
            _boardWidth = BoardWidth;
            _endPinWidth = EndPinWidth;
            _interiorPinWidth = InteriorPinWidth;
            //Find number of interior pins
            _interiorBoardWidth = _boardWidth - ((2 * _endPinWidth) + Clearance);
            _numInteriorAreas = (int)Math.Round(_interiorBoardWidth / _interiorPinWidth);
            //Recalculate Interior pin size to adjust for clearance
            _interiorPinWidth = _interiorBoardWidth / _numInteriorAreas;
            generateBreakpoints();
        }

        //Case 3
        public Breakpoints(double BoardWidth, double Clearance, double InteriorPinWidth)
        {
            _halfClearance = Clearance / 2;
            _boardWidth = BoardWidth;
            _interiorPinWidth = InteriorPinWidth;
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
            _interiorPinWidth -= Clearance / _numInteriorAreas; //Adjustment from ideal
            generateBreakpoints();
        }

        private void generateBreakpoints(){
            _breakpoints = new List<double>();
            double offset = _endPinWidth + (_halfClearance);
            _breakpoints.Add(0);
            _breakpoints.Add(offset);   
            for (int i = 0; i < _numInteriorAreas; i++)
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
                    newBreakPoints[i] = _breakpoints[i] + (_halfClearance);
                }
                else
                {
                    // is odd
                    newBreakPoints[i] = _breakpoints[i] - (_halfClearance);
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
                    newBreakPoints[i] = _breakpoints[i] - (_halfClearance);
                }
                else
                {
                    // is odd
                    newBreakPoints[i] = _breakpoints[i] + (_halfClearance);
                }
            }
            newBreakPoints[numItems - 1] = _breakpoints[numItems - 1]; //Last spot fixed - end of board and
            return newBreakPoints;
        }

    }
    
}
