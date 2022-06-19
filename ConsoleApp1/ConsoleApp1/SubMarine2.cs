using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Submarine2 : SubMarine
    {
        public Submarine2()
        {
            length = 2;
            Type = Type.subMarine2;
            SubmarineCells = new List<SubmarineCell>();
        }
        public override void Build_Vertical(SubmarineCell cell)
        {
            for (int i = cell.Row; i < cell.Row + length; i++)
                SubmarineCells.Add(new SubmarineCell(i, cell.Col, Type));

        }
        public override void Build_Horizontal(SubmarineCell cell)
        {
            for (int i = cell.Col; i < cell.Col + length; i++)
                SubmarineCells.Add(new SubmarineCell(cell.Row, i, Type));

        }
    }
}
