using AlphaThea.Models;
using AlphaThea.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AlphaThea.Pages
{
    public partial class Awards : ContentPage
    {
        AwardsViewModel viewModel = new AwardsViewModel();

        public Awards()
        {
            InitializeComponent();

            BindingContext = viewModel;
            dataGrid.BindingContext = viewModel;
        }

		protected override async void OnAppearing()
		{


			base.OnAppearing();

            //await viewModel.UpdateGreenPoints();

		}

		void Handle_StartDateSelected(object sender, Xamarin.Forms.DateChangedEventArgs e)
		{
			viewModel.StartDate = e.NewDate;
		}

		void Handle_EndDateSelected(object sender, Xamarin.Forms.DateChangedEventArgs e)
		{
			viewModel.EndDate = e.NewDate;
		}

    }
}
