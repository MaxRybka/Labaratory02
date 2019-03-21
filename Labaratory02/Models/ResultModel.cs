using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Labaratory02.Managers;

namespace Labaratory02.Models
{
    class ResultModel
    {

        private Person _person;

        public ResultModel(Person person)
        {
            _person = person;
        }

        public void BackToLogin()
        {
            
            NavigationManager.Instance.Navigate(ModesEnum.Login);
        }
    }
}
