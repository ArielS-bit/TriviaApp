using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;

namespace TriviaXamarinApp.ViewModel
{
    class ChooseViewModel : ViewModelBase
    {
        private string text;

        public string Text
        {
            get => text;
            set
            {
                if (value != text)
                {
                    text = value;
                    OnPropertyChanged("Text");
                }
            }
        }

        public event Action<Page> Push;

        public ChooseViewModel()
        {
            text = "Choose an option";
           
        }

        public ICommand GuestCommand => new Command(Guest);
        private void Guest()
        {
            Push?.Invoke(new TriviaXamarinApp.Views.GuestScreen());
        }

        public ICommand LogInCommand => new Command(LogIn);
        private void LogIn()
        {
            Push?.Invoke(new Views.LogIn());
        }

        public ICommand SignUpCommand => new Command(SignUp);
        private void SignUp()
        {
            Push?.Invoke(new Views.SignUp());
        }

       

    }
}
