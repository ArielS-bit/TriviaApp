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
        public event PopupDelegate Guest;
        
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

        private string qtext;
        public string QText
        {
            get
            {
                return qtext;
            }
            set
            {
                if (qtext != value)
                {
                    qtext = value;
                    OnPropertyChanged(nameof(QText));
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

        private int counter;
        public int Counter
        {
            get
            {
                return counter;
            }
            set
            {
                if (counter != value)
                {
                    counter = value;
                    OnPropertyChanged(nameof(Counter));
                }
            }
        }

        public ICommand MainEditorCommand => new Command(MainEditor);

        private void MainEditor()
        {
           
            Push?.Invoke(new TriviaXamarinApp.Views.MainEditor());
        }

        public ICommand AnswerCommand => new Command<string>(Answer);

        private async void Answer(string s)
        {
            if (s == CorrectAnswer)
            {
                Counter++;

                if (Counter % 3 == 0 && counter != 0)
                {
                    if (((App)App.Current).User == null)
                    {
                        //    bool guest = await Guest();

                        //    if (guest)
                        //    {
                        Counter = 0;
                        Push?.Invoke(new TriviaXamarinApp.Views.GuestEnd());
                        //}

                       
                    }
                    else
                    {
                        bool answer = await Popup();

                        if (answer)
                        {
                            Push?.Invoke(new TriviaXamarinApp.Views.AddQuestion());
                            Counter = 0;
                        }
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

            this.CorrectAnswer = q.CorrectAnswer;
            this.NickName = q.CreatorNickName;
            this.QText = q.QText;
            Answers = new string[4];

            for (int i = 0; i < 3; i++)
            {
                Answers[i] = q.OtherAnswers[i];
            }
            Answers[3] = q.CorrectAnswer;

            Random r = new Random();
            Answers = Answers.OrderBy(x => r.Next()).ToArray();
        }
        public QuestionScreenViewModel()
        {
            IsEnabled = ((App)App.Current).User != null;
        }
    }
}








