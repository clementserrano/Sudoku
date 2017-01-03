using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Game
    {
        private int[,] grid;

        public Game() // ADD Parameter for difficulty
        {
            this.grid = new int[9, 9];
            // TODO Generate a grid

        }

        public int[,] getGrid()
        {
            return this.grid;
        }

        public bool setNumber(int number, int row, int column)
        {
            if (number > 0 && number < 10 && this.checkColumn(number, column) && this.checkRow(number, row) && this.checkSquare(number, row, column))
            {
                this.grid[row, column] = number;
                return true;
            }
            return false;
        }

        private bool checkColumn(int number, int column)
        {
            for (int i = 0; i < this.grid.GetLength(0); i++)
            {
                if (this.grid[i, column] == number)
                {
                    return false;
                }

            }
            return true;
        }

        private bool checkRow(int number, int row)
        {
            for (int i = 0; i < this.grid.GetLength(1); i++)
            {
                if (this.grid[row, i] == number)
                {
                    return false;
                }

            }
            return true;
        }

        private bool checkSquare(int number, int row, int column)
        {
            // Check the position within the square to retrieve the square numbers
            int[] square = new int[8];
            if (row % 3 == 0 && column % 3 == 0) //
            {
                square = new int[] {
                    this.grid[row, column +1],
                    this.grid[row, column +2],
                    this.grid[row +1, column],
                    this.grid[row +1, column +1],
                    this.grid[row +1, column +2],
                    this.grid[row +2, column],
                    this.grid[row +2, column +1],
                    this.grid[row +2, column +2]
                };
            }
            else if (row % 3 == 0 && column % 3 == 1)
            {
                square = new int[] {
                    this.grid[row, column -1],
                    this.grid[row, column +1],
                    this.grid[row +1, column -1],
                    this.grid[row +1, column],
                    this.grid[row +1, column +1],
                    this.grid[row +2, column -1],
                    this.grid[row +2, column],
                    this.grid[row +2, column +1]
                };
            }
            else if (row % 3 == 0 && column % 3 == 2)
            {
                square = new int[] {
                    this.grid[row, column -2],
                    this.grid[row, column -1],
                    this.grid[row +1, column -2],
                    this.grid[row +1, column -1],
                    this.grid[row +1, column],
                    this.grid[row +2, column -2],
                    this.grid[row +2, column -1],
                    this.grid[row +2, column]
                };
            }
            else if (row % 3 == 1 && column % 3 == 0)
            {
                square = new int[] {
                    this.grid[row -1, column],
                    this.grid[row -1, column +1],
                    this.grid[row -1, column +2],
                    this.grid[row, column +1],
                    this.grid[row, column +2],
                    this.grid[row +1, column],
                    this.grid[row +1, column +1],
                    this.grid[row +1, column +2]
                };
            }
            else if (row % 3 == 1 && column % 3 == 1)
            {
                square = new int[] {
                    this.grid[row -1, column -1],
                    this.grid[row -1, column],
                    this.grid[row -1, column +1],
                    this.grid[row, column -1],
                    this.grid[row, column +1],
                    this.grid[row +1, column -1],
                    this.grid[row +1, column],
                    this.grid[row +1, column +1]
                };
            }
            else if (row % 3 == 1 && column % 3 == 2)
            {
                square = new int[] {
                    this.grid[row -1, column -2],
                    this.grid[row -1, column -1],
                    this.grid[row -1, column],
                    this.grid[row, column -2],
                    this.grid[row, column -1],
                    this.grid[row +1, column -2],
                    this.grid[row +1, column -1],
                    this.grid[row +1, column]
                };
            }
            else if (row % 3 == 2 && column % 3 == 0)
            {
                square = new int[] {
                    this.grid[row -2, column],
                    this.grid[row -2, column +1],
                    this.grid[row -2, column +2],
                    this.grid[row -1, column],
                    this.grid[row -1, column +1],
                    this.grid[row -1, column +2],
                    this.grid[row, column +1],
                    this.grid[row, column +2]
                };
            }
            else if (row % 3 == 2 && column % 3 == 1)
            {
                square = new int[] {
                    this.grid[row -2, column -1],
                    this.grid[row -2, column],
                    this.grid[row -2, column +1],
                    this.grid[row -1, column -1],
                    this.grid[row -1, column],
                    this.grid[row -1, column +1],
                    this.grid[row, column -1],
                    this.grid[row, column +1]
                };
            }
            else if (row % 3 == 2 && column % 3 == 2)
            {
                square = new int[] {
                    this.grid[row -2, column -2],
                    this.grid[row -2, column -1],
                    this.grid[row -2, column],
                    this.grid[row -1, column -2],
                    this.grid[row -1, column -1],
                    this.grid[row -1, column],
                    this.grid[row, column -2],
                    this.grid[row, column -1]
                };
            }
            if (square.Contains(number))
            {
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < this.grid.GetLength(0); i++)
            {
                for (int j = 0; j < this.grid.GetLength(1); j++)
                {
                    res += this.grid[i, j] + " ";
                }
                res += "\n";
            }
            return res;
        }
    }
}
