using PluginCore;
using System;

namespace PluginAssembly2
{
    public class Plugin2 : IPlugin
    {
        public string SayHello()
        {
            var c1 = new DependencyAssembly1.Class1();
            var c2 = new DependencyAssembly2.Class2();
            c1.DoSomething();
            c2.DoSomething();
            return $"Hello from {nameof(Plugin2)}";
        }
    }
}
