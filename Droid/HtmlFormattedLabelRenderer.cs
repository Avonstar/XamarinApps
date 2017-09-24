using System;
using AlphaThea.CustomControls;
using AlphaThea.Droid;
using Android.Text;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(HtmlFormattedLabel), typeof(HtmlFormattedLabelRenderer))]
namespace AlphaThea.Droid
{
    public class HtmlFormattedLabelRenderer : LabelRenderer
    {
		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);

			var view = (HtmlFormattedLabel)Element;
			if (view == null) return;

			Control.SetText(Html.FromHtml(view.Text.ToString()), TextView.BufferType.Spannable);
		}
    }
}
