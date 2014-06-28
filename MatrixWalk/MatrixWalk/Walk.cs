namespace MatrixWalk
{
    using System;
    using System.Linq;

    /// <summary>
    /// The class walk represents a walk in the matrix by given directions, assuming that a cell can be visited all but once and the walk can't
    /// go outside the matrix.
    /// </summary>


    public class Walk
    {

        /// <summary>
        /// The array of positions holds the possible directions for the current walk.
        /// </summary>
        private static readonly Position[] directionIncrements = new Position[]
        {
            new Position(1,1),
            new Position(1,0),
            new Position(1,-1),
            new Position(0,-1),
            new Position(-1,-1),
            new Position(-1,0),
            new Position(-1,1),
            new Position(0,1)
        };

        /// <summary>
        /// A field that holds the index of the currently used direction.
        /// </summary>

        private int directionChangeIndex = 0;

        private Matrix field;

        /// <summary>
        /// Constructor for the Walk class- creates a walk associated to a given matrix.
        /// </summary>
        /// <param name="matrix">The matrix to perform the walk in.</param>

        public Walk(Matrix matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentException("Can't make a walk in a null matrix.");
            }

            this.Field = matrix;
        }

        /// <summary>
        /// The matrix to walk in is represented as the property Field.
        /// </summary>

        public Matrix Field
        {
            get
            {
                return this.field;
            }
            private set
            {
                this.field = value;
            }
        }

        /// <summary>
        /// This method is performing the actual walk, starting with the position 0,0. Afterwards, for every value to fill in the field, a new position
        /// is calculated using the ComputeNextPosition method. 
        /// </summary>

        public void StartWalk()
        {
            Position currentPosition = new Position(0, 0);

            this.Field.UpdateSeparateValue(currentPosition, 1);

            double maximalValue = Math.Pow(this.Field.RowCount, 2)+1;

            for (int nextValue = 2; nextValue < maximalValue; nextValue++)
            {
                currentPosition = ComputeNextPosition(currentPosition, 0);

                this.Field.UpdateSeparateValue(currentPosition, nextValue);
            }

            PrintOutMatrix();
        }

        /// <summary>
        /// The method calculates a new position in the matrix in the current direction, if that doesn't lead outside the matrix or to an already
        /// visited cell. Should such case occur, the direction change index and the turn counter increase and the method is called again. If
        /// a full spin is made and a valid position is still not found, the next free cell that fits the criteria is picked.
        /// </summary>
        /// <param name="currentPosition">Position of the current cell.</param>
        /// <param name="turnCounter">How many times the direction has been changed for the cell we are searching a position for..</param>
        /// <returns>The position of the next value.</returns>

        private Position ComputeNextPosition(Position currentPosition,int turnCounter)
        {
            Position nextPosition = new Position(0, 0);

            int rowIncrement = directionIncrements[directionChangeIndex].RowNumber;
            int colIncrement = directionIncrements[directionChangeIndex].ColNumber;
            int nextRow = currentPosition.RowNumber+rowIncrement;
            int nextCol = currentPosition.ColNumber+colIncrement;

            bool positionIsValid = CheckIfPositionIsValid(nextRow, nextCol);

            if (positionIsValid)
            {
                nextPosition = new Position(nextRow, nextCol);
            }
            else
            {
                if (turnCounter <= 8)
                {
                    ChangeDirection();

                    turnCounter++;

                    nextPosition = ComputeNextPosition(currentPosition, turnCounter);
                }
                else
                {
                    nextPosition = FindNextFreePosition();
                }
            }
            return nextPosition;
        }

        /// <summary>
        /// This method increases the direction index. If it has reached the last index, the direction is reset to 0. 
        /// 
        /// </summary>

        private void ChangeDirection()
        {
            directionChangeIndex++;

            if (directionChangeIndex == 8)
            {
                directionChangeIndex = 0;
            }
        }

        /// <summary>
        /// Method to check if the position found is valid- namely if it's within the matrix and hasn't been visited yet.
        /// </summary>
        /// <param name="nextRow">Row of the found position.</param>
        /// <param name="nextCol">Column of the found position.</param>
        /// <returns>Boolean result- true if the position is valid, false- if it isn't.</returns>

        private bool CheckIfPositionIsValid(int nextRow, int nextCol)
        {
            bool positionIsInRange = CheckIfPositionIsInRange(nextRow, nextCol);
            bool positionIsAvailable = false;

            if (positionIsInRange)
            {
                positionIsAvailable = CheckIfPositionIsAvailable(nextRow, nextCol);
            }

            bool result = positionIsInRange && positionIsAvailable;
            return result;
        }

        /// <summary>
        /// This method checks if the given position is within the matrix.
        /// </summary>
        /// <param name="row">Row of the position.</param>
        /// <param name="col">Column of the position.</param>
        /// <returns>True if the position is within the matrix, false- if it's outside.</returns>

        private bool CheckIfPositionIsInRange(int row, int col)
        {
            bool rowIsInRange = (row >= 0) && (row < this.Field.RowCount);
            bool colIsInRange = (col >= 0) && (col < this.Field.ColCount);

            return rowIsInRange && colIsInRange;
        }


        /// <summary>
        /// This method checks if the given position hasn't been assigned a value already. 
        /// </summary>
        /// <param name="row">Row of the given position.</param>
        /// <param name="col">Column of the given position.</param>
        /// <returns>True if the position is available, false- if it's not.</returns>

        private bool CheckIfPositionIsAvailable(int row, int col)
        {
            if (this.Field.MatrixValues[row, col] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// This method finds the next free position, when all directions around the current one give no result.
        /// </summary>
        /// <returns>The next free position.</returns>

        private Position FindNextFreePosition()
        {
            for (int row = 0; row < this.Field.RowCount; row++)
            {
                for (int col = 0; col < this.Field.ColCount; col++)
                {
                    if (this.Field.MatrixValues[row, col] ==0)
                    {
                        Position nextFreePosition = new Position(row, col);
                        return nextFreePosition;
                    }
                }
            }

            return new Position(0, 0);
        }

        /// <summary>
        /// This method prints the current values in the matrix. 
        /// </summary>

        private void PrintOutMatrix()
        {
            for (int row = 0; row < this.Field.RowCount; row++)
            {
                for (int col = 0; col < this.Field.ColCount; col++)
                {
                    Console.Write( "{0,4}",this.Field.MatrixValues[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
