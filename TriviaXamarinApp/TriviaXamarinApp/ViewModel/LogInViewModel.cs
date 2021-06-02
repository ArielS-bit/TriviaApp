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

        public ICommand LoginCommand { get; }

        public LogInViewModel()
        {
            proxy = TriviaWebAPIProxy.CreateProxy();

            LoginCommand = new Command(Login);
        }

        public event Action<Page> Push;

        private async void Login()
        {
            User u = null;

            u = await proxy.LoginAsync(Email, Pass);

            if (u==null)
            {
                await Application.Current.MainPage.DisplayAlert("Login Failed!", "Email or username invalid", "OK");
            }
            else
            {
                Page p = new QuestionScreen();
                
                Push?.Invoke(p);
            }
        }

       
    }
}
