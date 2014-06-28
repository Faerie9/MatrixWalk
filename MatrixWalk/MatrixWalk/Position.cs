namespace MatrixWalk
{
    using System;
    using System.Linq;

    /// <summary>
    /// This class represents a position with given row and column number.
    /// </summary>

    public class Position
    {
        private int rowNumber;
        private int colNumber;

        /// <summary>
        /// The constructor of the class.
        /// </summary>
        /// <param name="numberOfRows">Number of the given row.</param>
        /// <param name="numberOfCols">Number of the given column.</param>

        public Position(int numberOfRows, int numberOfCols)
        {
            this.rowNumber = numberOfRows;
            this.colNumber = numberOfCols;
        }

        /// <summary>
        /// Number of row of the given position.
        /// </summary>

        public int RowNumber
        {
            get
            {
                return this.rowNumber;
            }

            private set
            {
                this.rowNumber = value;
            }
        }

        /// <summary>
        /// Number of column of the given position. 
        /// </summary>

        public int ColNumber
        {
            get
            {
                return this.colNumber;
            }

            private set
            {
                this.colNumber = value;
            }
        }
    }
}
