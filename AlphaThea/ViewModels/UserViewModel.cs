using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using System.Threading.Tasks;
using AlphaThea.Services;
using AlphaThea.Models;


namespace AlphaThea.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged
    {

        public static UserDataManager userdatamanager { get; private set; }

        public UserViewModel()
        {
            //userdatamanager = new UserDataManager(new RestService());

            IsBusy = false;

            FetchUserDataCommand = new Command(async () => await GetTokenAndSpecificUserData(),() => !IsBusy);

        }

        int _uid;
        string _username;
        string _email;
        bool _status;
        string _firstName="";
        string _lastName="";
        string[] _roles;

        bool _isbusy;

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public Command FetchUserDataCommand
        {
            get;

        }



        public int Uid
        {
            get { return _uid; }
            set 
            { 
                _uid = value; 
                OnPropertyChanged();
            }

        }

		public string Username
		{
			get { return _username; }
			set 
            {
                _username = value;
                OnPropertyChanged();;
            }

		}

		public string Email
		{
			get { return _email; }
			set 
            {
                _email = value;
                OnPropertyChanged();
            }

		}

		public bool Status
		{
			get { return _status; }
			set 
            {
                _status = value;
                OnPropertyChanged();
            }

		}

		public string FirstName
		{
			get { return _firstName; }
			set 
            { 
                _firstName = value;
                OnPropertyChanged();
            }

		}

		public string LastName
		{
			get { return _lastName; }
			set 
            {
                _lastName = value;
                OnPropertyChanged();
            }

		}

		public string[] Roles
		{
			get { return _roles; }
			set 
            { 
                _roles = value;
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
                //FetchUserDataCommand.ChangeCanExecute();
            }

        }

		public async Task GetTokenAndSpecificUserData()
		{

			try
			{

                IsBusy = true;

                var usr = new User();
                //usr = await userdatamanager.RefreshUserDataAsync();
                usr = await App.UsrDataManager.RefreshUserDataAsync();

				Uid = usr.uid;
				Username = usr.username;
				Email = usr.email;
				Status = usr.status;

				FirstName = usr.firstName;
				LastName = usr.lastName;
				Roles = usr.roles;

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
