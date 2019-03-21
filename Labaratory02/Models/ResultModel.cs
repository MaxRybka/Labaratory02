
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
