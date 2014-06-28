namespace MatrixWalkTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MatrixWalk;

    [TestClass]
    public class PositionTests
    {
        [TestMethod]
        public void MakeNormalPositionTestRow()
        {
            int row = 2;
            int col = 3;

            Position testPosition = new Position(row, col);

            Assert.AreEqual(testPosition.RowNumber, row, "The given in the constructor row and the actual one in the position differ.");
        }

        public void MakeNormalPositionTestCol()
        {
            int row = 2;
            int col = 3;

            Position testPosition = new Position(row, col);

            Assert.AreEqual(testPosition.ColNumber, col, "The given in the constructor col and the actual one in the position differ.");
        }
    }
}
