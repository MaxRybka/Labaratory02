using System.Windows.Controls;
using Labaratory02.Models;
using Labaratory02.ViewModels;

namespace Labaratory02.Views
{
    /// <summary>
    /// Логика взаимодействия для ResultView.xaml
    /// </summary>
    public partial class ResultView : UserControl
    {

        private Person _person;
        private ResultViewModel _resultViewModel;

        public ResultView()
        {
            InitializeComponent();
        }

        public ResultView(Person person)
        {
            InitializeComponent();
            _resultViewModel = new ResultViewModel(person);
            DataContext = _resultViewModel;
        }

        public void ChangeInfo(Person person)
        {
            InitializeComponent();
            _resultViewModel.ChangePersonInfo(person);//For some reason _resultViewModel.ChangePersonInfo(person) don't change the text blocks
            DataContext = _resultViewModel;
        }

    }
}
