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

        private bool _isbusy;
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

        private async void UpdateHomework()
        {
			//Retrieve Lesson Groups
			string result = null;

			if (App.Current.Properties.ContainsKey("AllLessonGroups"))
			{
				result = App.Current.Properties["AllLessonGroups"] as string;
			}

            var lessons = JsonConvert.DeserializeObject<List<LessonGroup>>(result).ToDictionary(x => x.nid, x => x.title);

			string id = null;

			if (Application.Current.Properties.ContainsKey("UserId"))
			{
				id = Application.Current.Properties["UserId"] as string;

			}

            result = null;

            var usrgrps = new List<UserGroups>();

			if (App.Current.Properties.ContainsKey("AllPupils"))
			{
				result = App.Current.Properties["AllPupils"] as string;
			}

			usrgrps = JsonConvert.DeserializeObject<List<UserGroups>>(result);

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


    }
}
