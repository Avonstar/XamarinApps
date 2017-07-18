using AlphaThea.Models;
using AlphaThea.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using C1.Xamarin.Forms.Grid;

namespace AlphaThea.Pages
{
    public partial class Awards : ContentPage
    {
        AwardsViewModel viewModel = new AwardsViewModel();

        public Awards()
        {
            InitializeComponent();

            dataGrid.BindingContext = viewModel;
        }

		protected override async void OnAppearing()
		{


			base.OnAppearing();

            dataGrid.BindingContext = viewModel;

			var greenPoints = await viewModel.GetGreenPointsListData();

            dataGrid.ItemsSource= greenPoints;

		}

    }
}
