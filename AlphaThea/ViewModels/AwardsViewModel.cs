using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using System.Threading.Tasks;
using AlphaThea.Services;
using AlphaThea.Models;
using System.Collections.ObjectModel;

namespace AlphaThea.ViewModels
{
    public class AwardsViewModel
    {

        //public int id { get; set; }
        //public User awardedTo { get; set; }
        //public User approvedBy { get; set; }
        //public int points { get; set; }
        //public int type { get; set; }
        //public int created { get; set; }
        //public string description { get; set; }
        //public int entityId { get; set; }
        //public string entityType { get; set; }
        //public string operation { get; set; }
        //public int reasonType { get; set; }

        int _transactionId;
        int _points;
        string _description;

        int _lateAm;
		int _absentAm;
		int _absentPm;

		bool _isbusy;

        public AwardsViewModel()
        {
            IsBusy = false;
        }

		public event PropertyChangedEventHandler PropertyChanged;

		void OnPropertyChanged([CallerMemberName] string name = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}

		public Command FetchGreenPointsDataCommand
		{
			get;

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


        public async Task<ObservableCollection<GreenPoints>> GetGreenPointsListData()
        {

            var greenPoints = new ObservableCollection<GreenPoints>();
            greenPoints = await App.UsrDataManager.RefreshUserGreenPointsAsync();

            return greenPoints;
            
        }


    }
}
