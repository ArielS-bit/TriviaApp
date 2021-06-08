using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;
using TriviaXamarinApp.Services;
using TriviaXamarinApp.Models;
using TriviaXamarinApp.ViewModel;
using TriviaXamarinApp.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace TriviaXamarinApp.ViewModel
{
    class MainEditorViewModel:ViewModelBase
    {
        public MainEditorViewModel()
        {
            if (((App)App.Current).User.Questions == null)
            {
                ((App)App.Current).User.Questions = new List<AmericanQuestion>();
                Questions = new ObservableCollection<AmericanQuestion>(((App)App.Current).User.Questions);
            }
            else
            {
                Questions = new ObservableCollection<AmericanQuestion>(((App)App.Current).User.Questions);
            }
        }

        public event Action<Page> Push;

        public ICommand EditCommand => new Command<AmericanQuestion>(Edit);
        private void Edit(AmericanQuestion q)
        {
            Push?.Invoke(new TriviaXamarinApp.Views.EditQuestions(q));
        }

        public ICommand DeleteCommand => new Command<AmericanQuestion>(Delete);
        private async void Delete(AmericanQuestion q)
        {
            TriviaWebAPIProxy proxy = TriviaWebAPIProxy.CreateProxy();
            bool worked = await proxy.DeleteQuestion(q);
            if (worked)
            {
                ((App)App.Current).User.Questions.Remove(q);
                Questions.Remove(q);
              
            }
        }

        public ObservableCollection<AmericanQuestion> Questions { get; set; }
        public ICommand DeleteQuestionCommand => new Command<AmericanQuestion>(DeleteQuestion);
        private async void DeleteQuestion(AmericanQuestion a)
        {
            TriviaWebAPIProxy proxy = TriviaWebAPIProxy.CreateProxy();
            await proxy.DeleteQuestion(a);
            Questions.Remove(a);
        }

    }
}
