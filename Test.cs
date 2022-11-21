using System;
using System.Collections.Generic;
using System.Text;

namespace Testparser
{
    class Test
    {
        public struct sss
        {
            public int x;
        }

       
        public int aaa = 3;
        public int test()
        {
            var x = new List<sss> { new sss{ x = 32 }, new sss { x = 34 } };
            return aaa + 3 * 4 + test2(3) / 2 & 55;
        }
        public int test2(int x)
        {
            return x + 5;
        }
    }
}
