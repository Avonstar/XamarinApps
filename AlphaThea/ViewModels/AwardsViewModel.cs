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
    public class AwardsViewModel
    {

		private bool _isbusy;
        private ImageSource _greenPointImg;

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

		public ImageSource GreenPointImage
		{
			get { return _greenPointImg; }
			set
			{
				this._greenPointImg = value;
			}
		}

		public async Task<ObservableCollection<GreenPointsFinal>> GetGreenPointsListData()
		{

			var greenPoints = new ObservableCollection<GreenPoints>();
			greenPoints = await App.UsrDataManager.RefreshUserGreenPointsAsync();

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
