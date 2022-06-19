using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
     class SubMarine
    {
       
        private int numOfHits;
        private bool isSunk;
        public List<SubmarineCell> SubmarineCells { get; set; }
        private Type type; 

        public int Length {
            get { if (type == Type.subMarine1) return 1;
                if (type == Type.subMarine2) return 2;
                if (type == Type.subMarine3) return 3;
                return 4;
            } }
        public int NumOfHits { get { return numOfHits; } set { numOfHits = value; } }
        public bool IsSunk { get { return numOfHits >= Length; } }
        public Type Type { get { return type; } }

        public SubMarine(Type type)
        {
            this.type = type;
            SubmarineCells = new List<SubmarineCell>();
        }
        public  void Build_Vertical(SubmarineCell cell)
        {
            for (int i = cell.Row; i < cell.Row + Length; i++)
                SubmarineCells.Add(new SubmarineCell(i, cell.Col, cell.Type));

        }
        public  void Build_Horizontal(SubmarineCell cell)
        {
            for (int i = cell.Col; i < cell.Col + Length; i++)
                SubmarineCells.Add(new SubmarineCell(cell.Row, i, cell.Type));

        }

    }
}