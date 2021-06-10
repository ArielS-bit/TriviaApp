using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using TriviaXamarinApp.Services;

namespace TriviaXamarinApp.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
