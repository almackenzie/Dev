using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Microsoft.Practices.Prism.MefExtensions;

namespace BeatportPowerCart.Shell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            BeatportPowerCartBootstrapper bootStrapper = new BeatportPowerCartBootstrapper();
            bootStrapper.Run();
        }
    }

    

}
