using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerJointAlgorithm
{
    public class Board
    {
        private double _boardHeight;
        private double _boardWidth;
        private double _endMillDiameter;
        private double _cutDepth;
        private double _clearance;

        public Board(double BoardHeight, double BoardWidth,
            double EndMillDiameter, double CutDepth, double Clearance)
        {
            _boardHeight = BoardHeight;
            _boardWidth = BoardWidth;
            _endMillDiameter = EndMillDiameter;
            _cutDepth = CutDepth;
            _clearance = Clearance;
        }

        private CutArea[] generatePinBoard(Breakpoints breakpoints)
        {
            List<CutArea> cutAreas = new List<CutArea>();
            CutArea temp;
            double xStart;
            double xStop;
            double yStart = 0 - (0.5 * _endMillDiameter);
            double yStop = _boardWidth + (0.5 * _endMillDiameter);
            double[] pinBoardBreaks = breakpoints.generatePinBoard();
            for (int i = 1; i < pinBoardBreaks.Length - 1;)
            {
                xStart = pinBoardBreaks[i++];
                xStop = pinBoardBreaks[i++];
                temp = new CutArea(xStart, xStop, yStart, yStop, _cutDepth);
                cutAreas.Add(temp);
            }
            return cutAreas.ToArray();
        }

        public CutArea[] generatePinBoard(double EndPinWidth, int NumInteriorPins)
        {
            Breakpoints breakpoints = new Breakpoints(_boardWidth, _clearance, EndPinWidth, NumInteriorPins);
            return generatePinBoard(breakpoints);
        }

        public CutArea[] generatePinBoard(double EndPinWidth, double InteriorPinWidth)
        {
            Breakpoints breakpoints = new Breakpoints(_boardWidth, _clearance, EndPinWidth, InteriorPinWidth);
            return generatePinBoard(breakpoints);
        }

        public CutArea[] generatePinBoard(double InteriorPinWidth)
        {
            Breakpoints breakpoints = new Breakpoints(_boardWidth, _clearance, InteriorPinWidth);
            return generatePinBoard(breakpoints);
        }

        private CutArea[] generateSocketBoard(Breakpoints breakpoints)
        {
            List<CutArea> cutAreas = new List<CutArea>();
            CutArea temp;
            double xStart;
            double xStop;
            double yStart = 0 - (0.5 * _endMillDiameter);
            double yStop = _boardWidth + (0.5 * _endMillDiameter);
            double[] socketBoardBreaks = breakpoints.generateSocketBoard();
            for (int i = 0; i < socketBoardBreaks.Length - 1;)
            {
                xStart = socketBoardBreaks[i++];
                xStop = socketBoardBreaks[i++];
                temp = new CutArea(xStart, xStop, yStart, yStop, _cutDepth);
                cutAreas.Add(temp);
            }
            return cutAreas.ToArray();
        }

        public CutArea[] generateSocketBoard(double EndPinWidth, int NumInteriorPins)
        {
            Breakpoints breakpoints = new Breakpoints(_boardWidth, _clearance, EndPinWidth, NumInteriorPins);
            return generateSocketBoard(breakpoints);
        }

        public CutArea[] generateSocketBoard(double EndPinWidth, double InteriorPinWidth)
        {
            Breakpoints breakpoints = new Breakpoints(_boardWidth, _clearance, EndPinWidth, InteriorPinWidth);
            return generatePinBoard(breakpoints);
        }

        public CutArea[] generateSocketBoard(double InteriorPinWidth)
        {
            Breakpoints breakpoints = new Breakpoints(_boardWidth, _clearance, InteriorPinWidth);
            return generateSocketBoard(breakpoints);
        }

    }
}
