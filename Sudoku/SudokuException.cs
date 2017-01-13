using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class SudokuException : Exception
    {
        /// <summary>
        /// Throws an exeption.
        /// </summary>
        /// <param name="message"> String message to display </param>
        public SudokuException(String message) : base(message)
        {
        }
    }
}