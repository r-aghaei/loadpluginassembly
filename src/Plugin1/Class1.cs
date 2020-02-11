using PluginCore;
using System;

namespace PluginAssembly1
{
    public class Plugin1 : IPlugin
    {
        public string SayHello()
        {
            var c1 = new DependencyAssembly1.Class1();
            c1.DoSomething();
            return $"Hello from {nameof(Plugin1)}";
        }
    }
}
