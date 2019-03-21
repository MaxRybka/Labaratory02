using System.Windows;
using Labaratory02.Managers;
using Labaratory02.Models;

namespace Labaratory02
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow mainWindow = new MainWindow();
            Person person = new Person();
            NavigationModel navigationModel = new NavigationModel(mainWindow, person);
            NavigationManager.Instance.Initialize(navigationModel);
            mainWindow.Show();
            navigationModel.Navigate(ModesEnum.Login);
        }
    }
}
