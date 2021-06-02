using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;
using TriviaXamarinApp.Models;
using TriviaXamarinApp.Services;
using System.Threading.Tasks;
using TriviaXamarinApp.ViewModel;
using TriviaXamarinApp.Views;

namespace TriviaXamarinApp.ViewModel
{
    class SignUpViewModel : ViewModelBase
    {
        private string nickName;
        private string email;
        private string pass;
        private List<AmericanQuestion> questions;
        private TriviaWebAPIProxy proxy;

        public string NickName
        {
            get => nickName;
            set
            {
                if (value != nickName)
                {
                    nickName = value;
                    OnPropertyChanged("NickName");
                }
            }
        }

        public string Email
        {
            get => email;
            set
            {
                if (value != email)
                {
                    email = value;
                    OnPropertyChanged("Email");
                }
            }
        }

        public string Pass
        {
            get => pass;
            set
            {
                if (value != pass)
                {
                    pass = value;
                    OnPropertyChanged("Pass");
                }
            }
        }

        //לא בטוח שנכון אולי לשים בפעולה בונה ושם לאתחל
        public List<AmericanQuestion> Questions
        {
            get => questions;
            set
            {
                questions = null;
            }
        }

        public ICommand SignUpCommand { get; }
        public event Action<Page> Push;

        public SignUpViewModel()
        {
            proxy = TriviaWebAPIProxy.CreateProxy();
            //command which updates all user's info using User constructor and then sends it to the RegisterUser func in Services folder
            SignUpCommand = new Command(SignUp);

        }


        private async void SignUp()
        {
            bool isReturned = false;
            User u = new User {Email=Email, Password=Pass, NickName=NickName};

            isReturned = await proxy.RegisterUser(u);

            if (isReturned ==false)
            {
                await Application.Current.MainPage.DisplayAlert("Sign In Failed!", "Invalid input", "OK");
            }
            else
            {
                Page p = new QuestionScreen();

                Push?.Invoke(p);
            }
        }

    }
}



