using System;
using System.Diagnostics;

namespace DependencyAssembly1
{
    public class Class1
    {
        public void DoSomething()
        {
            Debug.WriteLine($"{nameof(Class1)}.{nameof(DoSomething)} called.");
        }
    }
}
