using System.Threading;
using ConnectingWall.Common.Interfaces;
using ConnectingWall.Common.Services;
using ConnectingWall.Module.UI.Game;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace ConnectingWall.Shell
{
    public class ConnectingWallBootstrapper : UnityBootstrapper
    {
        private App _app;

        public ConnectingWallBootstrapper(App app)
        {
            _app = app;
        }

        protected override System.Windows.DependencyObject CreateShell()
        {
            Shell shell = new Shell();
            _app.OnBeforeShellDisplayed();
            shell.Show();
            return shell;
        }

        protected override void ConfigureModuleCatalog()
        {
            Thread.Sleep(2000);
            ModuleCatalog.AddModule(new ModuleInfo("GameModule", typeof(GameModule).AssemblyQualifiedName));
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterType<IGroupDefinitionService, GroupDefinitionService>();
        }

    }
}
