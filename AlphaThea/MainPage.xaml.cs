using System;
using System.Collections.Generic;
using AlphaThea.ViewModels;

using Xamarin.Forms;

namespace AlphaThea
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new UserViewModel();
        }
    }
}
