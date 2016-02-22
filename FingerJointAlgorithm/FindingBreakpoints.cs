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

        protected List<double> _breakpoints = new List<double>();
        protected double _boardWidth;
        protected double _endPinWidth;
        protected double _interiorBoardWidth;
        protected double _interiorPinWidth;
        protected int _numInteriorAreas;

        protected void generateBreakpoints(){
            int _numBreakPoints = (_numInteriorAreas / 2) + 1;
            _breakpoints.Add(_endPinWidth);   
            for (int i = 0; i <= _numBreakPoints; i++)
            {
                _breakpoints.Add(_endPinWidth + ((i + 1) * _interiorPinWidth));
            }
        }
    }

    public class Case1 : FindingBreakpoints
    {
        public Case1(double BoardWidth, double EndPinWidth, int NumInteriorPins)
        {
            _boardWidth = BoardWidth;
            _endPinWidth = EndPinWidth;
            _numInteriorAreas = (NumInteriorPins * 2) + 1;
            //Find width of interior pins
            _interiorBoardWidth = _boardWidth - (2 * _endPinWidth);
            _interiorPinWidth = _interiorBoardWidth / _numInteriorAreas;
            generateBreakpoints();
        }
    }

    public class Case2 : FindingBreakpoints
    {
        //Assumes interiorBoardWidth is evenly divisible
        public Case2(double BoardWidth, double EndPinWidth, double InteriorPinWidth)
        {
            _boardWidth = BoardWidth;
            _endPinWidth = EndPinWidth;
            _interiorPinWidth = InteriorPinWidth;
            //Find number of interior pins
            _interiorBoardWidth = _boardWidth - (2 * _endPinWidth);
            _numInteriorAreas = (int)(_interiorBoardWidth / _interiorPinWidth);
            generateBreakpoints();
        }
    }

    public class Case3 : FindingBreakpoints
    {
        //Case 3: User provides only Width of Interior Pins
        public Case3(double BoardWidth, double InteriorPinWidth)
        {
            _boardWidth = BoardWidth;
            _interiorPinWidth = InteriorPinWidth;
            int pinsAndSockets = (int)(_boardWidth / _interiorPinWidth);
            _interiorBoardWidth = (double)pinsAndSockets * _interiorPinWidth;
            if (pinsAndSockets % 2 != 0 || _interiorBoardWidth == _boardWidth)
            {
                //Number of pins and sockets are odd or whole board is taken up from interior pins/sockets
                pinsAndSockets--;
                _interiorBoardWidth = (double)pinsAndSockets * _interiorPinWidth;
            }
            _numInteriorAreas = (int)(_interiorBoardWidth / _interiorPinWidth);
            _endPinWidth = (_boardWidth - _interiorBoardWidth) / 2;
            generateBreakpoints();
        }
    }
}
