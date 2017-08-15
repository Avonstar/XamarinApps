
using Syncfusion.SfPdfViewer.XForms;
using Syncfusion.Pdf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;

using Xamarin.Forms;


namespace AlphaThea.Pages
{
	public partial class PolicyPage : ContentPage
	{
		public ContentPage page = new ContentPage();
		private string targetText = string.Empty;
		private StackLayout popupLayout = new StackLayout();
		List<Document> documents = null;
		string documentBackup = string.Empty;
		int documentIndex = 1;
		Picker picker;

		public List<Document> DocumentsList
		{
			get { return documents; }
			set
			{
				this.documents = value;
			}
		}
		public PolicyPage()
		{
			page.Title = "PDFViewer Sample";
			InitializeComponent();
			
			pageNumberEntry.Completed += pageNumberEntry_Completed;
			pageNumberEntry.Focused += pageNumberEntry_Focused;
			pdfViewerControl.PageChanged += PdfViewerControl_PageChanged;
			pdfViewerControl.DocumentLoaded += PdfViewerControl_DocumentLoaded;
			goToNextButton.Clicked += goToNextButton_Clicked;
			goToPreviousButton.Clicked += goToPreviousButton_Clicked;
			toolbar.IsVisible = true;
			searchBar.IsVisible = false;
			searchButton.Clicked += OnSearchIconClicked;
			backIcon.Clicked += OnBackIconClicked;
			textSearchEntry.PlaceholderColor = Color.FromRgb(189, 189, 189);
			textSearchEntry.TextColor = Color.FromRgb(103, 103, 103);
			textSearchEntry.HorizontalTextAlignment = TextAlignment.Start;
			textSearchEntry.Placeholder = "Search Text";
			//toolbar.WidthRequest = Application.Current.MainPage.Width;
			//searchBar.WidthRequest = Application.Current.MainPage.Width;
			textSearchEntry.TextChanged += TextField_TextChanged;
			textSearchEntry.Completed += TextSearchEntry_Completed;
			showFileBtn.Clicked += ShowFileBtn_Clicked;
			pdfViewerControl.SearchCompleted += PdfViewerControl_SearchCompleted;
			documentBackup = "Anti-BullyingPolicy";
			documentIndex = 1;
			pdfViewerControl.InputFileStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("AlphaThea.Content." + documentBackup + ".pdf");
			picker = new Picker();
			this.picker.Items.Add("Anti-BullyingPolicy");
			this.picker.Items.Add("FirstAidPolicy");
			this.picker.Items.Add("HarassmentandBullyingPolicy");
			this.picker.SelectedIndexChanged += Picker_SelectedIndexChanged;

			if (Device.RuntimePlatform != Device.Windows)
			{
				popupLayout.WidthRequest = 0;
				popupLayout.HeightRequest = 0;
				popupLayout.HorizontalOptions = LayoutOptions.Start;
				popupLayout.VerticalOptions = LayoutOptions.Start;
				popupLayout.BackgroundColor = Color.FromHex("#E9E9E9");
				popupLayout.Children.Add(picker);
				picker.Focus();
				picker.Unfocused += Picker_Unfocused;
				popupLayout.IsVisible = false;
				mainGrid.Children.Add(popupLayout, 0, 0);
			}
			else
			{
				DocumentsList = new List<Document> { new Document("Anti-BullyingPolicy"), new Document("FirstAidPolicy"), new Document("HarassmentandBullyingPolicy") };
				var filesDataTemplate = new DataTemplate(() =>
				{
					var grid = new Grid();
					var fileNameLabel = new Label { TextColor = Color.Black, FontSize = 18, Margin = new Thickness(10, 10) };
					fileNameLabel.SetBinding(Label.TextProperty, "FileName");
					grid.Children.Add(fileNameLabel);
					return new ViewCell { View = grid };
				});

				ListView fileListView = new ListView { ItemsSource = DocumentsList, ItemTemplate = filesDataTemplate };
				fileListView.ItemSelected += FileListView_ItemSelected;
				fileListView.BindingContext = this;
				popupLayout.WidthRequest = 280;
				popupLayout.HeightRequest = 180;
				popupLayout.HorizontalOptions = LayoutOptions.Start;
				popupLayout.VerticalOptions = LayoutOptions.Start;
				popupLayout.BackgroundColor = Color.FromHex("#E9E9E9");
				popupLayout.Children.Add(fileListView);
				popupLayout.IsVisible = false;
				mainGrid.Children.Add(popupLayout, 0, 1);
				TapGestureRecognizer gesture = new TapGestureRecognizer();
				gesture.Tapped += gesture_Tapped;
				pdfViewGrid.GestureRecognizers.Add(gesture);
			}

		}

		private void pageNumberEntry_Focused(object sender, FocusEventArgs e)
		{
			if (Device.RuntimePlatform == Device.Windows)
			{
				popupLayout.IsVisible = false;
			}
		}

		private void gesture_Tapped(object sender, EventArgs e)
		{
			if (Device.RuntimePlatform == Device.Windows)
			{
				popupLayout.IsVisible = false;
			}
		}

		private void Picker_Unfocused(object sender, FocusEventArgs e)
		{
			popupLayout.IsVisible = false;
			picker.Unfocus();
		}

		private void Picker_SelectedIndexChanged(object sender, EventArgs e)
		{
			Picker picker = sender as Picker;
			if (picker != null)
			{
				int selectedFileIndex = picker.SelectedIndex;
				if (documentIndex != selectedFileIndex)
				{
					pdfViewerControl.InputFileStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("AlphaThea.Content." + picker.Items[selectedFileIndex] + ".pdf");
                    documentIndex = selectedFileIndex;
				}
			}
		}

		private void FileListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var listView = sender as ListView;
			if (listView != null)
			{
				var selectedDocument = listView.SelectedItem as Document;
				if (selectedDocument != null && selectedDocument.FileName != string.Empty)
				{
					if (documentBackup != selectedDocument.FileName)
					{
						pdfViewerControl.InputFileStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("AlphaThea.Content." + selectedDocument.FileName + ".pdf");
						documentBackup = selectedDocument.FileName;
					}
				}
			}
			popupLayout.IsVisible = false;
		}

		private void ShowFileBtn_Clicked(object sender, EventArgs e)
		{
			if (Device.RuntimePlatform != Device.Windows)
			{
				if (!popupLayout.IsVisible)
				{
					popupLayout.IsVisible = true;
					picker.Focus();
				}
				else
				{
					popupLayout.IsVisible = false;
					picker.Unfocus();
				}
			}
			else
			{
				if (!popupLayout.IsVisible)
				{
					popupLayout.IsVisible = true;
				}
				else
				{
					popupLayout.IsVisible = false;
				}
			}
		}

		#region TextSearch
		private void OnCancelSearchClicked(object sender, EventArgs e)
		{
			cancelSearchButton.IsVisible = false;
			if (!textSearchEntry.IsFocused)
				textSearchEntry.Focus();
			textSearchEntry.Text = "";
			pdfViewerControl.CancelSearch();
			targetText = string.Empty;
		}


		private void TextField_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (Device.RuntimePlatform != Device.Windows)
			{
				if (textSearchEntry.Text != "")
				{
					cancelSearchButton.IsVisible = true;
				}
				else
				{
					cancelSearchButton.IsVisible = false;
				}
			}
			if (textSearchEntry.Text == "")
			{
				pdfViewerControl.CancelSearch();
				targetText = string.Empty;
			}
		}

		private void TextSearchEntry_Completed(object sender, EventArgs e)
		{
			if (targetText != textSearchEntry.Text)
			{
				pdfViewerControl.SearchText(textSearchEntry.Text);
				targetText = textSearchEntry.Text;
			}
		}


		private void PdfViewerControl_SearchCompleted(object sender, TextSearchEventArgs args)
		{
			if (args.NoMatchFound)
			{
				if (Device.RuntimePlatform != Device.iOS)
					page.DisplayAlert("Message", "No match found", "OK");
				else
					DependencyService.Get<IAlertView>().Show("Message", "No match found");
			}
		}

		private void OnSearchIconClicked(object sender, EventArgs e)
		{
			if (Device.RuntimePlatform == Device.Windows)
			{
				popupLayout.IsVisible = false;
			}
			toolbar.IsVisible = false;
			searchBar.IsVisible = true;
			textSearchEntry.Focus();
			cancelSearchButton.IsVisible = false;

		}

		private void OnBackIconClicked(object sender, EventArgs e)
		{
			toolbar.IsVisible = true;
			searchBar.IsVisible = false;
			textSearchEntry.Text = "";
			pdfViewerControl.CancelSearch();

		}
		#endregion

		private void PdfViewerControl_PageChanged(object sender, PageChangedEventArgs e)
		{
			if (Device.RuntimePlatform == Device.Windows)
			{
				popupLayout.IsVisible = false;
			}
			pageNumberEntry.Text = e.PageNumber.ToString();
		}

		private void PdfViewerControl_DocumentLoaded(object sender, EventArgs e)
		{
			if (Device.RuntimePlatform == Device.Windows)
			{
				popupLayout.IsVisible = false;
			}
			pageCountLabel.Text = pdfViewerControl.PageCount.ToString();
			pageNumberEntry.Text = pdfViewerControl.PageNumber.ToString();
		}

		private void goToPreviousButton_Clicked(object sender, EventArgs e)
		{
			if (Device.RuntimePlatform == Device.Windows)
			{
				popupLayout.IsVisible = false;
			}
			if (pdfViewerControl.PageNumber > 1)
				pdfViewerControl.GoToPreviousPage();
		}

		private void goToNextButton_Clicked(object sender, EventArgs e)
		{
			if (Device.RuntimePlatform == Device.Windows)
			{
				popupLayout.IsVisible = false;
			}
			if (pdfViewerControl.PageNumber < pdfViewerControl.PageCount)
				pdfViewerControl.GoToNextPage();
		}

		private void pageNumberEntry_Completed(object sender, EventArgs e)
		{
			if (Device.RuntimePlatform == Device.Windows)
			{
				popupLayout.IsVisible = false;
			}
			int pageNumber = 1;
			if (int.TryParse(((sender as Entry).Text), NumberStyles.Integer, CultureInfo.InvariantCulture, out pageNumber))
			{
				if ((sender as Entry) != null && pageNumber > 0 && pageNumber <= pdfViewerControl.PageCount)
					pdfViewerControl.GoToPage(int.Parse((sender as Entry).Text));
				else
				{
					if (Device.RuntimePlatform != Device.iOS)
						page.DisplayAlert("Error", "Please enter the valid page number.", "OK");
					else
						DependencyService.Get<IAlertView>().Show("Error", "Please enter the valid page number.");
					(sender as Entry).Text = pdfViewerControl.PageNumber.ToString();
				}
			}
			else
			{
				if (Device.RuntimePlatform != Device.iOS)
					page.DisplayAlert("Error", "Please enter the valid page number.", "OK");
				else
					DependencyService.Get<IAlertView>().Show("Error", "Please enter the valid page number.");
				(sender as Entry).Text = pdfViewerControl.PageNumber.ToString();
			}
		}


		protected override void OnAppearing()
		{

			toolbar.WidthRequest = Application.Current.MainPage.Width;
			searchBar.WidthRequest = Application.Current.MainPage.Width;

		}


	}

	public class Document
	{
		public string FileName { get; private set; }

		public Document(string fileName)
		{
			FileName = fileName;
		}

	}

	
}

