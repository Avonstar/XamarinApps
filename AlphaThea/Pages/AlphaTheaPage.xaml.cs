using Xamarin.Forms;
using AlphaThea.Models;
using System;
using System.Collections.Generic;
using Xuni.Forms.FlexPie;

namespace AlphaThea.Pages
{
    public partial class AlphaTheaPage : TabbedPage
    {

        public AlphaTheaPage()
        {
            InitializeComponent();

			Xuni.Forms.Core.LicenseManager.Key = License.Key;

			//List<AttendancePieEntity> attendancePie = new List<AttendancePieEntity>();

			//attendancePie.Add(new AttendancePieEntity("Late (am)", 67));
			//attendancePie.Add(new AttendancePieEntity("Absent (am)", 12));
			//attendancePie.Add(new AttendancePieEntity("Absent (pm)", 12));

			//pieChart.ItemsSource = attendancePie;



        }

    }
}
