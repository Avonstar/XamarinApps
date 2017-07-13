using System;
using System.Collections.Generic;
using AlphaThea.ViewModels;
using AlphaThea.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AlphaThea.Pages
{
    public partial class PolicyPage : ContentPage
    {
        PolicyViewModel viewModel = new PolicyViewModel();

        public PolicyPage()
        {

            BindingContext = viewModel;

        }

		protected override void OnAppearing()
		{


			base.OnAppearing();

			Padding = new Thickness(0, 20, 0, 0);
			Content = new StackLayout
			{
				Children = {
				new CustomWebView {
					Uri = "Anti-BullyingPolicy.pdf",
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand
				}
			}
			};


		}

    }
}
