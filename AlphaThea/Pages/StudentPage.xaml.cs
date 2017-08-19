using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AlphaThea.Models;
using AlphaThea.ViewModels;
using Newtonsoft.Json;
using Xamarin.Forms;
using Syncfusion.SfAutoComplete.XForms;

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

            viewModel.RefreshStudentCollection();

            //studentAutoComplete.BindingContext = viewModel.StudentCollection;

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
