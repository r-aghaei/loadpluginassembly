using System;
using System.Diagnostics;

namespace DependencyAssembly2
{
    public class Class2
    {
        public void DoSomething()
        {
            Debug.WriteLine($"{nameof(Class2)}.{nameof(DoSomething)} called.");
        }
    }
}
