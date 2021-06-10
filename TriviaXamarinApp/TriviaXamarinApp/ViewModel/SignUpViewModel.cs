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

        public ICommand SignUpCommand { get; }
        public event Action<Page> Push;

        public SignUpViewModel()
        {
            proxy = TriviaWebAPIProxy.CreateProxy();
            SignUpCommand = new Command(SignUp);

        }


        private async void SignUp()
        {
            User u = new User {Email=Email, Password=Pass, NickName=NickName};

            bool isReturned = await proxy.RegisterUser(u);

            if (isReturned ==false)
            {
                await Application.Current.MainPage.DisplayAlert("Sign Up Failed!", "Invalid input", "OK");
                Push?.Invoke(new SignUp());
            }
            else
            {
                ((App)App.Current).User = u;
                //Push?.Invoke(new QuestionScreen());
            }
        }

    }
}



