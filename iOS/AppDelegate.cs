
using Foundation;
using Syncfusion.SfDataGrid.XForms.iOS;
using Syncfusion.SfPdfViewer.XForms.iOS;
using Syncfusion.SfAutoComplete.XForms.iOS;
using Syncfusion.SfChart.XForms.iOS.Renderers;
using Syncfusion.SfBusyIndicator.XForms.iOS;
using UIKit;
using Syncfusion.ListView.XForms.iOS;

namespace AlphaThea.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {

            global::Xamarin.Forms.Forms.Init();

            LoadApplication(new App());

            SfChartRenderer.Init();
            SfDataGridRenderer.Init();
            SfListViewRenderer.Init();

            new HtmlFormattedLabelRenderer();
			new SfChartRenderer();
			new SfAutoCompleteRenderer();
			new SfPdfDocumentViewRenderer();
            new SfBusyIndicatorRenderer();

			return base.FinishedLaunching(app, options);
        }
    }
}
