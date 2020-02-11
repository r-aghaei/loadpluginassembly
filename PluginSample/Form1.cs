using PluginCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PluginSample
{
    public partial class Form1 : Form
    {
        FlowLayoutPanel flowLayoutPanel1;
        public Form1()
        {
            InitializeComponent();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel1.Dock = DockStyle.Fill;
            this.Controls.Add(flowLayoutPanel1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            var plugins = new List<IPlugin>();
            var pluginsPath = Path.Combine(Application.StartupPath, "Plugins");
            var referencesPath = Path.Combine(Application.StartupPath, "References");

            var pluginFiles = Directory.GetFiles(pluginsPath, "*.dll", SearchOption.AllDirectories);
            var referenceFiles = Directory.GetFiles(referencesPath, "*.dll", SearchOption.AllDirectories);

            AppDomain.CurrentDomain.AssemblyResolve += (obj, arg) =>
            {
                var name = $"{new AssemblyName(arg.Name).Name}.dll";
                var assemblyFile = referenceFiles.Where(x => x.EndsWith(name))
                    .FirstOrDefault();
                if (assemblyFile != null)
                    return Assembly.LoadFrom(assemblyFile);
                throw new Exception($"'{name}' Not found");
            };

            foreach (var pluginFile in pluginFiles)
            {
                var pluginAssembly = Assembly.LoadFrom(pluginFile);
                var pluginTypes = pluginAssembly.GetTypes().Where(x => typeof(IPlugin).IsAssignableFrom(x));
                foreach (var pluginType in pluginTypes)
                {
                    var plugin = (IPlugin)Activator.CreateInstance(pluginType);
                    var button = new Button() { Text = plugin.GetType().Name };
                    button.Click += (obj, arg) => MessageBox.Show(plugin.SayHello());
                    flowLayoutPanel1.Controls.Add(button);
                }
            }
        }

    }
}
