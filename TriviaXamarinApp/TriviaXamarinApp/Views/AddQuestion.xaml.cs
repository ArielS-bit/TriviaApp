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
    public partial class AddQuestion : ContentPage
    {
        public AddQuestion()
        {
            InitializeComponent();

            TriviaXamarinApp.ViewModel.AddQuestionViewModel addQ = new ViewModel.AddQuestionViewModel();
            this.BindingContext = addQ;
            addQ.Push += (p) => Navigation.PushAsync(p);

        }
    }
}