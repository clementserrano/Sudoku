using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Game
    {
        public int[,] grid { get;}
        public int[,] gridSolved { get; }
        public bool generated {get; set;}
        public String currentDiff;

        /// <summary>
        /// Generates valid Sudoku grid for the user to solve.
        /// </summary>
        /// <param name="difficulty"> Chosen difficulty </param>
        public Game(String difficulty)
        {
            currentDiff = difficulty;
            generated = false;
            grid = new int[9, 9];
            
            // Generates a grid
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    backtrack(i, j);
                }
            }
            gridSolved = (int[,])grid.Clone();

            // Removes numbers from grid
            int nbToRemove = 0;
            switch (difficulty)
            {
                case "easy":
                    nbToRemove = 40;
                    break;
                case "normal":
                    nbToRemove = 45;
                    break;
                case "hard":
                    nbToRemove = 50;
                    break;
            }
            
            int[,] tempGrid;
            int[,] saveCopy;
            // Temporary grids to save between tests

            int totalBlanks = 0;                        // Count current number of blanks
            tempGrid = (int[,])grid.Clone();            // Cloned input grid (no damage)
            do
            {   // Call RandomlyBlank() to blank random squares symmetrically
                saveCopy = (int[,])tempGrid.Clone();     // in case undo needed
                tempGrid = RandomlyBlank(tempGrid, ref totalBlanks);
                // Blanks 1 or 2 squares according to symmetry chosen
                grid = new int[9,9];
            } while (totalBlanks < nbToRemove);
            grid = tempGrid;
        }

        /// <summary>
        /// Randomly blanks cells for the user to resolve.
        /// </summary>
        /// <param name="tempGrid"> Sudoku grid </param>
        /// <param name="blankCount"> Number of blanked cells </param>
        /// <returns> Sudoku grid with blanked cells </returns>
        public int[,] RandomlyBlank(int[,] tempGrid, ref int blankCount)
        {
            // Blanks one or two squares(depending on if on center line) randomly
            Random rnd = new Random();          // allow random number generation
            int row = rnd.Next(0, 9);           // choose randomly the row
            int column = rnd.Next(0, 9);        // and column of cell to blank
            while (tempGrid[row, column] == 0)  // don't blank a blank cell
            {
                row = rnd.Next(0, 9);
                column = rnd.Next(0, 9);
            }
            tempGrid[row, column] = 0;          // clear chosen cell
            blankCount++;                       // increment the count of blanks
            
            // diagonal symmetry
            if (tempGrid[column, row] != 0)
                blankCount++;
            tempGrid[column, row] = 0;

            return tempGrid;
        }

        /// <summary>
        /// Checks that inputted caracter is a number between 1 and 9 and that is unique in its column, row and square. 
        /// </summary>
        /// <param name="number"> Inputted number </param>
        /// <param name="row"> Given cell's row position </param>
        /// <param name="column"> Given cell's column position </param>
        /// <returns> True if number settled, else false </returns>
        public bool setNumber(int number, int row, int column)
        {
            if (grid[row, column] == number)
            {
                return false;
            }
            if (number > 0 && number < 10 && checkColumn(number, column) && checkRow(number, row) && checkSquare(number, row, column))
            {
                grid[row, column] = number;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Reset the cell value to 0
        /// </summary>
        /// <param name="row"> Given cell's row position </param>
        /// <param name="column"> Given cell's column position </param>
        public void resetCell(int row, int column)
        {
            grid[row, column] = 0;
        }

        /// <summary>
        /// General algorith for finding all solutions for a generated grid. 
        /// </summary>
        /// <param name="x"> Given cell's row position </param>
        /// <param name="y"> Given cell's column position </param>
        /// <returns> True if solution found, else false </returns>
        public bool backtrack(int x, int y)
        {
            if (isGridFilled())
            { // Empty cells filled. Solution found. Abort
                return true;
            }
            Random rnd = new Random();
            IEnumerable<int> numbers = Enumerable.Range(1, 9).OrderBy(r => rnd.Next());
            foreach (int n in numbers)
            {
                if (setNumber(n, x, y))
                {
                    Tuple<int, int> pos = nextPosition(x, y);
                    if (backtrack(pos.Item1, pos.Item2) == true)
                    { // Move to next empty cell
                        return true; // Empty cells filled. Solution found. Abort.
                    }
                }
            }
            grid[x, y] = 0; // Empties cell
            return false;   // Solution not found. Backtrack.
        }

        /// <summary>
        /// Checks if current grid is filled.
        /// </summary>
        /// <returns> True if filled, else false </returns>
        public bool isGridFilled()
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Calculates next cell's position of a given cell.
        /// </summary>
        /// <param name="x"> Given cell's current row position </param>
        /// <param name="y"> Given cell's current column position </param>
        /// <returns> Tuple (row, column) of next cell's position </row></returns>
        public Tuple<int, int> nextPosition(int x, int y)
        {
            int rx = 0;
            int ry = 0;
            if (y + 1 > 8)
            {
                ry = 0;
                rx = x + 1;
            }
            else
            {
                rx = x;
                ry = y + 1;
            }
            return new Tuple<int, int>(rx, ry);
        }

        /// <summary>
        /// Checks that inputted number isn't already in the same column.
        /// </summary>
        /// <param name="number"> Inputted number </param>
        /// <param name="column"> Changed cell's column position </param>
        /// <returns> True if inputted number is unique in its column, else false </returns>
        private bool checkColumn(int number, int column)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                if (grid[i, column] == number)
                {
                    if (generated)
                    {
                        throw new SudokuException("There's already a " + number + " in this column !");
                    }
                    return false;
                }

            }
            return true;
        }

        /// <summary>
        /// Checks that inputted number isn't already in the same row.
        /// </summary>
        /// <param name="number"> Inputted number </param>
        /// <param name="row"> Changed cell's row position </param>
        /// <returns> True if inputted number is unique in its row, else false </returns>
        private bool checkRow(int number, int row)
        {
            for (int i = 0; i < grid.GetLength(1); i++)
            {
                if (grid[row, i] == number)
                {
                    if (generated)
                    {
                        throw new SudokuException("There's already a " + number + " in this row !");
                    }
                    return false;
                }

            }
            return true;
        }

        /// <summary>
        /// Checks that inputted number isn't already in the 3x3 square.
        /// </summary>
        /// <param name="number"> Inputted number </param>
        /// <param name="row"> Changed cell's row position </param>
        /// <param name="column"> Changed cell's column position </param>
        /// <returns> True if inputted number is unique in its square, else false </returns>
        private bool checkSquare(int number, int row, int column)
        {
            // Check the position within the square to retrieve the square numbers
            int[] square = new int[8];
            if (row % 3 == 0 && column % 3 == 0) //
            {
                square = new int[] {
                    grid[row, column +1],
                    grid[row, column +2],
                    grid[row +1, column],
                    grid[row +1, column +1],
                    grid[row +1, column +2],
                    grid[row +2, column],
                    grid[row +2, column +1],
                    grid[row +2, column +2]
                };
            }
            else if (row % 3 == 0 && column % 3 == 1)
            {
                square = new int[] {
                    grid[row, column -1],
                    grid[row, column +1],
                    grid[row +1, column -1],
                    grid[row +1, column],
                    grid[row +1, column +1],
                    grid[row +2, column -1],
                    grid[row +2, column],
                    grid[row +2, column +1]
                };
            }
            else if (row % 3 == 0 && column % 3 == 2)
            {
                square = new int[] {
                    grid[row, column -2],
                    grid[row, column -1],
                    grid[row +1, column -2],
                    grid[row +1, column -1],
                    grid[row +1, column],
                    grid[row +2, column -2],
                    grid[row +2, column -1],
                    grid[row +2, column]
                };
            }
            else if (row % 3 == 1 && column % 3 == 0)
            {
                square = new int[] {
                    grid[row -1, column],
                    grid[row -1, column +1],
                    grid[row -1, column +2],
                    grid[row, column +1],
                    grid[row, column +2],
                    grid[row +1, column],
                    grid[row +1, column +1],
                    grid[row +1, column +2]
                };
            }
            else if (row % 3 == 1 && column % 3 == 1)
            {
                square = new int[] {
                    grid[row -1, column -1],
                    grid[row -1, column],
                    grid[row -1, column +1],
                    grid[row, column -1],
                    grid[row, column +1],
                    grid[row +1, column -1],
                    grid[row +1, column],
                    grid[row +1, column +1]
                };
            }
            else if (row % 3 == 1 && column % 3 == 2)
            {
                square = new int[] {
                    grid[row -1, column -2],
                    grid[row -1, column -1],
                    grid[row -1, column],
                    grid[row, column -2],
                    grid[row, column -1],
                    grid[row +1, column -2],
                    grid[row +1, column -1],
                    grid[row +1, column]
                };
            }
            else if (row % 3 == 2 && column % 3 == 0)
            {
                square = new int[] {
                    grid[row -2, column],
                    grid[row -2, column +1],
                    grid[row -2, column +2],
                    grid[row -1, column],
                    grid[row -1, column +1],
                    grid[row -1, column +2],
                    grid[row, column +1],
                    grid[row, column +2]
                };
            }
            else if (row % 3 == 2 && column % 3 == 1)
            {
                square = new int[] {
                    grid[row -2, column -1],
                    grid[row -2, column],
                    grid[row -2, column +1],
                    grid[row -1, column -1],
                    grid[row -1, column],
                    grid[row -1, column +1],
                    grid[row, column -1],
                    grid[row, column +1]
                };
            }
            else if (row % 3 == 2 && column % 3 == 2)
            {
                square = new int[] {
                    grid[row -2, column -2],
                    grid[row -2, column -1],
                    grid[row -2, column],
                    grid[row -1, column -2],
                    grid[row -1, column -1],
                    grid[row -1, column],
                    grid[row, column -2],
                    grid[row, column -1]
                };
            }
            if (square.Contains(number))
            {
                if (generated)
                {
                    throw new SudokuException("There's already a " + number + " in this square !");
                }
                return false;
            }
            return true;
        }
        
        /// <summary>
        ///  Modifies display for debuging
        /// </summary>
        /// <returns> String to display </returns>
        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    res += grid[i, j] + " ";
                }
                res += "\n";
            }
            return res;
        }
    }
}
