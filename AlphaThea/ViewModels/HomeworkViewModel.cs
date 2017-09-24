using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using AlphaThea.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace AlphaThea.ViewModels
{
    public class HomeworkViewModel : INotifyPropertyChanged
    {

        private bool _isbusy = false;
        private bool _iserror = false;
        private string _errormsg;
        private DateTime _startdate;
        private DateTime _enddate;
        private ObservableCollection<DisplayHomework> _homework;

        public HomeworkViewModel()
        {
            UpdateHomeworkCommand = new Command(UpdateHomework);
        }

		public event PropertyChangedEventHandler PropertyChanged;

		void OnPropertyChanged([CallerMemberName] string name = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
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

		public bool IsError
		{
			get { return _iserror; }
			set
			{
				_iserror = value;
				OnPropertyChanged();
			}

		}

		public string ErrorMsg
		{
			get { return _errormsg; }
			set
			{
				_errormsg = value;
				OnPropertyChanged();
			}

		}

        public DateTime StartDate
        {
            get { return _startdate; }
			set
			{
				_startdate = value;
				OnPropertyChanged();
			}
        }

		public DateTime EndDate
		{
            get { return _enddate; }
			set
			{
				_enddate = value;
				OnPropertyChanged();
			}
		}

		public ObservableCollection<DisplayHomework> HomeworkCollection
		{
			get { return _homework; }
			set
			{
				_homework = value;
				OnPropertyChanged();
			}
		}

        public Command UpdateHomeworkCommand
        {
            get;
        }

        public async void UpdateHomework()
        {

            IsBusy = true;

			await System.Threading.Tasks.Task.Delay(100);

            //Retrieve Lesson Groups
			string lessonGroups = null;
            string allPupils = null;

			if (App.Current.Properties.ContainsKey("AllLessonGroups"))
			{
				lessonGroups = App.Current.Properties["AllLessonGroups"] as string;
			}
            else
            {
                IsError = true;
                ErrorMsg = "Lesson group data missing, check your intenet connection and restart the application";
                IsBusy = false;
                return;
            }

			string id = null;

			if (Application.Current.Properties.ContainsKey("UserId"))
			{
				id = Application.Current.Properties["UserId"] as string;

			}
            else
            {
				IsError = true;
				ErrorMsg = "UserId missing, check your intenet connection and restart the application";
				IsBusy = false;
				return;
            }

			if (App.Current.Properties.ContainsKey("AllPupils"))
			{
				allPupils = App.Current.Properties["AllPupils"] as string;
			}
			else
			{
				IsError = true;
				ErrorMsg = "Pupil data missing, check your intenet connection and restart the application";
				IsBusy = false;
				return;
			}


            try
            {
                
                //var lessons = JsonConvert.DeserializeObject<List<LessonGroup>>(lessonGroups).ToDictionary(x => x.nid, x => x.title);
                var lecons = JsonConvert.DeserializeObject<List<LessonGroup>>(lessonGroups);

                var lessons = lecons.ToDictionary(x => x.nid, x => x.title);

                var usrgrps = new List<UserGroups>();

    			usrgrps = JsonConvert.DeserializeObject<List<UserGroups>>(allPupils);

                var groups = usrgrps.Where(u => u.uid == id).First().groupNodeIds;

                var hmwrkList = new List<string>();

                foreach(var item in groups)
                {
                    if(lessons.ContainsKey(item))
                    {
                        hmwrkList.Add(item);
                    }
                }

				HomeworkCollection = await App.UsrDataManager.RefreshUserHomeworkAsync(StartDate, EndDate, hmwrkList);

			}
			catch (Exception ex)
			{
				IsError = true;
				ErrorMsg = ex.InnerException.ToString();
				IsBusy = false;
				return;
			}

            IsBusy = false;
			
		}

    }
}
