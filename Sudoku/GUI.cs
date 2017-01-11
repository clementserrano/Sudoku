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

        private void GUI_Load(object sender, EventArgs e)
        {
            newGame("normal");
        }

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
                    {
                        n.Text = "";
                        n.ReadOnly = false;
                        n.ForeColor = Color.Red;
                    }
                    else
                    {
                        n.Text = game.grid[i, j].ToString();
                    }
                    gridView.Controls.Add(n);
                    gridNumbers[i, j] = n;
                }
            }
            game.generated = true;
        }

        private void solveButton_Click(object sender, EventArgs e)
        {
            game.generated = false;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    gridNumbers[i,j].Text = game.gridSolved[i, j].ToString();
                }
            }
        }

        private void easyNewGameButton_Click(object sender, EventArgs e)
        {
            newGame("easy");
        }

        private void normalNewGameButton_Click(object sender, EventArgs e)
        {
            newGame("normal");
        }

        private void hardNewGameButton_Click(object sender, EventArgs e)
        {
            newGame("hard");
        }
    }
}
