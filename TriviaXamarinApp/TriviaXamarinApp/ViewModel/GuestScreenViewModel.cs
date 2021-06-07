using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using TriviaXamarinApp.Services;
using TriviaXamarinApp.Models;


namespace TriviaXamarinApp.ViewModel
{
    class GuestScreenViewModel:ViewModelBase
    {
        public ICommand PlayCommand => new Command(Play);
        private void Play()
        {
            Push?.Invoke(new TriviaXamarinApp.Views.QuestionScreen());
        }

        public event Action<Page> Push;


    }
}
