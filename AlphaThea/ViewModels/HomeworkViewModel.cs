using System;
using System.Collections.Generic;
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

        public HomeworkViewModel()
        {
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

        public void UpdateHomework()
        {

			string id = null;

			if (Application.Current.Properties.ContainsKey("UserId"))
			{
				id = Application.Current.Properties["UserId"] as string;

			}

            string result = null;

            var usrgrps = new List<UserGroups>();

			if (App.Current.Properties.ContainsKey("AllUsers"))
			{
				result = App.Current.Properties["AllUsers"] as string;
			}

			usrgrps = JsonConvert.DeserializeObject<List<UserGroups>>(result);

            var groups = usrgrps.Where(u => u.uid == id).First().groupNodeIds;

            foreach (string grpId in groups)
            {


            }

		}


    }
}
