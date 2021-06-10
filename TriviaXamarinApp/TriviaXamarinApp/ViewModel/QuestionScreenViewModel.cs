using System;
using System.Collections.Generic;
using System.Text;
using TriviaXamarinApp.ViewModel;
using TriviaXamarinApp.Models;
using TriviaXamarinApp.Views;
using TriviaXamarinApp.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Linq;


namespace TriviaXamarinApp.ViewModel
{
    class QuestionScreenViewModel : ViewModelBase
    {

        public delegate Task<bool> PopupDelegate();
        public event PopupDelegate Popup;
        public delegate Task<bool> GuestDelegate();
        

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

        private bool isenabled;
        public bool IsEnabled
        {
            get
            {
                return isenabled;
            }
            set
            {
                if (isenabled != value)
                {
                    isenabled = value;
                    OnPropertyChanged(nameof(IsEnabled));
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

        private string[] answers;
        public string[] Answers
        {
            get
            {
                return answers;
            }
            set
            {
                if (answers != value)
                {
                    answers = value;
                    OnPropertyChanged(nameof(Answers));
                }
            }
        }

        private int score;
        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                if (score != value)
                {
                    score = value;
                    OnPropertyChanged(nameof(Score));
                }
            }
        }

        private bool click;
        public bool Click
        {
            get
            {
                return click;
            }
            set
            {
                if (click != value)
                {
                    click = value;
                    OnPropertyChanged(nameof(Click));
                }
            }
        }

        public QuestionScreenViewModel()
        {
            IsEnabled = ((App)App.Current).User != null;
            Click = false;
            Play();
        }

        public ICommand MainEditorCommand => new Command(MainEditor);

        private void MainEditor()
        {
            Push?.Invoke(new MainEditor());
        }

        public ICommand AnswerCommand => new Command<string>(Answer);

        private async void Answer(string s)
        {
            if (s == CorrectAnswer)
            {

                Score++;
                if (Score % 3 != 0)
                {
                    Click = false;
                }

                if (Score % 3 == 0 && score != 0)
                {
                    if (((App)App.Current).User == null)
                    {
                        
                        Push?.Invoke(new GuestEnd());
                        
                    }
                    else
                    {
                        bool answer = await Popup();

                        if (answer)
                        {
                            Push?.Invoke(new AddQuestion());
                            
                        }
                        Click = true;
                    }
                }
            }
            Play();
        }

        public ICommand PlayCommand => new Command(Play);
        private async void Play()
        {
            TriviaWebAPIProxy proxy = TriviaWebAPIProxy.CreateProxy();

            AmericanQuestion q = await proxy.GetRandomQuestion();
            Random r = new Random();
            this.CorrectAnswer = q.CorrectAnswer;
            this.NickName = q.CreatorNickName;
            this.QuestionText = q.QText;
            Answers = new string[4];

            for (int i = 0; i < 3; i++)
            {
                Answers[i] = q.OtherAnswers[i];
            }
            Answers[3] = q.CorrectAnswer;

           
            Answers = Answers.OrderBy(x => r.Next()).ToArray();
        }
        
    }
}








