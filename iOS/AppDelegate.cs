using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Syncfusion.SfDataGrid.XForms.iOS;
using Syncfusion.SfPdfViewer.XForms.iOS;
using UIKit;

namespace AlphaThea.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {

        //public static Xuni.Forms.FlexPie.Platform.iOS.FlexPieRenderer pieDummy;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            Xuni.Forms.FlexPie.Platform.iOS.Forms.Init();



            LoadApplication(new App());

            //C1.Xamarin.Forms.Grid.Platform.iOS.FlexGridRenderer.Init();
            SfDataGridRenderer.Init();

            new Syncfusion.SfChart.XForms.iOS.Renderers.SfChartRenderer();
            new SfPdfDocumentViewRenderer();

			return base.FinishedLaunching(app, options);
        }
    }
}
