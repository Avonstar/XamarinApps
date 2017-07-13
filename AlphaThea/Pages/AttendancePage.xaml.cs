using System;
using System.Collections.Generic;
using AlphaThea.ViewModels;
using AlphaThea.Models;
using Xuni.Forms.FlexPie;

using Xamarin.Forms;

namespace AlphaThea.Pages
{
    public partial class AttendancePage : ContentPage
    {

        AttendanceViewModel viewModel = new AttendanceViewModel();

        public AttendancePage()
        {
            InitializeComponent();

            Xuni.Forms.Core.LicenseManager.Key = License.Key;

            BindingContext = viewModel;

			List<AttendancePieEntity> attendancePie = new List<AttendancePieEntity>();

			attendancePie.Add(new AttendancePieEntity("Baseline", 100));
		
			pieChart.ItemsSource = attendancePie;


		}



        protected override async void OnAppearing()
        {


			base.OnAppearing();

            await viewModel.GetAttendanceData();

            pieChart.BindingContext = viewModel;

            pieChart.ItemsSource = viewModel.AttendancePie;
            pieChart.HeaderText = "School attendance (%)";
            pieChart.HeaderFontSize = 20;

            pieChart.SelectedItemOffset = 0.2;

			Color[] palette = {
					Color.FromHex("#B47114"),
					Color.FromHex("#685444"),
					Color.FromHex("#ED6200"),
					Color.FromHex("#CDDC39")};

            pieChart.Palette = palette;


        }

    }
}
