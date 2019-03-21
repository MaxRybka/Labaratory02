using System;
using System.Windows;
using System.Windows.Input;
using Labaratory02.Models;
using Labaratory02.Tools;
using Labaratory02.Views;

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
            ChangePersonInfo(person);
            Model = new ResultModel(person);
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
            set { ChangeAndNotify(ref _bornDate, value, () => BornDate); }
        }

        public string Name
        {
            get { return _name; }
            set { ChangeAndNotify(ref _name, value, () => Name); }
        }

        public string Surname
        {
            get { return _surname; }
            set { ChangeAndNotify(ref _surname, value, () => Surname); }
        }

        public string Email
        {
            get { return _email; }
            set { ChangeAndNotify(ref _email, value, () => Email); }
        }

        public bool IsAdult
        {
            get { return _isAdult; }
            set { ChangeAndNotify(ref _isAdult, value, () => IsAdult); }
        }

        public string SunSign
        {
            get { return _sunSign; }
            set { ChangeAndNotify(ref _sunSign, value, () => SunSign); }
        }

        public string ChineseSign
        {
            get { return _chineseSign; }
            set { ChangeAndNotify(ref _chineseSign, value, () => ChineseSign); }
        }

        public bool IsBirthday
        {
            get { return _isBirthday; }
            set { ChangeAndNotify(ref _isBirthday, value, () => IsBirthday); }
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
