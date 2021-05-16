using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;

namespace TriviaXamarinApp.ViewModel
{
    class ChooseViewModel : ViewModelBase
    {
        string text;

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



        public ChooseViewModel()
        {
            text = "Choose an option";
           
        }
       
    }
}
