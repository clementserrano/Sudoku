using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    class Sudoku_Validator
    {
        //Horizontal List
        public TextBox[] txtBox_Array_Horiz_1;
        public TextBox[] txtBox_Array_Horiz_2;
        public TextBox[] txtBox_Array_Horiz_3;
        public TextBox[] txtBox_Array_Horiz_4;
        public TextBox[] txtBox_Array_Horiz_5;
        public TextBox[] txtBox_Array_Horiz_6;
        public TextBox[] txtBox_Array_Horiz_7;
        public TextBox[] txtBox_Array_Horiz_8;
        public TextBox[] txtBox_Array_Horiz_9;

        //Vertical List
        public TextBox[] txtBox_Array_Vert_1;
        public TextBox[] txtBox_Array_Vert_2;
        public TextBox[] txtBox_Array_Vert_3;
        public TextBox[] txtBox_Array_Vert_4;
        public TextBox[] txtBox_Array_Vert_5;
        public TextBox[] txtBox_Array_Vert_6;
        public TextBox[] txtBox_Array_Vert_7;
        public TextBox[] txtBox_Array_Vert_8;
        public TextBox[] txtBox_Array_Vert_9;

        public ArrayList arr_txtBox_Horiz = new ArrayList();
        public ArrayList arr_txtBox_Vert = new ArrayList();
        public ArrayList arr_control = new ArrayList();

        public void txtBox_Array_Add() {
            // Horizontal Array Add
            arr_txtBox_Horiz.Add(txtBox_Array_Horiz_1);
            arr_txtBox_Horiz.Add(txtBox_Array_Horiz_2);
            arr_txtBox_Horiz.Add(txtBox_Array_Horiz_3);
            arr_txtBox_Horiz.Add(txtBox_Array_Horiz_4);
            arr_txtBox_Horiz.Add(txtBox_Array_Horiz_5);
            arr_txtBox_Horiz.Add(txtBox_Array_Horiz_6);
            arr_txtBox_Horiz.Add(txtBox_Array_Horiz_7);
            arr_txtBox_Horiz.Add(txtBox_Array_Horiz_8);
            arr_txtBox_Horiz.Add(txtBox_Array_Horiz_9);

            // Vertical Array Add
            arr_txtBox_Vert.Add(txtBox_Array_Vert_1);
            arr_txtBox_Vert.Add(txtBox_Array_Vert_2);
            arr_txtBox_Vert.Add(txtBox_Array_Vert_3);
            arr_txtBox_Vert.Add(txtBox_Array_Vert_4);
            arr_txtBox_Vert.Add(txtBox_Array_Vert_5);
            arr_txtBox_Vert.Add(txtBox_Array_Vert_6);
            arr_txtBox_Vert.Add(txtBox_Array_Vert_7);
            arr_txtBox_Vert.Add(txtBox_Array_Vert_8);
            arr_txtBox_Vert.Add(txtBox_Array_Vert_9);

        }

        // Check if all numbers on ROW occur once, from 1 to 9.
        //private bool checkRow(int box, string val)
        //{
        //    bool errorFound = true;
        //    int rowIndex = box.ToString.Substring(0, 1);
        //    for (i = 1; i <= 9; i++)
        //    {
        //        if (var("var" + rowIndex + i) == val & (rowIndex + i) != box)
        //        {
        //            errorFound = false;
        //        }
        //    }
        //    return errorFound;
        //}

        // Check if all numbers on COLUMN occur once, from 1 to 9.
        //private bool CheckColumn(int box, string val)
        //{
        //    bool errorFound = true;
        //    int columnIndex = box.ToString.Substring(1, 1);
        //    for (i = 1; i <= 9; i++)
        //    {
        //        if (var("var" + i + columnIndex) == val & (i + columnIndex) != box)
        //        {
        //            errorFound = false;
        //        }
        //    }
        //    return errorFound;
        //}

        public void CheckColumn()
        {
            foreach (TextBox[] txtBox_Vert_Controls in arr_txtBox_Vert)
            {
                foreach (TextBox txtBox_Vert in txtBox_Vert_Controls)
                {
                    string s_txt_Value = txtBox_Vert.Text;
                    foreach (TextBox txtBox_Vert_1 in txtBox_Vert_Controls)
                    {
                        if (txtBox_Vert.Name == txtBox_Vert_1.Name) { continue; }
                        else if (s_txt_Value == txtBox_Vert_1.Text)
                        {
                            if (arr_control.Contains(txtBox_Vert_1) == false) { arr_control.Add(txtBox_Vert_1); }
                        }
                    }
                }
            }
        }

        // Check if all numbers on GRID occur once, from 1 to 9.
        //public bool CheckGrid(int box, string val)
        //{
        //    bool errorFound = true;
        //    int x = box.ToString.Substring(0, 1);
        //    int y = box.ToString.Substring(1, 1);

        //    x = Math.Ceiling(x / 3) - 1;
        //    y = Math.Ceiling(y / 3) - 1;

        //    x = 11 + (30 * x);
        //    y = (y * 3);
        //    for (i1 = 0; i1 <= 2; i1++)
        //    {
        //        for (i = 0; i <= 2; i++)
        //        {
        //            if (var("var" + (x + (i1 * 10)) + y + i) == val & (x + (i1 * 10) + y + i) != box)
        //            {
        //                errorFound = false;
        //            }
        //        }
        //    }
        //    return errorFound;
        //}
    }
}
