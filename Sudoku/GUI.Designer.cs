namespace Sudoku
{
    partial class GUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newGameButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.easyNewGameButton = new System.Windows.Forms.ToolStripMenuItem();
            this.normalNewGameButton = new System.Windows.Forms.ToolStripMenuItem();
            this.hardNewGameButton = new System.Windows.Forms.ToolStripMenuItem();
            this.solveButton = new System.Windows.Forms.ToolStripButton();
            this.gridView = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameButton,
            this.solveButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(304, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newGameButton
            // 
            this.newGameButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.newGameButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.easyNewGameButton,
            this.normalNewGameButton,
            this.hardNewGameButton});
            this.newGameButton.Image = ((System.Drawing.Image)(resources.GetObject("newGameButton.Image")));
            this.newGameButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(78, 22);
            this.newGameButton.Text = "New Game";
            // 
            // easyNewGameButton
            // 
            this.easyNewGameButton.Name = "easyNewGameButton";
            this.easyNewGameButton.Size = new System.Drawing.Size(152, 22);
            this.easyNewGameButton.Text = "Easy";
            this.easyNewGameButton.Click += new System.EventHandler(this.easyNewGameButton_Click);
            // 
            // normalNewGameButton
            // 
            this.normalNewGameButton.Name = "normalNewGameButton";
            this.normalNewGameButton.Size = new System.Drawing.Size(152, 22);
            this.normalNewGameButton.Text = "Normal";
            this.normalNewGameButton.Click += new System.EventHandler(this.normalNewGameButton_Click);
            // 
            // hardNewGameButton
            // 
            this.hardNewGameButton.Name = "hardNewGameButton";
            this.hardNewGameButton.Size = new System.Drawing.Size(152, 22);
            this.hardNewGameButton.Text = "Hard";
            this.hardNewGameButton.Click += new System.EventHandler(this.hardNewGameButton_Click);
            // 
            // solveButton
            // 
            this.solveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.solveButton.Image = ((System.Drawing.Image)(resources.GetObject("solveButton.Image")));
            this.solveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(39, 22);
            this.solveButton.Text = "Solve";
            this.solveButton.Click += new System.EventHandler(this.solveButton_Click);
            // 
            // gridView
            // 
            this.gridView.AutoSize = true;
            this.gridView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gridView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(79)))), ((int)(((byte)(0)))));
            this.gridView.ColumnCount = 9;
            this.gridView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.gridView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.gridView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.gridView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.gridView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.gridView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.gridView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.gridView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.gridView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.gridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridView.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridView.Location = new System.Drawing.Point(0, 25);
            this.gridView.Margin = new System.Windows.Forms.Padding(2);
            this.gridView.Name = "gridView";
            this.gridView.RowCount = 9;
            this.gridView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.gridView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.gridView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.gridView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.gridView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.gridView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.gridView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.gridView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.gridView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.gridView.Size = new System.Drawing.Size(304, 289);
            this.gridView.TabIndex = 1;
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(304, 314);
            this.Controls.Add(this.gridView);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GUI";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Sudoku";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.GUI_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton newGameButton;
        private System.Windows.Forms.ToolStripButton solveButton;
        private System.Windows.Forms.TableLayoutPanel gridView;
        private System.Windows.Forms.ToolStripMenuItem easyNewGameButton;
        private System.Windows.Forms.ToolStripMenuItem normalNewGameButton;
        private System.Windows.Forms.ToolStripMenuItem hardNewGameButton;
    }
}