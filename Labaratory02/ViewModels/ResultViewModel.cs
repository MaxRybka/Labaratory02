using System;
using System.Windows.Input;
using Labaratory02.Models;
using Labaratory02.Tools;

namespace Labaratory02.ViewModels
{
    class ResultViewModel : ObservableItem
    {
        public readonly ResultModel Model;

        private string _name = String.Empty, _surname = String.Empty, _email = String.Empty , _sunSign = String.Empty , _chineseSign = String.Empty;
        private bool _isAdult , _isBirthday ;
        private DateTime _bornDate;

        private ICommand _backCommand;

        public ResultViewModel(Person person)
        {
            Model = new ResultModel(person);
            ChangePersonInfo(person);
        }

        public void ChangePersonInfo(Person person)
        {
            Name = person.FirstName;
            Surname = person.SecondName;
            Email = person.Email;
            BornDate = person.BornDateTime;

            IsAdult = person.IsAdult;
            SunSign = person.SunSign;
            ChineseSign = person.ChineseSign;
            IsBirthday = person.IsBirthday; 
        }

        public DateTime BornDate
        {
            get { return _bornDate; }
            set
            {
                _bornDate = value;
                OnPropertyChanged("BornDate");
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged("Surname");
            }
        }

        public string Email
        {
            get { return _email; }
            set {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        public bool IsAdult
        {
            get { return _isAdult; }
            set
            {
                _isAdult = value;
                OnPropertyChanged("IsAdult");
            }
        }

        public string SunSign
        {
            get { return _sunSign; }
            set
            {
                _sunSign = value;
                OnPropertyChanged("SunSign");
            }
        }

        public string ChineseSign
        {
            get { return _chineseSign; }
            set
            {
                _chineseSign = value;
                OnPropertyChanged("ChineseSign");
            }
        }

        public bool IsBirthday
        {
            get { return _isBirthday; }
            set {
                _isBirthday = value;
                OnPropertyChanged("IsBirthday");
            }
        }

        public ICommand BackCommand
        {
            get
            {
                if (_backCommand == null)
                {
                    _backCommand = new RelayCommand<object>(ResultExecute, ResultCanExecute);
                }

                return _backCommand;
            }
            set { ChangeAndNotify(ref _backCommand, value, () => BackCommand); }
        }

        private void ResultExecute(object obj)
        {
            Model.BackToLogin();
        }

        private bool ResultCanExecute(object obj)
        {
            return true;
        }

    }
}
