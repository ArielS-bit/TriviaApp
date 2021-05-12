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
            BindingContext = new WelcomePageViewModel();
            //logo.Source = "ttps://i.pinimg.com/originals/78/ec/e9/78ece98404ae86f281e0c4cc35ad0dd9.jpg";
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}