using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Labaratory02.Models;

namespace Labaratory02.Managers
{
    class NavigationManager
    {
        private static NavigationManager _instance;
        private static object _lock = new object();
        private NavigationModel _navigationModel;

        public static NavigationManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    {
                        lock (_lock)
                        {
                            _instance = new NavigationManager();
                        }
                    }
                }

                return _instance;
            }
        }

        public void Initialize(NavigationModel navigationModel)
        {
            _navigationModel = navigationModel;
        }

        public void Navigate(ModesEnum mode)
        {
            _navigationModel?.Navigate(mode);
        }

        public void LoadResult(Person person)
        {
            _navigationModel?.LoadResult(person);
        }
    }
}
