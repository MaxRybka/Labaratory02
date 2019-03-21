using System;
using System.Windows.Input;
using Labaratory02.Models;
using Labaratory02.Tools;

namespace Labaratory02.ViewModels
{
    class LoginViewModel : ObservableItem
    {

        private DateTime _selectedDate = DateTime.Now;
        private String _selectedName = String.Empty;
        private String _selectedSurname = String.Empty;
        private String _selectedEmail = String.Empty;

        private readonly LoginModel LoginModel;
        private ICommand _confirmCommand;

        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set { ChangeAndNotify(ref _selectedDate, value, () => SelectedDate); }
        }

        public string SelectedName
        {
            get { return _selectedName; }
            set { ChangeAndNotify(ref _selectedName, value, () => SelectedName); }
        }

        public string SelectedSurname
        {
            get { return _selectedSurname; }
            set { ChangeAndNotify(ref _selectedSurname, value, () => SelectedSurname); }
        }

        public string SelectedEmail
        {
            get { return _selectedEmail; }
            set { ChangeAndNotify(ref _selectedEmail, value, () => SelectedEmail); }
        }

        public LoginViewModel(Person person)
        {
            LoginModel = new LoginModel(person);
        }

        public ICommand ConfirmCommand
        {
            get
            {
                if (_confirmCommand == null)
                {
                    _confirmCommand = new RelayCommand<object>(StartExecute, StartCanExecute);
                }

                return _confirmCommand;
            }
            set { ChangeAndNotify(ref _confirmCommand, value, () => ConfirmCommand); }
        }

        private void StartExecute(object obj)
        {
            LoginModel.CheckDate(SelectedName , SelectedSurname , SelectedEmail, SelectedDate);
        }

        private bool StartCanExecute(object obj)
        {
            return (!string.IsNullOrWhiteSpace(_selectedName) && !string.IsNullOrWhiteSpace(_selectedSurname) && !string.IsNullOrWhiteSpace(_selectedEmail));
        }

    }
}
