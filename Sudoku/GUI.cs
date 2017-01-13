using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class GUI : Form
    {
        private Game game;
        private NumberBox[,] gridNumbers;

        public GUI()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Creates new "normal" game by default.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GUI_Load(object sender, EventArgs e)
        {
            newGame("normal");
        }

        /// <summary>
        /// Generates and displays a valid sudoku game.  
        /// </summary>
        /// <param name="difficulty"> Chosen difficulty </param>
        private void newGame(string difficulty)
        {
            gridView.Controls.Clear();
            game = new Game(difficulty);
            gridNumbers = new NumberBox[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    NumberBox n = new NumberBox(i, j, game);
                    if (game.grid[i, j] == 0)
                    { // Changes font color for editable cells
                        n.Text = "";
                        n.ForeColor = Color.IndianRed;
                    }
                    else
                    { // Disable given numbers
                        n.Text = game.grid[i, j].ToString();
                        n.Enabled = false;
                    }
                    gridView.Controls.Add(n);
                    gridNumbers[i, j] = n;
                }
            }
            game.generated = true;
        }

        /// <summary>
        /// Solves the current Sudoku after clicking on the button.
        /// </summary>
        /// <param name="sender"> Solve button </param>
        /// <param name="e"> Contains the event data </param>
        private void solveButton_Click(object sender, EventArgs e)
        {
            game.generated = false;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (gridNumbers[i, j].Enabled == true)
                    { // Disable and highlights solved cells
                        gridNumbers[i, j].Enabled = false;
                        gridNumbers[i, j].BackColor = Color.Moccasin;
                    }
                    gridNumbers[i, j].Text = game.gridSolved[i, j].ToString();
                }
            }
        }

        /// <summary>
        /// Create new "easy" game.
        /// </summary>
        /// <param name="sender"> Easy button </param>
        /// <param name="e"> Contains the event data </param>
        private void easyNewGameButton_Click(object sender, EventArgs e)
        {
            newGame("easy");
        }
        /// <summary>
        /// Create new "normal" game.
        /// </summary>
        /// <param name="sender"> Normal button </param>
        /// <param name="e"> Contains the event data </param>
        private void normalNewGameButton_Click(object sender, EventArgs e)
        {
            newGame("normal");
        }
        /// <summary>
        /// Create new "hard" game.
        /// </summary>
        /// <param name="sender"> Hard button </param>
        /// <param name="e"> Contains the event data </param>
        private void hardNewGameButton_Click(object sender, EventArgs e)
        {
            newGame("hard");
        }
    }
}
