using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Xamarin.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using AlphaThea.ViewModels;


namespace AlphaThea
{
    public partial class AlphaTheaPage : ContentPage
    {

        //public List<User> Users { get; private set; }

        public AlphaTheaPage()
        {
            InitializeComponent();
            BindingContext = new UserViewModel();

        }

    }
}
