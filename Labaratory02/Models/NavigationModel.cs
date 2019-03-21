using System;
using System.Windows;
using Labaratory02.Views;

namespace Labaratory02.Models
{

    public enum ModesEnum
    {
        Login,
        Result
    }

    class NavigationModel
    {
        private MainWindow _mainWindow;
        private LoginView _loginView;
        private ResultView _resultView;


        public NavigationModel(MainWindow mainWindow, Person person)
        {
            _mainWindow = mainWindow;
            _loginView = new LoginView(person);
            _resultView = new ResultView(person);
        }

        public void Navigate(ModesEnum mode)
        {
            switch (mode)
            {
                case ModesEnum.Login:
                    
                    _mainWindow.ContentControl.Content = _loginView;
                    break;
                case ModesEnum.Result:
                    _mainWindow.ContentControl.Content = _resultView;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }

        public void LoadResult(Person person)
        {
            _resultView.ChangeInfo(person);
        }
    }
}
