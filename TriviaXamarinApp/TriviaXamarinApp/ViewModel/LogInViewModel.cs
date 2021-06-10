using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;
using TriviaXamarinApp.Services;
using TriviaXamarinApp.Models;
using TriviaXamarinApp.ViewModel;
using TriviaXamarinApp.Views;


namespace TriviaXamarinApp.ViewModel
{
    class LogInViewModel:ViewModelBase
    {
        private string email;
        private string pass;
        private TriviaWebAPIProxy proxy;

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

        

        public LogInViewModel()
        {
            proxy = TriviaWebAPIProxy.CreateProxy();

           
        }

        public event Action<Page> Push;
        public ICommand LoginCommand => new Command(Login);
        private async void Login()
        {
            
            TriviaWebAPIProxy proxy = TriviaWebAPIProxy.CreateProxy();

            User u = await proxy.LoginAsync(Email, Pass);

            if (u==null)
            {
                await Application.Current.MainPage.DisplayAlert("Login Failed!", "Email or username invalid", "OK");
            }
            else
            {
                ((App)App.Current).User = u;
                Push?.Invoke(new QuestionScreen());
            }
        }

        public ICommand SignUpCommand => new Command(SignUp);
        private void SignUp()
        {
            Push?.Invoke(new SignUp());
        }


    }
}
