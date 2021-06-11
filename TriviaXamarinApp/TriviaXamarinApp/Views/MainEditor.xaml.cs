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
    public partial class MainEditor : ContentPage
    {
        public MainEditor()
        {
            InitializeComponent();

            MainEditorViewModel m = new MainEditorViewModel();
            this.BindingContext = m;
            m.Push += (p) => Navigation.PushAsync(p);
        }
    }
}