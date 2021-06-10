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
        private TriviaXamarinApp.ViewModel.QuestionScreenViewModel trivia;

        public QuestionScreen()
        {
            trivia = new ViewModel.QuestionScreenViewModel();
            this.BindingContext = trivia;
            trivia.Push += (p) => Navigation.PushAsync(p);

            trivia.Popup += AlertYesNo;
            

            InitializeComponent();
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            trivia.IsEnabled = ((App)App.Current).User != null;
        }

        public async Task<bool> AlertYesNo()
        {
            bool answer = await DisplayAlert("Question?", "Would you like to add a question?", "Yes", "No");

            return answer;
        }

        
    }
}
