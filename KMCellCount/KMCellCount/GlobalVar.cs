using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMCellCount
{
    class GlobalVar
    {
        private static string someString = "Hello, world!";
        public static string SomeString
        {
            get { return someString; }
            set { someString = value; }
        }
    }
}
