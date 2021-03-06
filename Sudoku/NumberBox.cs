﻿using System;
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
        private GUI gui;

        /// <summary>
        /// Constructor of each cells representing a number box. 
        /// </summary>
        /// <param name="x"> Cell's row position </param>
        /// <param name="y"> Cell's column position </param>
        /// <param name="game"> Current game </param>
        /// <param name="gui"> Current GUI </param>
        public NumberBox(int x, int y, Game game, GUI gui)
        {
            this.x = x;
            this.y = y;
            this.game = game;
            this.gui = gui;
            oldValue = "";
            Multiline = true;
            BackColor = System.Drawing.SystemColors.Window;
            BorderStyle = BorderStyle.None;
            Dock = DockStyle.Fill;
            Margin = new Padding(1);
            MaxLength = 1;
            Font = new Font(Font.Name, 12, FontStyle.Bold);
            TextAlign = HorizontalAlignment.Center;
            KeyPress += NumberBox_KeyPress;
            TextChanged += NumberBox_TextChanged;
        }

        /// <summary>
        /// Displays only if inputs are numbers from 1 to 9.
        /// </summary>
        /// <param name="sender"> Key pressed </param>
        /// <param name="e">  Contains the key event data </param>
        private void NumberBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) || e.KeyChar == '0')
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Sets numbers and offers to play again with a harder difficulty level or quit game when the player won.
        /// </summary>
        /// <param name="sender"> Selected cell </param>
        /// <param name="e"> Contains the event data </param>
        private void NumberBox_TextChanged(object sender, EventArgs e)
        {
            NumberBox n = (NumberBox)sender;
            try
            {
                if (n.Text == "")
                {
                    game.resetCell(n.x, n.y);
                }
                else
                {
                    game.setNumber(Int32.Parse(n.Text), n.x, n.y);
                }
                n.oldValue = n.Text;
                if (game.isGridFilled() && game.generated) // Game over, grid filled and correct
                {
                    MessageBox.Show("Bravo ! Vous avez gagné !","Game over", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    game.generated = false;
                    
                    if (MessageBox.Show("Voulez vous jouer à nouveau?", "Play again?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
                    {
                      // Generates harder game if player wants to try again
                      string harderGame;
                      if (game.currentDiff == "easy") harderGame = "normal";
                      else harderGame = "hard";                        
                      gui.newGame(harderGame);
                    }
                    else
                        Application.Exit();
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
