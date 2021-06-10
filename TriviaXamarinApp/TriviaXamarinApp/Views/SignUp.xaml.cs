using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using TriviaXamarinApp.ViewModel;
using Xamarin.Forms.Xaml;

namespace TriviaXamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUp : ContentPage
    {
        public SignUp()
        {
            InitializeComponent();

            SignUpViewModel s = new SignUpViewModel();
            s.Push += (p) => Navigation.PushAsync(p);
            this.BindingContext = s;
        }

       
    }
}