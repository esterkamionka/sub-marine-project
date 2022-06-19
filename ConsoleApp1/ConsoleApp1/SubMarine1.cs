using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class SubMarine1 : SubMarine
    {
        public SubMarine1()
        {
            length = 1;
            Type = Type.subMarine1;
            SubmarineCells = new List<SubmarineCell>();
        }
        public override void Build_Vertical(SubmarineCell cell)
        {
            SubmarineCells.Add(cell);
            
        }
        public override void Build_Horizontal(SubmarineCell cell)
        {
            SubmarineCells.Add(cell);
           
        }
    }
   
    

 
   
}
