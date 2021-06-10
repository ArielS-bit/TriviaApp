using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TriviaXamarinApp.Models;
using TriviaXamarinApp.ViewModel;

namespace TriviaXamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditQuestions : ContentPage
    {
        public EditQuestions(AmericanQuestion q)
        {
            

            InitializeComponent();
            EditViewModel edit = new EditViewModel(q);
            this.BindingContext = edit;

            edit.Push += (p) => Navigation.PushAsync(p);
        }
    }
}