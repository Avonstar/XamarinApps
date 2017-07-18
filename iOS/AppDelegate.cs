
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
            global::Xamarin.Forms.Forms.Init();

            LoadApplication(new App());

            SfDataGridRenderer.Init();

            new Syncfusion.SfChart.XForms.iOS.Renderers.SfChartRenderer();
            new SfPdfDocumentViewRenderer();

			return base.FinishedLaunching(app, options);
        }
    }
}
