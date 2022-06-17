using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class SubMarine
    {
        protected int length;
        private int numOfHits;
        private bool isSunk;
        public Type Type { get; set; }

        public int Length { get { return length; } }
        public int NumOfHits { get { return numOfHits; } set { numOfHits = value; } }
        public bool IsSunk { get { return numOfHits >= length; } }


    }
}
