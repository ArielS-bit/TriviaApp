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
    public partial class ChooseScreen : ContentPage
    {
        public ChooseScreen()
        {
           
            InitializeComponent();
            ChooseViewModel c = new ChooseViewModel();
            this.BindingContext = c;
            c.Push += (p) => Navigation.PushAsync(p);
        }

        
    }
}