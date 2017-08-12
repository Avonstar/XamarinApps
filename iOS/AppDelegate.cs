
using Foundation;
using Syncfusion.SfDataGrid.XForms.iOS;
using Syncfusion.SfPdfViewer.XForms.iOS;
using UIKit;

namespace AlphaThea.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {

			new Syncfusion.SfChart.XForms.iOS.Renderers.SfChartRenderer();
			new Syncfusion.SfAutoComplete.XForms.iOS.SfAutoCompleteRenderer();
			new SfPdfDocumentViewRenderer();

            global::Xamarin.Forms.Forms.Init();

            SfDataGridRenderer.Init();

            LoadApplication(new App());

			return base.FinishedLaunching(app, options);
        }
    }
}
