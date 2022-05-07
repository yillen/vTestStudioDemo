using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PythonLib;

namespace testApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IronPy py = new IronPy();
            py.runPy();
            Console.ReadLine();
        }
    }
}
