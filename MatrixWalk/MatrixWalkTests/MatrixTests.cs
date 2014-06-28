namespace MatrixWalkTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MatrixWalk;

    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        public void MakeNormalMatrixTestRows()
        {
            int matrixSize = 4;

            Matrix testMatrix = new Matrix(matrixSize);

            Assert.AreEqual(testMatrix.RowCount, matrixSize, "The matrix row size differs from the given in the constructor.");

            Assert.AreEqual(testMatrix.ColCount, matrixSize, "The matrix col size differs from the given in the constructor.");
        }

        [TestMethod]
        public void MakeNormalMatrixTestCols()
        {
            int matrixSize = 4;

            Matrix testMatrix = new Matrix(matrixSize);

            Assert.AreEqual(testMatrix.ColCount, matrixSize, "The matrix col size differs from the given in the constructor.");
        }

        [TestMethod]
        public void MakeNormalMatrixTestValuesRows()
        {
            int matrixSize = 4;

            Matrix testMatrix = new Matrix(matrixSize);

            Assert.AreEqual(testMatrix.MatrixValues.GetLength(0), matrixSize, "The matrix's array of values row count differs from the given in the constructor.");
        }

        [TestMethod]
        public void MakeNormalMatrixTestValuesCols()
        {
            int matrixSize = 4;

            Matrix testMatrix = new Matrix(matrixSize);

            Assert.AreEqual(testMatrix.MatrixValues.GetLength(1), matrixSize, "The matrix's array of values col count differs from the given in the constructor.");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MakeMatrixNegativeRowCount()
        {
            Matrix testMatrix = new Matrix(-4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MakeMatrixZeroRowCount()
        {
            Matrix testMatrix = new Matrix(0);
        }

        [TestMethod]
        public void SetMatrixValueNormalPosition()
        {
            int row = 2;
            int col = 3;
            int value = 14;

            Position testPosition = new Position(row, col);

            Matrix testMatrix = new Matrix(4);

            testMatrix.UpdateSeparateValue(testPosition, value);

            Assert.AreEqual(testMatrix.MatrixValues[row, col], value, "The given value differs from the one in the matrix values array.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TryToSetValueNullPosition()
        {

            Matrix testMatrix = new Matrix(4);

            testMatrix.UpdateSeparateValue(null, 10);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TryToSetValueNegativeRow()
        {
            int row = -2;
            int col = 3;
            int value = 14;

            Position testPosition = new Position(row, col);

            Matrix testMatrix = new Matrix(4);

            testMatrix.UpdateSeparateValue(testPosition, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TryToSetValueNegativeCol()
        {
            int row = 2;
            int col = -3;
            int value = 14;

            Position testPosition = new Position(row, col);

            Matrix testMatrix = new Matrix(4);

            testMatrix.UpdateSeparateValue(testPosition, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TryToSetValueNegativeRowAndCol()
        {
            int row = -2;
            int col = -3;
            int value = 14;

            Position testPosition = new Position(row, col);

            Matrix testMatrix = new Matrix(4);

            testMatrix.UpdateSeparateValue(testPosition, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TryToSetValueRowTooBig()
        {
            int row = 20;
            int col = 3;
            int value = 14;

            Position testPosition = new Position(row, col);

            Matrix testMatrix = new Matrix(4);

            testMatrix.UpdateSeparateValue(testPosition, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TryToSetValueColTooBig()
        {
            int row = 2;
            int col = 30;
            int value = 14;

            Position testPosition = new Position(row, col);

            Matrix testMatrix = new Matrix(4);

            testMatrix.UpdateSeparateValue(testPosition, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TryToSetValueRowANdColTooBig()
        {
            int row = 20;
            int col = 30;
            int value = 14;

            Position testPosition = new Position(row, col);

            Matrix testMatrix = new Matrix(4);

            testMatrix.UpdateSeparateValue(testPosition, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TryToSetNegativeValueToMatrixValues()
        {
            int row = 2;
            int col = 3;
            int value = -14;

            Position testPosition = new Position(row, col);

            Matrix testMatrix = new Matrix(4);

            testMatrix.UpdateSeparateValue(testPosition, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TryToSetTooBigValueToMatrixValues()
        {
            int row = 2;
            int col = 3;
            int value = 144;

            Position testPosition = new Position(row, col);

            Matrix testMatrix = new Matrix(4);

            testMatrix.UpdateSeparateValue(testPosition, value);
        }
    }
}
