using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;


namespace TriviaXamarinApp.ViewModel
{
    class LogInViewModel:ViewModelBase
    {
        string succuessStatus;

        public string SuccuessStatus
        {
            get => succuessStatus;
            set
            {
                if (value != succuessStatus)
                {
                    succuessStatus = value;
                    OnPropertyChanged("SuccuessStatus");
                }
            }
        }



        public LogInViewModel()
        {
            succuessStatus = "";
            ChangeStatus = new Command(() => { succuessStatus = "SUCCESS!"; });


        }
        public ICommand ChangeStatus { get; set; }
    }
}
