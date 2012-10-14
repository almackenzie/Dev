using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.MefExtensions;

namespace BeatportPowerCart.Shell
{
    public class BeatportPowerCartBootstrapper : MefBootstrapper
    {
        protected override System.Windows.DependencyObject CreateShell()
        {
            Shell shell = new Shell();
            shell.Show();
            return shell;
        }


        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
        }

    }
}
