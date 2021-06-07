using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TriviaXamarinApp.Services;
using TriviaXamarinApp.Models;
using System.Threading.Tasks;
using TriviaXamarinApp.Views;


namespace TriviaXamarinApp
{
    public partial class App : Application
    {
        public event Action<User> Changed;
        private User user;
        public User User
        {
            get
            {
                return user;
            }
            set
            {
                if (user != value)
                {
                    user = value;
                }
            }
        }
        public App()
        {
            
            InitializeComponent();
            //TriviaWebAPIProxy t = new TriviaWebAPIProxy("ttps://ramonws.azurewebsites.net/AmericanQuestions/");
            
            MainPage = new NavigationPage(new WelcomePage());

            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
