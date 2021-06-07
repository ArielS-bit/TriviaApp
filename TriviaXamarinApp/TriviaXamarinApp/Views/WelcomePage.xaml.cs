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
            
            //Image
            //logo.Source = "ttps://images-platform.99static.com/ToOcJbuDzoa8sqctL1QMGO089kA=/200x220:1800x1820/500x500/top/smart/99designs-contests-attachments/95/95660/attachment_95660693";
            
            //Button
            //btn.CornerRadius = 18;
            btn.Margin = 85;
            btn.HeightRequest = 45;
            
        
        }

        private async void btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChooseScreen());
        }
    }
}