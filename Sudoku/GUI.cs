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
        private NumberBox[,] gridNumber;

        public GUI()
        {
            InitializeComponent();
            game = new Sudoku.Game("normal");
        }

        private void GUI_Load(object sender, EventArgs e)
        {
            gridNumber = new NumberBox[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    NumberBox n = new NumberBox(i,j);
                    n.Multiline = true;
                    n.Dock = DockStyle.Fill;
                    n.MaxLength = 1;
                    n.Font = new Font(n.Font.Name, 12, FontStyle.Bold);
                    n.TextAlign = HorizontalAlignment.Center;
                    n.TextChanged += textBoxNumber_TextChanged;
                    n.KeyPress += textBoxNumber_KeyPress;
                    if (game.getGrid()[i, j] == 0) { 
                        n.Text = "";
                        n.ForeColor = System.Drawing.Color.IndianRed;
                        n.BackColor = System.Drawing.Color.Cornsilk;
                    } else
                    {
                        n.Text = game.getGrid()[i, j].ToString();
                        n.Enabled = false;
                    }
                    gridView.Controls.Add(n);
                    gridNumber[i, j] = n;
                }
            }
            game.unlock();
        }

        // TextBox behaviour when a key is pressed
        private void textBoxNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) || e.KeyChar == '0')
            {
                e.Handled = true;
            }
        }

        private void textBoxNumber_TextChanged(object sender, EventArgs e)
        {
            NumberBox n = (NumberBox)sender;
            try
            {
                if (n.Text == "")
                {
                    game.setNumber(0, n.getX(), n.getY());
                }
                else
                {
                    game.setNumber(Int32.Parse(n.Text), n.getX(), n.getY());
                }
                n.setOldValue(n.Text);
                if (game.isGridFilled())
                {
                    MessageBox.Show("Bravo ! Vous avez gagné !");
                }
            }
            catch (SudokuException error)
            {
                MessageBox.Show(error.Message);
                n.Text = n.getOldValue();
            } catch(FormatException) { /*a FormatException is throwned but we ignored it*/ }
        }
    }
}
