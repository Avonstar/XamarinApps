using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using System.Threading.Tasks;
using AlphaThea.Services;
using AlphaThea.Models;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace AlphaThea.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged
    {

        public static UserDataManager userdatamanager { get; private set; }

        public UserViewModel()
        {
            //userdatamanager = new UserDataManager(new RestService());

            IsBusy = false;

            //FetchUserDataCommand = new Command(async () => await GetSpecificUserData(),() => !IsBusy);


        }

        int _uid;
        string _username;
        string _email;
        bool _status;
        string _firstName="";
        string _lastName="";
        string[] _roles;

        ObservableCollection<User> _studentCollection;

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

		public ObservableCollection<User> StudentCollection
		{
			get { return _studentCollection; }
			set { 
                _studentCollection = value;
                OnPropertyChanged();
            }
		}

		public async Task GetSpecificUserData()
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

        public void RefreshStudentCollection()
        {
			string result = null;

            var usrs = new List<User>();

			if (App.Current.Properties.ContainsKey("AllUsers"))
			{
				result = App.Current.Properties["AllUsers"] as string;
			}

			usrs = JsonConvert.DeserializeObject<List<User>>(result);

			var students = usrs.Where(u => u.roles.Contains("ROLE_PUPIL"));

			var pupils = new ObservableCollection<User>();

			foreach (var item in students)
			{
				pupils.Add(new User()
				{
					firstName = item.firstName,
					lastName = item.lastName,
					uid = item.uid,
					email = item.email,
					fullName = item.firstName + " " + item.lastName
				});
			}

            StudentCollection = pupils;

        }

		public async Task GetAllsUsers()
		{

			try
			{

				IsBusy = true;

				StudentCollection = await App.UsrDataManager.RefreshUsersAsync();

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
