using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Game
    {
        private int[,] gridSolved;
        private int[,] grid;
        private bool generated = false;

        public Game(String difficulty)
        {
            grid = new int[9, 9];
            // Generate a grid
            for (int i = 0; i < this.grid.GetLength(0); i++)
            {
                for (int j = 0; j < this.grid.GetLength(1); j++)
                {
                    backtrack(i, j);
                }
            }
            gridSolved = (int[,])grid.Clone();
            // Remove numbers from grid
            int nbToRemove = 0;
            switch (difficulty)
            {
                case "easy":
                    break;
                case "normal":
                    nbToRemove = 45;
                    break;
                case "hard":
                    break;
            }
            Random rnd = new Random();
            int k = 0;
            while(k < nbToRemove)
            {
                int x = rnd.Next(0, 8);
                int y = rnd.Next(0, 8);
                if (grid[x, y] != 0)
                {
                    grid[x, y] = 0;
                    k++;
                }
            }
        }

        public int[,] getGridSolved()
        {
            return this.gridSolved;
        }

        public int[,] getGrid()
        {
            return this.grid;
        }

        public void unlock()
        {
            generated = true;
        }

        public bool setNumber(int number, int row, int column)
        {
            if (grid[row, column] == number)
            {
                return false;
            }
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
                    if (generated)
                    {
                        throw new SudokuException("There's already a " + number + " in this column !");
                    }
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
                    if (generated)
                    {
                        throw new SudokuException("There's already a " + number + " in this row !");
                    }
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
                if (generated)
                {
                    throw new SudokuException("There's already a " + number + " in this square !");
                }
                return false;
            }
            return true;
        }

        public bool backtrack(int x, int y)
        {
            if (isGridFilled())
            { // Empty cells filled. Solution found. Abort
                return true;
            }
            System.Random rnd = new System.Random();
            IEnumerable<int> numbers = Enumerable.Range(1, 9).OrderBy(r => rnd.Next());
            foreach (int n in numbers){
                if (setNumber(n, x, y))
                {
                    System.Console.WriteLine(this);
                    Tuple<int, int> pos = nextPosition(x, y);
                    if (backtrack(pos.Item1, pos.Item2) == true)
                    { // Move to next empty cell
                        return true; // Empty cells filled. Solution found. Abort.
                    }
                }
            }
            grid[x,y] = 0; // Empties cell
            return false; //Solution not found. Backtrack.
        }

        public bool isGridFilled()
        {
            for (int i = 0; i < this.grid.GetLength(0); i++)
            {
                for (int j = 0; j < this.grid.GetLength(1); j++)
                {
                    if (grid[i, j] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public Tuple<int,int> nextPosition(int x, int y)
        {
            int rx = 0;
            int ry = 0;
            if (y + 1 > 8)
            {
                ry = 0;
                rx = x + 1;
            }else
            {
                rx = x;
                ry = y + 1;
            }
            return new Tuple<int, int>(rx, ry);
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
