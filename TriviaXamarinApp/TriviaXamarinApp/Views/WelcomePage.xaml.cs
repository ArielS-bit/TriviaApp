using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TriviaXamarinApp.ViewModel;


namespace TriviaXamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
            WelcomePageViewModel w = new WelcomePageViewModel();
            w.Push += (p) => Navigation.PushAsync(p);
            this.BindingContext = w;

            btn.Margin = 85;
            btn.HeightRequest = 45;
            

        }

       
    }
}