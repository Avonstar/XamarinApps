using System;
using System.Collections.Generic;
using AlphaThea.ViewModels;
using Xamarin.Forms;

namespace AlphaThea.Pages
{
    public partial class HomeworkPage : ContentPage
    {

        HomeworkViewModel viewModel = new HomeworkViewModel();

        public HomeworkPage()
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.UpdateHomework();


        }
    }
}
