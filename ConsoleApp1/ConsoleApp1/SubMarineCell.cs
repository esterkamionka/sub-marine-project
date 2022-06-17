using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class SubmarineCell : Point
    {
        public Type Type { get; }
        private bool isSunk;

        public bool IsSunk { get { return isSunk; } set { isSunk = value; } }
        public SubmarineCell(int x, int y, Type type)
            : base(x, y)
        {
            this.Type = type;
            isSunk = false;
        }
        public override string ToString()
        {
            return " * ";
        }
    }
}
