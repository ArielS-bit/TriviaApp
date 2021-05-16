using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TriviaXamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChooseScreen : ContentPage
    {
        public ChooseScreen()
        {
            InitializeComponent();
        }

        private async void SignUpBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUp());
        }

        private async void GuestBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GuestScreen());

        }

        private async void LogInBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LogIn());

        }
    }
}