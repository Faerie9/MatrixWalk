namespace MatrixWalk
{
    using System;
    using System.Linq;

    /// <summary>
    /// This class represents a matrix that for the current task has to be square. 
    /// </summary>
    
    public class Matrix
    {
        private int[,] matrixValues;
        private int rowCount;
        private int colCount;

        /// <summary>
        /// Create a matrix by given count of rows. For the current task the matrix has to be square, so the count of rows is the same as
        /// the count of columns.
        /// </summary>
        /// <param name="countOfRows">Size of the matrix.</param>

        public Matrix(int countOfRows)
        {
            this.RowCount = countOfRows;
            this.ColCount = countOfRows;
            this.MatrixValues = new int[countOfRows, countOfRows];
        }

        /// <summary>
        /// The two dimensional int array that holds the values of the current matrix.
        /// </summary>
       
        public int[,] MatrixValues
        {
            get
            {
                int[,] copyOfValues = this.MakeDeepCopyOfValues(this.matrixValues);

                return copyOfValues;
            }

            private set
            {
                this.matrixValues = value;
            }
        }

        /// <summary>
        /// The number of rows in the matrix.
        /// </summary>

        public int RowCount
        {
            get
            {
                return this.rowCount;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format("Invalid size of matrix - {0}. It must be positive.", value));
                }

                this.rowCount = value;
            }
        }

        /// <summary>
        /// The number of columns in the matrix- for the current task the number of rows and the number of columns are the same.
        /// </summary>

        public int ColCount
        {
            get
            {
                return this.colCount;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format("Invalid size of matrix - {0}. It must be positive.", value));
                }

                this.colCount = value;
            }
        }

        /// <summary>
        /// This method sets the value of an individual cell in the array of values.
        /// </summary>
        /// <param name="currentPosition">Position of the current cell- a position has row and column number.</param>
        /// <param name="currentValue">The value to set to the current cell- it must be between 1 and the squared value of the row count.</param>

        public void UpdateSeparateValue(Position currentPosition, int currentValue)
        {
            int currentRow;
            int currentCol;

            try
            {
                currentRow = currentPosition.RowNumber;
                currentCol = currentPosition.ColNumber;
            }
            catch (NullReferenceException)
            {
                throw new ArgumentException("The position to set a value to is null.");
            }

            if (currentRow < 0 || currentRow >= this.RowCount)
            {
                throw new ArgumentException(string.Format("Row of the given position ({0}), is outside of the matrix range- 0 to {1}", currentRow, this.RowCount));
            }
            else if (currentCol < 0 || currentCol >= this.ColCount)
            {
                throw new ArgumentException(string.Format("Col of the given position ({0}), is outside of the matrix range- 0 to {1}", currentCol, this.ColCount));
            }
            else if (currentValue < 1 || currentValue > Math.Pow(this.RowCount, 2))
            {
                throw new ArgumentException(string.Format("The given value ({0}) , is outside of the range of values for this matrix- 1 to {1}", currentValue, Math.Pow(this.RowCount, 2)));
            }

            this.matrixValues[currentRow, currentCol] = currentValue;
        }


        /// <summary>
        /// This is a method that makes a deep copy of a given array, in the current class used to make a deep copy of the matrix values, so that
        /// the array of values isn't returned directly and its manipulation is accessible only via the UpdateSeparateValue method. 
        /// </summary>
        /// <param name="valuesOfMatrix">The array to clone.</param>
        /// <returns>The copy array.</returns>

        private int[,] MakeDeepCopyOfValues(int[,] valuesOfMatrix)
        {
            int[,] copyOfValues = new int[this.RowCount, this.ColCount];

            for (int row = 0; row < this.RowCount; row++)
            {
                for (int col = 0; col < this.ColCount; col++)
                {
                    copyOfValues[row, col] = valuesOfMatrix[row, col];
                }
            }

            return copyOfValues;
        }
    }
}