using System;
using System.Collections.ObjectModel;
using System.Reflection;
using Vector.Tools;
using Vector.CANoe.Runtime;
using Vector.CANoe.Threading;
using Vector.Diagnostics;
using Vector.Scripting.UI;
using Vector.CANoe.TFS;
using Vector.CANoe.VTS;
using NetworkDB;
using PythonLib;

[TestClass]
public class IPCP
{
  static IronPy py;
  
  [Export] [TestCase]
  public static void MyTestCase()
  {
    // Your implementation here...
    
      // assign system variables at least once before using it in a task (implicit initialization must not be done in task)
     // SVs.IntSV.Value = 0;  
  }

  [Export]  [TestFunction]
  public static void init_ipcp()
  {
    //Report.TestStep(System.IO.Directory.GetCurrentDirectory());
     
    try{
      //   Assembly assembly = Assembly.LoadFile("IronPython.dll");
      //   Report.TestStep(assembly.Location);
      
      //  Type type = assembly.GetType("IronPython.Hosting.Python");
      py = new IronPy();
   
      //Report.TestStep(py.getAssembly());
      Report.TestStep(py.getCurrentDirectory());
      string array = py.runPy();
      Report.TestStep(array);
    }
    catch(Exception e){
      Report.TestStep(e.Message);
      Report.TestStepFail(string.Format("Exception {0}", e.Message));
      Execution.Wait(1000);
    }
    
  }
  
  [Export]  [TestFunction]
  public static void exit_ipcp()
  {

  }

}