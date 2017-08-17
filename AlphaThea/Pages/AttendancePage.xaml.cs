using AlphaThea.ViewModels;
using Xamarin.Forms;
using Syncfusion.SfChart.XForms;

namespace AlphaThea.Pages
{
    public partial class AttendancePage : ContentPage
    {

        AttendanceViewModel viewModel = new AttendanceViewModel();

        public AttendancePage()
        {
            InitializeComponent();

            Chart.BindingContext = viewModel;

			if (!(Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS))

				{
				Chart.Series[0].AnimationDuration = 2;
				(Chart.Series[0] as PieSeries).StartAngle = 0;
				(Chart.Series[0] as PieSeries).EndAngle = 360;
			}

		}


        protected override async void OnAppearing()
        {
            
			base.OnAppearing();

            await viewModel.UpdateAttendanceData();

        }

    }
}
