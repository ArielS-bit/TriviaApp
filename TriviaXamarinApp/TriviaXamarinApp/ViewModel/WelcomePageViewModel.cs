using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;


namespace TriviaXamarinApp.ViewModel
{
    class WelcomePageViewModel : ViewModelBase
    {
        private string gameName;
        public event Action<Page> Push;
        public string GameName
        {
            get => gameName;
            set
            {
                if (value != gameName)
                {
                    gameName = value;
                    OnPropertyChanged("GameName");
                }
            }
        }

       


        public WelcomePageViewModel()
        {
            gameName = "Trivia Game";
           
        }

        public ICommand ChangeCommand => new Command(PrintMove);

        public void PrintMove()
        {
            GameName = "Loading Game....";
            Push?.Invoke(new Views.ChooseScreen());
        }

       

    }
}
