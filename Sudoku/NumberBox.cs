using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    class NumberBox : TextBox
    {
        public int x { get; }
        public int y { get; }
        public String oldValue { get; set; }
        private Game game;

        public NumberBox(int x, int y, Game game)
        {
            this.x = x;
            this.y = y;
            this.game = game;
            oldValue = "";
            Multiline = true;
            BackColor = System.Drawing.SystemColors.Window;
            Dock = DockStyle.Fill;
            MaxLength = 2;
            Font = new Font(Font.Name, 12, FontStyle.Bold);
            TextAlign = HorizontalAlignment.Center;
            KeyPress += NumberBox_KeyPress;
            TextChanged += NumberBox_TextChanged;
        }

        private void NumberBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) || e.KeyChar == '0')
            {
                e.Handled = true;
            }
        }

        private void NumberBox_TextChanged(object sender, EventArgs e)
        {
            NumberBox n = (NumberBox)sender;
            try
            {
                if (n.Text == "")
                {
                    game.setNumber(0, n.x, n.y);
                }
                else
                {
                    game.setNumber(Int32.Parse(n.Text), n.x, n.y);
                }
                n.oldValue = n.Text;
                if (game.isGridFilled() && game.generated)
                {
                    MessageBox.Show("Bravo ! Vous avez gagné !");
                }
            }
            catch (SudokuException error)
            {
                MessageBox.Show(error.Message);
                n.Text = n.oldValue;
            }
            catch (FormatException) { /* A FormatException is throwned but we ignored it */ }
        }
    }
}
