using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ConnectingWall.Shell.Startup;

namespace ConnectingWall.Shell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private SplashView _splashView;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _splashView = new SplashView() {DataContext = new SplashViewModel()};
            _splashView.Show();
            
            new ConnectingWallBootstrapper(this).Run();
        }

        internal void OnBeforeShellDisplayed()
        {
            _splashView.Close();
        }

    }
}
