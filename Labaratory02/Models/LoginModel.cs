using System;
using System.Net.Mail;
using System.Windows;
using Labaratory02.Managers;

namespace Labaratory02.Models
{
    class LoginModel
    {

        private Person _person;
        private readonly DateTime _periodFrom;


        public LoginModel(Person person)
        {
            _person = person;

            _periodFrom = new DateTime(DateTime.Now.Year - 135, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        }

        public bool CheckInput(string firstName, string secondName, string email, DateTime bornDateTime)
        {
            

            if (!ValidDate(bornDateTime))
            {
                MessageBox.Show("The date is invalid");
                return false;
            }

            if (!ValidEmail(email))
            {
                MessageBox.Show("The email is invalid");
                return false;
            }

            _person = new Person(firstName, secondName, email, bornDateTime);

            NavigationManager.Instance.LoadResult(_person);
            NavigationManager.Instance.Navigate(ModesEnum.Result);

            if (_person.IsBirthday)
                MessageBox.Show("Happy Birthday!!!");

            return true;
        }

        private bool ValidDate(DateTime date)
        {
            return date > _periodFrom && date <= DateTime.Now;
        }

        private bool ValidEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }

    
}
