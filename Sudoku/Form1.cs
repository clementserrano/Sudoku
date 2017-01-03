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
        Sudoku_Validator validate = new Sudoku_Validator();


        public GUI()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Horizontal List            
            validate.txtBox_Array_Horiz_1 = new TextBox[] { textBox1, textBox4, textBox7, textBox18, textBox15, textBox12, textBox27, textBox24, textBox21 };
            validate.txtBox_Array_Horiz_2 = new TextBox[] { textBox2, textBox5, textBox8, textBox17, textBox14, textBox11, textBox26, textBox23, textBox20 };
            validate.txtBox_Array_Horiz_3 = new TextBox[] { textBox3, textBox6, textBox9, textBox16, textBox13, textBox10, textBox25, textBox22, textBox19 };
            validate.txtBox_Array_Horiz_4 = new TextBox[] { textBox36, textBox33, textBox30, textBox45, textBox42, textBox39, textBox54, textBox51, textBox48 };
            validate.txtBox_Array_Horiz_5 = new TextBox[] { textBox35, textBox32, textBox29, textBox44, textBox41, textBox38, textBox53, textBox50, textBox47 };
            validate.txtBox_Array_Horiz_6 = new TextBox[] { textBox34, textBox31, textBox28, textBox43, textBox40, textBox37, textBox52, textBox49, textBox46 };
            validate.txtBox_Array_Horiz_7 = new TextBox[] { textBox63, textBox60, textBox57, textBox72, textBox69, textBox66, textBox81, textBox78, textBox75 };
            validate.txtBox_Array_Horiz_8 = new TextBox[] { textBox62, textBox59, textBox56, textBox71, textBox68, textBox65, textBox80, textBox77, textBox74 };
            validate.txtBox_Array_Horiz_9 = new TextBox[] { textBox61, textBox58, textBox55, textBox70, textBox67, textBox64, textBox79, textBox76, textBox73 };

            //Vertical List
            validate.txtBox_Array_Vert_1 = new TextBox[] { textBox1, textBox2, textBox3, textBox36, textBox35, textBox34, textBox63, textBox62, textBox61 };
            validate.txtBox_Array_Vert_2 = new TextBox[] { textBox4, textBox5, textBox6, textBox33, textBox32, textBox31, textBox60, textBox59, textBox58 };
            validate.txtBox_Array_Vert_3 = new TextBox[] { textBox7, textBox8, textBox9, textBox30, textBox29, textBox28, textBox57, textBox56, textBox55 };
            validate.txtBox_Array_Vert_4 = new TextBox[] { textBox18, textBox17, textBox16, textBox45, textBox44, textBox43, textBox72, textBox71, textBox70 };
            validate.txtBox_Array_Vert_5 = new TextBox[] { textBox15, textBox14, textBox13, textBox42, textBox41, textBox40, textBox69, textBox68, textBox67 };
            validate.txtBox_Array_Vert_6 = new TextBox[] { textBox12, textBox11, textBox10, textBox39, textBox38, textBox37, textBox66, textBox65, textBox64 };
            validate.txtBox_Array_Vert_7 = new TextBox[] { textBox27, textBox26, textBox25, textBox54, textBox53, textBox52, textBox81, textBox80, textBox79 };
            validate.txtBox_Array_Vert_8 = new TextBox[] { textBox24, textBox23, textBox22, textBox51, textBox50, textBox49, textBox78, textBox77, textBox76 };
            validate.txtBox_Array_Vert_9 = new TextBox[] { textBox21, textBox20, textBox19, textBox48, textBox47, textBox46, textBox75, textBox74, textBox73 };

            validate.txtBox_Array_Add();

            //validate.ctrl_Tab_Change();

            //grp_Text_Change();

            //btn_New_Click(sender, e);
        }

        //Allow only number between 1 and 9 to be entered 
        public void txtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsLetter(e.KeyChar)) || (char.IsWhiteSpace(e.KeyChar)) || (char.IsPunctuation(e.KeyChar)) || (char.IsSeparator(e.KeyChar)) || (char.IsSurrogate(e.KeyChar)) || (char.IsSymbol(e.KeyChar)) || (e.KeyChar == '0'))
            {
                e.Handled = true;
            }
        }



        // Check for solution
        private void solveSudoku(object sender, EventArgs e)
        {

        }

       
    }
}
