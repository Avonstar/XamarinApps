using System;
using System.IO;
using System.Net;
using AlphaThea.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using AlphaThea.CustomControls;

[assembly: ExportRenderer(typeof(CustomWebView), typeof(CustomWebViewRenderer))]
namespace AlphaThea.iOS
{
	public class CustomWebViewRenderer : ViewRenderer<CustomWebView, UIWebView>
	{
		protected override void OnElementChanged(ElementChangedEventArgs<CustomWebView> e)
		{
			base.OnElementChanged(e);

			if (Control == null)
			{
				SetNativeControl(new UIWebView());
			}
			if (e.OldElement != null)
			{
				// Cleanup
			}
			if (e.NewElement != null)
			{
				var customWebView = Element as CustomWebView;

                //Use this in dev - REMEMBER TO REMOVE
                string fileName = customWebView.Uri;

                //This is probably the deployed path
				//string fileName = Path.Combine(NSBundle.MainBundle.BundlePath, string.Format("Content/{0}", WebUtility.UrlEncode(customWebView.Uri)));
				

                Control.LoadRequest(new NSUrlRequest(new NSUrl(fileName, false)));
				Control.ScalesPageToFit = true;
			}
		}
	}
}
