using System;
using Syncfusion.SfDataGrid.XForms;
using Xamarin.Forms;

namespace AlphaThea.CustomStyles
{
    public class Blue : DataGridStyle
    {
		public override Color GetHeaderBackgroundColor()
		{
			//return Color.FromRgb(242, 242, 242);
            return Color.FromRgb(19, 52, 76);
		}

		//I added
		public override Color GetHeaderForegroundColor()
		{
			return Color.FromRgb(222, 228, 232);
		}

        //I added
		public override Color GetRecordBackgroundColor()
		{
			return Color.FromRgb(66, 209, 244);
		}

        public override Color GetSelectionBackgroundColor()
		{
			return Color.FromRgb(72, 173, 170);
		}

		public override Color GetSelectionForegroundColor()
		{
			return Color.FromRgb(255, 255, 255);
		}

		public override Color GetCaptionSummaryRowBackgroundColor()
		{
			return Color.FromRgb(224, 224, 224);
		}

		public override Color GetCaptionSummaryRowForeGroundColor()
		{
			return Color.FromRgb(51, 51, 51);
		}

		public override Color GetBordercolor()
		{
			return Color.FromRgb(180, 180, 180);
		}

		public override Color GetAlternatingRowBackgroundColor()
		{
			return Color.FromRgb(230, 239, 237);
		}
    }
}
