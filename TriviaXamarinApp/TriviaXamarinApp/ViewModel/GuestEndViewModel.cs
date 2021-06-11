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
    class GuestEndViewModel : ViewModelBase
    {
        public event Action<Page> Push;
        public ICommand SignUpCommand => new Command(SignUp);
        private void SignUp()
        {
            Push?.Invoke(new TriviaXamarinApp.Views.SignUp());
        }

        public ICommand LogInCommand => new Command(LogIn);
        private void LogIn()
        {
            Push?.Invoke(new TriviaXamarinApp.Views.LogIn());
        }

        public ICommand ExitCommand => new Command(Exit);
        private void Exit()
        {
            System.Environment.Exit(0);
        }

    }

}
