using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;

namespace TriviaXamarinApp.ViewModel
{
    class WelcomePageViewModel:ViewModelBase
    {
        string gameName;
       
        public string GameName { get=> gameName; 
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
            ChangeButtonText = new Command(() => { GameName = "Loading Game...."; });
        }
        public ICommand ChangeButtonText{ get; set; }
    }
}
