using System;
using System.Collections.Generic;
using AlphaThea.ViewModels;

using Xamarin.Forms;

namespace AlphaThea.Pages
{
    public partial class StudentPage : ContentPage
    {
        UserViewModel viewModel = new UserViewModel();

        public StudentPage()
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

		protected override async void OnAppearing()
		{

			base.OnAppearing();

			BindingContext = viewModel;

            await viewModel.GetTokenAndSpecificUserData();

		}
    }
}
