using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;
using TriviaXamarinApp.Models;
using TriviaXamarinApp.Services;
using System.Threading.Tasks;

namespace TriviaXamarinApp.ViewModel
{
    class SignUpViewModel : ViewModelBase
    {
        private string nickName;
        private string email;
        private string pass;
        private List<AmericanQuestion> questions;
        private TriviaWebAPIProxy proxyServer;

        public string NickName
        {
            get => nickName;
            set
            {
                if (value != nickName)
                {
                    nickName = value;
                    OnPropertyChanged("NickName");
                }
            }
        }

        public string Email
        {
            get => email;
            set
            {
                if (value != email)
                {
                    email = value;
                    OnPropertyChanged("Email");
                }
            }
        }

        public string Pass
        {
            get => pass;
            set
            {
                if (value != pass)
                {
                    pass = value;
                    OnPropertyChanged("Pass");
                }
            }
        }

        //לא בטוח שנכון אולי לשים בפעולה בונה ושם לאתחל
        public List<AmericanQuestion> Questions
        {
            get => questions;
            set
            {
                questions = null;
            }
        }


        public SignUpViewModel()
        {
            proxyServer = TriviaWebAPIProxy.CreateProxy();
            //command which updates all user's info using User constructor and then sends it to the RegisterUser func in Services folder
            SignUpCommand = new Command(async () => {
                User u = new User
                {
                    Email = email,
                    Password = pass,
                    NickName = nickName,
                    Questions = questions
                };
                Task<bool> t = proxyServer.RegisterUser(u);//יש לבדוק ערך מוחזר ולעשות בדיקת קלט לכל נתון שנקלט 
                if (t==true)
                {

                }




            });
        }

        public ICommand SignUpCommand { get; set; }

    }
}
