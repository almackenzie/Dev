using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectingWall.Module.UI.Game.ViewModels
{
    public class GameViewModel : NotificationObject
    {

        private IUnityContainer _container;

        public GameViewModel(IUnityContainer container)
        {
            _container = container;
            Title = "Game " + DateTime.Now;

        }

        public string Title { get; set; }
        

    }
}
