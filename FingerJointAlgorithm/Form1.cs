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
            double Clearance = ((double)1 / 64);
            double EndPinWidth = 0.5;
            double InteriorPinWidth = 1;
            int NumInteriorPins = 1;
            FindingBreakpoints test1 = new Case1(BoardWidth, Clearance, EndPinWidth, NumInteriorPins);
            FindingBreakpoints test2 = new Case2(BoardWidth, Clearance, EndPinWidth, InteriorPinWidth);
            FindingBreakpoints test3 = new Case3(BoardWidth, Clearance, InteriorPinWidth);
            Console.WriteLine(test1);
            Console.WriteLine(test2);
            Console.WriteLine(test3);
            Console.WriteLine(string.Join(", ", test1.generatePinBoard()));
            Console.WriteLine(string.Join(", ", test1.generateSocketBoard()));
        }
    }
}
