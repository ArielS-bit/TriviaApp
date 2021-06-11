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
    public partial class GuestEnd : ContentPage
    {
        public GuestEnd()
        {
            InitializeComponent();

            GuestEndViewModel g = new GuestEndViewModel();
            g.Push += (p) => Navigation.PushAsync(p);
            this.BindingContext = g;
        }

       
    }
}