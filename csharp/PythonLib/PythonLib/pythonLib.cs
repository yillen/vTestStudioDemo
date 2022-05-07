using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using IronPython;
using Microsoft.Scripting.Hosting;
using System.Reflection;

namespace PythonLib
{
    public class IronPy
    {
        public string reStr;

        ScriptEngine pyEngine;
        public IronPy()
        {
            //  List<string> path = new List<string>();
            //  path.Add(@"D:\ECU_Simulator\csharp\udpService\packages\IronPython.2.7.11\lib\net45");
            //  AddEnvironmentPaths(path);
            //  Assembly assembly = Assembly.Load(new AssemblyName("IronPython"));
            //  Assembly assembly = Assembly.LoadFile("IronPython.dll");
            //  Console.WriteLine(assembly.Location);

            //  Type type = assembly.GetType("IronPython.Hosting.Python");
            //  var instance = (IronPython.Hosting.Python)Activator.CreateInstance(type);
            //  instance.Print();
        }
        public string runPy()
        {
            pyEngine = IronPython.Hosting.Python.CreateEngine();//创建Python解释器对象

            dynamic py = pyEngine.ExecuteFile("IronPythonDemo2.py");

            int[] array = new int[9] { 9, 3, 5, 7, 2, 1, 3, 6, 8 };
            reStr = py.main(array);//调用脚本文件中对应的函数
            Console.WriteLine(reStr);

            return reStr;

            // Assembly assembly = Assembly.Load(new AssemblyName("IronPython"));
            // Console.WriteLine(assembly.Location);
        }

        public string getCurrentDirectory()
        {
            return Environment.CurrentDirectory;
        }

        public string getAssembly()
        {
            Assembly assembly = Assembly.LoadFrom(@"D:\ECU_Simulator\testPython\canoe\IronPython.dll");
            if (assembly != null)
                return assembly.Location;
            else
                return "empty";
        }

        public string runAssemblyPy()
        {
            Assembly assembly = Assembly.LoadFrom(@"D:\ECU_Simulator\testPython\canoe\IronPython.dll");
            Type type = assembly.GetType("IronPython.Hosting.Python");
            Type[] collection = assembly.GetTypes();
            foreach (Type item in collection)
            {
                Console.WriteLine(item.FullName.ToString());
            }

            //Object obj = Activator.CreateInstance(type);
            MethodInfo methodInfo = type.GetMethod("CreateEngine"); 
            pyEngine = (ScriptEngine)methodInfo.Invoke(null, null);

            dynamic py = pyEngine.ExecuteFile("IronPythonDemo2.py");

            int[] array = new int[9] { 9, 3, 5, 7, 2, 1, 3, 6, 8 };
            reStr = py.main(array);//调用脚本文件中对应的函数
            Console.WriteLine(reStr);

            return reStr;
        }


        static void AddEnvironmentPaths(IEnumerable<string> paths)
        {
            var path = new[] { Environment.GetEnvironmentVariable("PATH") ?? string.Empty };

            string newPath = string.Join(Path.PathSeparator.ToString(), path.Concat(paths));
            Environment.SetEnvironmentVariable("PATH", newPath);
        }

        public void taskPy()
        {
           // Thread vThread = new Thread(runPy);
            //vThread.Name = "td_Name"; // 线程名称
           // vThread.Start();
        }
    }
}
