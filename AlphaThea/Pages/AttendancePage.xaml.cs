using System;
using System.Collections.Generic;
using AlphaThea.ViewModels;
using AlphaThea.Models;
using Xuni.Forms.FlexPie;

using Xamarin.Forms;
using Syncfusion.SfChart.XForms;
using System.Collections.ObjectModel;

namespace AlphaThea.Pages
{
    public partial class AttendancePage : ContentPage
    {

        AttendanceViewModel viewModel = new AttendanceViewModel();

        public AttendancePage()
        {
            InitializeComponent();

			if (!(Device.OS == TargetPlatform.Android || Device.OS == TargetPlatform.iOS))
			{
				Chart.Series[0].AnimationDuration = 2;
				(Chart.Series[0] as PieSeries).StartAngle = 0;
				(Chart.Series[0] as PieSeries).EndAngle = 360;
			}

		}


        protected override async void OnAppearing()
        {
            
			base.OnAppearing();

            await viewModel.GetAttendanceData();

            PieSeries pieSeries = new PieSeries()
            {
                ItemsSource = viewModel.AttendancePie,
                XBindingPath = "Name",
                YBindingPath = "Value",
				EnableSmartLabels = true,
				DataMarkerPosition = CircularSeriesDataMarkerPosition.OutsideExtended,
				ConnectorLineType = ConnectorLineType.Bezier,
				StartAngle = 75,
				EndAngle = 435,
                DataMarker = new ChartDataMarker()
                {
                    LabelContent = LabelContent.Percentage
                }    
			};

            Chart.BindingContext = viewModel;

            Chart.Series.Add(pieSeries);

        }

    }
}
