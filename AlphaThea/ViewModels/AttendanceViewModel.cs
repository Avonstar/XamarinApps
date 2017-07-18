using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using System.Threading.Tasks;
using AlphaThea.Services;
using AlphaThea.Models;


namespace AlphaThea.ViewModels
{
    public class AttendanceViewModel : INotifyPropertyChanged
    {

        public AttendanceViewModel()
        {

			IsBusy = false;

		}

		int _lateAm;
        int _absentAm;
        int _absentPm;

		bool _isbusy;

        IEnumerable<ChartDataModel> _attendancePie;

		public event PropertyChangedEventHandler PropertyChanged;

		void OnPropertyChanged([CallerMemberName] string name = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}

		public Command FetchAttendanceDataCommand
		{
			get;

		}

		public int LateAm
		{
			get { return _lateAm; }
			set
			{
				_lateAm = value;
				OnPropertyChanged();
			}

		}

		public int AbsentAm
		{
			get { return _absentAm; }
			set
			{
				_absentAm = value;
				OnPropertyChanged();
			}

		}

		public int AbsentPm
		{
			get { return _absentPm; }
			set
			{
				_absentPm = value;
				OnPropertyChanged();
			}

		}

		public bool IsBusy
		{
			get { return _isbusy; }
			set
			{
				_isbusy = value;
				OnPropertyChanged();
			}

		}

		public IEnumerable<ChartDataModel> AttendancePie
		{
			get { return _attendancePie; }
			set
			{
				_attendancePie = value;
				OnPropertyChanged();
			}
		}

		//public async Task<List<ChartDataModel>> GetAttendanceListData()
		//{

		//	try
		//	{

		//		IsBusy = true;

		//		var att = new Attendance();
		//		att = await App.UsrDataManager.RefreshUserAttendanceAsync();

  //              List<ChartDataModel> attendancePie = new List<ChartDataModel>();

  //              int total = 180;

  //              int lateAmAsPercent = (int)Math.Round((double)(100 * att.LateAm) / total);
  //              int absentAmAsPercent = (int)Math.Round((double)(100 * att.AbsentAm) / total);
  //              int absentPmAsPercent = (int)Math.Round((double)(100 * att.AbsentPm) / total);
  //              int goodDays = 100 - (lateAmAsPercent + absentAmAsPercent + absentPmAsPercent);

		//		attendancePie.Add(new ChartDataModel("Late (am)", lateAmAsPercent));
		//		attendancePie.Add(new ChartDataModel("Absent (am)", absentAmAsPercent));
		//		attendancePie.Add(new ChartDataModel("Absent (pm)", absentPmAsPercent));
  //              attendancePie.Add(new ChartDataModel("No lates or absences", goodDays));

		//		IsBusy = false;

  //              return attendancePie;
                     

		//	}
		//	catch (Exception ex)
		//	{
		//		//await DisplayAlert("ERROR", ex.Message, "OK");
		//		throw new Exception(ex.Message);
		//	}


		//}

		public async Task GetAttendanceData()
		{

			try
			{

				IsBusy = true;

				var att = new Attendance();
                att = await App.UsrDataManager.RefreshUserAttendanceAsync();

                List<ChartDataModel> attendancePie = new List<ChartDataModel>();

				int total = 180;

				int lateAmAsPercent = (int)Math.Round((double)(100 * att.LateAm) / total);
				int absentAmAsPercent = (int)Math.Round((double)(100 * att.AbsentAm) / total);
				int absentPmAsPercent = (int)Math.Round((double)(100 * att.AbsentPm) / total);
				int goodDays = 100 - (lateAmAsPercent + absentAmAsPercent + absentPmAsPercent);

				attendancePie.Add(new ChartDataModel("Late (am)", lateAmAsPercent));
				attendancePie.Add(new ChartDataModel("Absent (am)", absentAmAsPercent));
				attendancePie.Add(new ChartDataModel("Absent (pm)", absentPmAsPercent));
				attendancePie.Add(new ChartDataModel("No lates/ absences", goodDays));

                //AttendancePie = attendancePie;
                _attendancePie = attendancePie;

				//LateAm = att.lateAm;
				//AbsentAm = att.absentAm;
				//AbsentPm = att.absentPm;

				IsBusy = false;


			}
			catch (Exception ex)
			{
				//await DisplayAlert("ERROR", ex.Message, "OK");
				throw new Exception(ex.Message);
			}


		}

    }
}
