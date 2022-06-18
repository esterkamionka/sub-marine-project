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
        }
    }
    class Submarine2 : SubMarine
    {
        public Submarine2()
        {
            length = 2;
            Type = Type.subMarine2;
        }
    }
    class Submarine3 : SubMarine
    {
        public Submarine3()
        {
            length = 3;
            Type = Type.subMarine3;
        }

    }
    class Submarine4 : SubMarine
    {
        public Submarine4()
        {
            length = 4;
            Type = Type.subMarine4;
        }
    }
}
