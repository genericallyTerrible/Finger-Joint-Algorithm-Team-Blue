using FingerJointAlgorithm;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace FingerJointAlgorithmTesting
{
    [TestClass]
    public class BoardTesting
    {
        [TestMethod]
        public void PinBoardTest()
        {
            double BoardWidth = 4;
            double BoardHeight = 1;
            double CutDepth = 2;
            double EndMillDiameter = (double)1 / 8;
            double Clearance = (double)1 / 64;
            double EndPinWidth = 0.5;
            int NumInteriorPins = 1;

            Breakpoints testPoints = new Breakpoints(BoardWidth, Clearance, EndPinWidth, NumInteriorPins);
            double[] testPinPoints = testPoints.generatePinBoard();

            Board testBoard = new Board(BoardHeight, BoardWidth, EndMillDiameter, CutDepth, Clearance);
            CutArea[] testAreas =  testBoard.generatePinBoard(EndPinWidth, NumInteriorPins);

            int x = 0;
            for(int i = 1; i < testPinPoints.Length - 1;)
            {
                Assert.AreEqual(testPinPoints[i++], testAreas[x].xStart);
                Assert.AreEqual(testPinPoints[i++], testAreas[x].xStop);
                Assert.AreEqual((0 - (0.5 * EndMillDiameter)), testAreas[x].yStart);
                Assert.AreEqual((BoardWidth + (0.5 * EndMillDiameter)), testAreas[x].yStop);
                Assert.AreEqual(CutDepth, testAreas[x++].CutDepth);
            }
            
        }

        [TestMethod]
        public void SocketBoardTest()
        {
            double BoardWidth = 4;
            double BoardHeight = 1;
            double CutDepth = 2;
            double EndMillDiameter = (double)1 / 8;
            double Clearance = (double)1 / 64;
            double EndPinWidth = 0.5;
            int NumInteriorPins = 1;

            Breakpoints testPoints = new Breakpoints(BoardWidth, Clearance, EndPinWidth, NumInteriorPins);
            double[] testSocketPoints = testPoints.generateSocketBoard();

            Board testBoard = new Board(BoardHeight, BoardWidth, EndMillDiameter, CutDepth, Clearance);
            CutArea[] testAreas = testBoard.generateSocketBoard(EndPinWidth, NumInteriorPins);

            int x = 0;
            for (int i = 0; i < testSocketPoints.Length - 1;)
            {
                Assert.AreEqual(testSocketPoints[i++], testAreas[x].xStart);
                Assert.AreEqual(testSocketPoints[i++], testAreas[x].xStop);
                Assert.AreEqual((0 - (0.5 * EndMillDiameter)), testAreas[x].yStart);
                Assert.AreEqual((BoardWidth + (0.5 * EndMillDiameter)), testAreas[x].yStop);
                Assert.AreEqual(CutDepth, testAreas[x++].CutDepth);
            }

        }
    }
}
