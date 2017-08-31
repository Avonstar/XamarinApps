using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AlphaThea.ViewModels
{
    public class HomeViewModel :INotifyPropertyChanged
    {
        private bool _isbusy = false;

        public HomeViewModel()
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

    }
}
