﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaXamarinApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TriviaXamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogIn : ContentPage
    {
        public LogIn()
        {
            InitializeComponent();
            LogInViewModel l = new LogInViewModel();
            l.Push += (p) => Navigation.PushAsync(p);
            this.BindingContext = l;
            //todo
        }

        private void LogInBtn_Clicked(object sender, EventArgs e)
        {

        }

        private async void SignUpBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUp());
        }
    }
}