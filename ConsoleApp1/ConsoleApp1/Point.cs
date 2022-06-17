using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class Point
    {
        private int row;
        public int col;

        public int Row { get { return row; } set { row = value; } }
        public int Col { get { return col; } set { col = value; } }
        public Point(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }


}

