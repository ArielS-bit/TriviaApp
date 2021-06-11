using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using TriviaXamarinApp.Services;
using TriviaXamarinApp.Views;
using System.Threading.Tasks;
using TriviaXamarinApp.Models;
using TriviaXamarinApp.ViewModel;

namespace TriviaXamarinApp.ViewModel
{
    class AddQuestionViewModel : ViewModelBase
    {
        public event Action<Page> Push;

        private string correctanswer;
        public string CorrectAnswer
        {
            get
            {
                return correctanswer;
            }
            set
            {
                if (correctanswer != value)
                {
                    correctanswer = value;
                    OnPropertyChanged(nameof(CorrectAnswer));
                }
            }
        }

        private string nickname;
        public string NickName
        {
            get
            {
                return nickname;
            }
            set
            {
                if (nickname != value)
                {
                    nickname = value;
                    OnPropertyChanged(nameof(NickName));
                }
            }
        }

        private string questionText;
        public string QuestionText
        {
            get
            {
                return questionText;
            }
            set
            {
                if (questionText != value)
                {
                    questionText = value;
                    OnPropertyChanged(nameof(QuestionText));
                }
            }
        }

        private string[] otheranswers;
        public string[] OtherAnswers
        {
            get
            {
                return otheranswers;
            }
            set
            {
                if (otheranswers != value)
                {
                    otheranswers = value;
                    OnPropertyChanged(nameof(OtherAnswers));
                }
            }
        }

        private string warning;
        public string Warning
        {
            get
            {
                return warning;
            }
            set
            {
                if (warning != value)
                {
                    warning = value;
                    OnPropertyChanged(nameof(Warning));
                }
            }
        }

        public AddQuestionViewModel()
        {
            OtherAnswers = new string[3];
        }

        public ICommand AddQCommand => new Command(AddQ);
        private async void AddQ()
        {
            TriviaWebAPIProxy proxy = TriviaWebAPIProxy.CreateProxy();
            AmericanQuestion a = new AmericanQuestion()
            {
                QText = QuestionText,
                CreatorNickName = ((App)App.Current).User.NickName,
                CorrectAnswer = CorrectAnswer,
                OtherAnswers = OtherAnswers
            };

            if (!IsNotEmpty(a))
            {
                Warning = "You cant add empty question, please try again";
            }
            else
            {
                bool b = await proxy.PostNewQuestion(a);
                ((App)App.Current).User.Questions.Add(a);

                Push?.Invoke(new QuestionScreen());
            }
        }
        private bool IsNotEmpty(AmericanQuestion q)
        {
            return (q.QText != "" && q.CorrectAnswer != "" && q.OtherAnswers[0] != "" && q.OtherAnswers[1] != "" && q.OtherAnswers[2] != "" && q.CreatorNickName != "");
        }
    }
}
