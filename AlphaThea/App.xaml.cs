using Xamarin.Forms;
using System;
using AlphaThea.Services;
using AlphaThea.Pages;

namespace AlphaThea
{
    public partial class App : Application
    {

        public static UserDataManager UsrDataManager { get; private set; }

        public App()
        {
            InitializeComponent();

            UsrDataManager = new UserDataManager(new RestService());
            MainPage = new AlphaTheaPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
