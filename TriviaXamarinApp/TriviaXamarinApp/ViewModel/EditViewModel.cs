using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using TriviaXamarinApp.Services;
using TriviaXamarinApp.Models;
using System.Linq;
using TriviaXamarinApp.Views;

namespace TriviaXamarinApp.ViewModel
{
    class EditViewModel:ViewModelBase
    {
        
        public event Action<Page> Push;

        public EditViewModel(AmericanQuestion q)
        {
            QuestionText = q.QText;
            CorrectAnswer = q.CorrectAnswer;
            OtherAnswers = q.OtherAnswers;
            originalQuestion = q;
        }

        private AmericanQuestion originalQuestion;

        private string questionText;
        public string QuestionText
        {
            get
            {
                return this.questionText;
            }
            set
            {
                if (this.questionText != value)
                {
                    this.questionText = value;
                    OnPropertyChanged(nameof(QuestionText));
                }
            }
        }

        private string correctAnswer;
        public string CorrectAnswer
        {
            get
            {
                return this.correctAnswer;
            }
            set
            {
                if (this.correctAnswer != value)
                {
                    this.correctAnswer = value;
                    OnPropertyChanged(nameof(CorrectAnswer));
                }
            }
        }

        private string[] otherAnswers;
        public string[] OtherAnswers
        {
            get
            {
                return this.otherAnswers;
            }
            set
            {
                if (this.otherAnswers != value)
                {
                    this.otherAnswers = value;
                    OnPropertyChanged(nameof(OtherAnswers));
                }
            }
        }

        private string errorMessage;
        public string ErrorMessage
        {
            get
            {
                return this.errorMessage;
            }
            set
            {
                if (this.errorMessage != value)
                {
                    this.errorMessage = value;
                    OnPropertyChanged(nameof(ErrorMessage));
                }
            }
        }

        public ICommand EditCommand => new Command(Edit);
        private async void Edit()
        {
            TriviaWebAPIProxy proxy = TriviaWebAPIProxy.CreateProxy();
            bool valid = await proxy.DeleteQuestion(originalQuestion);
            if (valid)
            {
                AmericanQuestion newQuestion = new AmericanQuestion()
                {
                    QText = QuestionText,
                    CorrectAnswer = CorrectAnswer,
                    OtherAnswers = OtherAnswers,
                    CreatorNickName = ((App)App.Current).User.NickName
                };

                if (IsNotEmpty(newQuestion))
                {
                    await proxy.PostNewQuestion(newQuestion);
                    Push?.Invoke(new MainEditor());
                }
            }
        }

        private bool IsNotEmpty(AmericanQuestion q)
        {
            return (q.QText != "" && q.CorrectAnswer != "" && q.OtherAnswers[0] != "" && q.OtherAnswers[1] != "" && q.OtherAnswers[2] != "" && q.CreatorNickName != "");
        }
    }
}