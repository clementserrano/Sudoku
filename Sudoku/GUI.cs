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
        private TableLayoutPanel[,] subgridView;

        public GUI()
        {
            InitializeComponent();
            Resize += GUI_Resize;
        }
        /// <summary>
        /// Creates new "normal" game by default.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GUI_Load(object sender, EventArgs e)
        {
            gridView.Padding = new Padding(2);
            // Create the subgrids in the main TableLayoutPanel
            subgridView = new TableLayoutPanel[3,3];
            for (int i = 0; i < subgridView.GetLength(0); i++)
            {
                for (int j = 0; j < subgridView.GetLength(1); j++)
                {
                    TableLayoutPanel subgrid = new TableLayoutPanel();

                    subgrid.ColumnCount = 3;
                    subgrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
                    subgrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
                    subgrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));

                    subgrid.RowCount = 3;
                    subgrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
                    subgrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
                    subgrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));

                    subgrid.Dock = DockStyle.Fill;
                    subgrid.Margin = new Padding(1);
                    subgrid.Padding = new Padding(0);
                    subgrid.BackColor = System.Drawing.SystemColors.ControlDark;

                    gridView.Controls.Add(subgrid);
                    subgridView[i, j] = subgrid;
                }
            }
            newGame("normal");
        }

        /// <summary>
        /// Generates and displays a valid sudoku game.  
        /// </summary>
        /// <param name="difficulty"> Chosen difficulty </param>
        private void newGame(string difficulty)
        {
            // Clear the subgrid controls
            for (int i = 0; i < subgridView.GetLength(0); i++)
            {
                for (int j = 0; j < subgridView.GetLength(1); j++)
                {
                    subgridView[i, j].Controls.Clear();
                }
            }
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
                    gridNumbers[i, j] = n;
                    // Atttribute the NummberBox to the right subgrid
                    int i2 = 0;
                    int j2 = 0;
                    if (i >= 3 && i < 6) i2 = 1;
                    if (i >= 6) i2 = 2;
                    if (j >= 3 && j < 6) j2 = 1;
                    if (j >= 6) j2 = 2;
                    subgridView[i2, j2].Controls.Add(n);
                }
            }
            game.generated = true;
            GUI_Resize(null, null);
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

        private void GUI_Resize(object sender, EventArgs e)
        {
            int size = (int)(subgridView[0, 0].Controls[0].Height * 0.65);
            foreach (TableLayoutPanel subgrid in subgridView)
            {
                foreach(Control box in subgrid.Controls)
                {

                    box.Font = new Font(box.Font.FontFamily.Name, size);
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
