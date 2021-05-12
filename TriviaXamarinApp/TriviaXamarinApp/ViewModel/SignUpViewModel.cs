using System;
using System.Collections.Generic;
using System.Text;

namespace TriviaXamarinApp.ViewModel
{
    class SignUpViewModel:ViewModelBase
    {
        string gameName;

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



        public SignUpViewModel()
        {
            gameName = "Trivia Game";

        }
    }
}
