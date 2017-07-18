using System;
using Xamarin.Forms;
using Syncfusion.SfDataGrid.XForms;

namespace AlphaThea.CustomStyles
{
	public class Green : DataGridStyle
	{
		public Green()
		{
		}

		public override Color GetHeaderBackgroundColor()
		{
			return Color.FromRgb(242, 242, 242);
		}

		public override Color GetSelectionBackgroundColor()
		{
			return Color.FromRgb(123, 149, 52);
		}

        //I added
		public override Color GetRecordBackgroundColor()
		{
			return Color.FromRgb(123, 149, 52);
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
			return Color.FromRgb(248, 249, 229);
		}
	}
}
