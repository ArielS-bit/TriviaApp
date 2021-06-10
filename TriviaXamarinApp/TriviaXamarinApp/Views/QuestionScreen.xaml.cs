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
    public partial class QuestionScreen : ContentPage
    {
        private TriviaXamarinApp.ViewModel.QuestionScreenViewModel t;

        public QuestionScreen()
        {
            t = new ViewModel.QuestionScreenViewModel();
            this.BindingContext = t;
            t.Push += (p) => Navigation.PushAsync(p);

            t.Popup += Alert;
            

            InitializeComponent();
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            t.IsEnabled = ((App)App.Current).User != null;
        }

        public async Task<bool> Alert()
        {
            bool answer = await DisplayAlert("Add Question", "Would you like to add a question into our DB?", "Indeed", "Nope");

            return answer;
        }

        
    }
}
