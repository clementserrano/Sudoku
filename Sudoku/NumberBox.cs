using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    class NumberBox : TextBox
    {
        private int x;
        private int y;
        private String oldValue;

        public NumberBox(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.oldValue = "";
        }

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

        public String getOldValue()
        {
            return oldValue;
        }

        public void setOldValue(String value)
        {
            oldValue = value;
        }
    }
}
