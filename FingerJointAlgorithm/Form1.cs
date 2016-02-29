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
            double BoardWidth = 4;
            double BoardHeight = 1;
            double CutDepth = 2;
            double EndMillDiameter = (double)1 / 4;
            double Clearance = ((double)1 / 64);
            double EndPinWidth = 0.5;
            int NumInteriorPins = 1;

            
            
            
            Breakpoints breakPointsTest = new Breakpoints(BoardWidth, Clearance, EndPinWidth, NumInteriorPins);
            Console.WriteLine();
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
