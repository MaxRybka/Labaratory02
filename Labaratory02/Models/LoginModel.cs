using System;
using System.Net.Mail;
using System.Windows;
using Labaratory02.Exceptions;
using Labaratory02.Managers;
using Labaratory02.ViewModels;

namespace Labaratory02.Models
{
    class LoginModel
    {

        private Person _person;
        private LoginViewModel _loginViewModel;
        private readonly DateTime _periodFrom;


        public LoginModel(Person person , LoginViewModel loginViewModel)
        {
            _person = person;
            _loginViewModel = loginViewModel;
            _periodFrom = new DateTime(DateTime.Now.Year - 135, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        }

        public bool ValidateInput(string firstName, string secondName, string email, DateTime bornDateTime)
        {

            try
            {
                ValidateDate(bornDateTime); 
                ValidateEmail(email);
  
                _person = new Person(firstName, secondName, email, bornDateTime);

                NavigationManager.Instance.LoadResult(_person);
                NavigationManager.Instance.Navigate(ModesEnum.Result);

                if (_person.IsBirthday)
                    MessageBox.Show("Happy Birthday!!!");

                return true;
            }
            catch(Exception e)
            {
                _loginViewModel.ShowInvalidInputMessage(e);
                return false;
            }

        }

        private void ValidateDate(DateTime date)
        {
            if (date <= _periodFrom) throw new InvalidAgeException();

            if (date > DateTime.Now) throw new InvalidDateException();

        }

        private void ValidateEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);

            }
            catch (FormatException)
            {
                throw new InvalidEmailException();
    
            }
        }
    }

    
}
