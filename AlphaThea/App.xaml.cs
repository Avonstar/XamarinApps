using Xamarin.Forms;
using AlphaThea.Services;
using AlphaThea.Pages;
using AlphaThea.ViewModels;
using System;

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

        protected async override void OnStart()
        {
            // Handle when your app starts

            try
            {
                
                homeViewModel.IsBusy = true;

                await UsrDataManager.GetNewToken();

                //Get all users
                await UsrDataManager.GetPupilsAsync();

                //Get all lesson groups
                await UsrDataManager.GetLessonGroups();

                homeViewModel.IsBusy = false;
            }
            catch(Exception ex)
            {
                throw new System.Exception();
            }
            finally
            {
                homeViewModel.IsBusy = false;

            }

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
			// Handle when your app resumes
			//await UsrDataManager.GetNewToken();

			//await UsrDataManager.GetPupilsAsync();
        }
    }
}
