using ConnectingWall.Module.UI.Game;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectingWall.Shell
{
    public class ConnectingWallBootstrapper : UnityBootstrapper
    {
        protected override System.Windows.DependencyObject CreateShell()
        {
            Shell shell = new Shell();
            shell.Show();
            return shell;
        }

        protected override void ConfigureModuleCatalog()
        {
            //ModuleCatalog = new ModuleCatalog();

            ModuleCatalog.AddModule(new ModuleInfo("GameModule", typeof(GameModule).AssemblyQualifiedName));

        }

    }
}
