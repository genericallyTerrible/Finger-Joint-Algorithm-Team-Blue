using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FingerJointAlgorithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            double BoardWidth = 7;
            double BoardHeight = 2;
            double CutDepth = 2;
            double EndMillDiameter = (double)1 / 8;
            double Clearance = ((double)1 / 32);
            double EndPinWidth = 1;
            int NumInteriorPins = 5;

            
            
            
            Breakpoints breakPointsTest = new Breakpoints(BoardWidth, Clearance, EndPinWidth, NumInteriorPins);
            Console.WriteLine();
            Console.WriteLine("Ideal Breakpoints:");
            Console.WriteLine("[" + string.Join(", ", breakPointsTest.IdealBreakpoints) + "]");
            Console.WriteLine("Pin Board Break Points:");
            Console.WriteLine("[" + string.Join(", ", breakPointsTest.generatePinBoard()) + "]");
            Console.WriteLine("Socket Board Break Points:");
            Console.WriteLine("[" + string.Join(", ", breakPointsTest.generateSocketBoard()) + "]");

            Board boardTest = new Board(BoardHeight, BoardWidth, EndMillDiameter, CutDepth, Clearance);
            CutArea[] pinBoardTest = boardTest.generatePinBoard(EndPinWidth, NumInteriorPins);
            CutArea[] socketBoardTest = boardTest.generateSocketBoard(EndPinWidth, NumInteriorPins);

            Console.WriteLine();
            Console.WriteLine("Pinboard areas to be cut:");
            foreach (CutArea cutArea in pinBoardTest)
            {
                Console.WriteLine(cutArea.ToString());
            }
            
            Console.WriteLine("Socketboard areas to be cut:");
            foreach (CutArea cutArea in socketBoardTest)
            {
                Console.WriteLine(cutArea.ToString());
            }
        }
    }
}
