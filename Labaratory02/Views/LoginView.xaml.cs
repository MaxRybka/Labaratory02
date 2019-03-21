using System;
using System.Windows.Controls;
using Labaratory02.Models;
using Labaratory02.ViewModels;

namespace Labaratory02.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        private LoginViewModel _loginViewModel;

        public LoginView(Person person)
        {
            InitializeComponent();
            _loginViewModel = new LoginViewModel(person);
            DataContext = _loginViewModel;
        }
    }
}
