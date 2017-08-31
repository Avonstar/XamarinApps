using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using System.Threading.Tasks;
using AlphaThea.Services;
using AlphaThea.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace AlphaThea.ViewModels
{
    public class AwardsViewModel : INotifyPropertyChanged
    {

        private bool _isbusy;
		private DateTime _startdate;
		private DateTime _enddate;
        private ImageSource _greenPointImg;
        private ObservableCollection<GreenPointsFinal> _greenPoints;

        public AwardsViewModel()
        {
            FetchGreenPointsDataCommand = new Command(UpdateGreenPoints);
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


		public ImageSource GreenPointImage
        {
            get { return _greenPointImg; }
            set
            {
                this._greenPointImg = value;
            }
        }

        public async void UpdateGreenPoints()
        {

            try
            {
                IsBusy = true;

                var greenPoints = new ObservableCollection<GreenPoints>();

                await System.Threading.Tasks.Task.Delay(100);

                greenPoints = await App.UsrDataManager.RefreshUserGreenPointsAsync(StartDate, EndDate);

                var greenPointsFinal = new ObservableCollection<GreenPointsFinal>();

                foreach (var gpItem in greenPoints)
                {

                    greenPointsFinal.Add(new GreenPointsFinal()
                    {
                        Created = gpItem.Created,
                        AwardedBy = gpItem.AwardedBy,
                        Description = gpItem.Description,
                        GreenPointsImage = GetGreenPointImage(gpItem.Points)
                    });
                }


                GreenPoints = greenPointsFinal;

                IsBusy = false;
            }
            catch(Exception ex)
            {
                
            }
            finally
            {
                IsBusy = false;

            }

		}

		public async Task<ObservableCollection<GreenPointsFinal>> GetGreenPointsListData()
		{

            //This could probably be removed as its not used

			var greenPoints = new ObservableCollection<GreenPoints>();
			greenPoints = await App.UsrDataManager.RefreshUserGreenPointsAsync(StartDate, EndDate);

            var greenPointsFinal = new ObservableCollection<GreenPointsFinal>();

            foreach(var gpItem in greenPoints)
            {

                greenPointsFinal.Add(new GreenPointsFinal()
                {
                    Created = gpItem.Created,
                    AwardedBy = gpItem.AwardedBy,
                    Description = gpItem.Description,
                    GreenPointsImage = GetGreenPointImage(gpItem.Points)
                });
            }

            return greenPointsFinal;

		}

        public ObservableCollection<GreenPointsFinal> GreenPoints
        {
            get { return _greenPoints; }
            set
            {
                _greenPoints = value;
                OnPropertyChanged();
            }
        }

        private ImageSource GetGreenPointImage(int greenPoints)
        {

            ImageSource imgSource;

            switch (greenPoints)
			{

				case 1:

					imgSource = ImageSource.FromResource("AlphaThea.Content.Images.1GreenStar.png");
                    break;

				case 2:
                    imgSource = ImageSource.FromResource("AlphaThea.Content.Images.2GreenStars.png");
                    break;

				case 3:
					imgSource = ImageSource.FromResource("AlphaThea.Content.Images.3GreenStars.png");
                    break;

				case 4:
					imgSource = ImageSource.FromResource("AlphaThea.Content.Images.4GreenStars.png");
                    break;

				case 5:
					imgSource = ImageSource.FromResource("AlphaThea.Content.Images.5GreenStars.png");
                    break;

				default:
                    imgSource = null;
					break;

			}

            return imgSource;


		}

    }
}
