using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AlphaThea.Models;
using AlphaThea.ViewModels;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace AlphaThea.Pages
{
    public partial class StudentPage : ContentPage
    {
        UserViewModel viewModel = new UserViewModel();

        public StudentPage()
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

		protected override void OnAppearing()
		{

			base.OnAppearing();

            //BindingContext = viewModel;

			//var usrs = new List<User>();

   //         string result=null;

			//if (App.Current.Properties.ContainsKey("AllUsers"))
			//{
			//	result = App.Current.Properties["AllUsers"] as string;
			//}

			//usrs = JsonConvert.DeserializeObject<List<User>>(result);

			//var students = usrs.Where(u => u.roles.Contains("ROLE_PUPIL"));

			//var pupils = new ObservableCollection<User>();

			//foreach (var item in students)
			//{
			//	pupils.Add(new User()
			//	{
			//		firstName = item.firstName,
			//		lastName = item.lastName,
			//		uid = item.uid,
			//		email = item.email,
			//		fullName = item.firstName + " " + item.lastName
			//	});
			//}

            //viewModel.StudentCollection = pupils;

            //studentAutoComplete.DataSource = pupils;

            //studentAutoComplete.DisplayMemberPath = "fullName";

			//studentAutoComplete.SelectedValuePath = "uid";

            viewModel.RefreshStudentCollection();

            studentAutoComplete.Focus();

            string userid=null;

			studentAutoComplete.SelectionChanged += (sender, e) =>
			{
				//DisplayAlert("Selection Changed", "Selected Value: " + studentAutoComplete.SelectedValue.ToString(), "OK");
                userid=studentAutoComplete.SelectedValue.ToString();

                var usr = (User)e.Value;

                viewModel.FirstName=usr.firstName;
                viewModel.LastName = usr.lastName;
                viewModel.Uid = usr.uid;
                viewModel.Email = usr.email;

                Application.Current.Properties["UserId"] = userid;

			};

		}
    }
}
