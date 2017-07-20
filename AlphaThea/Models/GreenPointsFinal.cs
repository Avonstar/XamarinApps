#region Copyright Softray. 2017-2018
//The final Green Points should include an image source derived from the actual green points attained
#endregion

using System;
using Xamarin.Forms;


namespace AlphaThea.Models
{
    public class GreenPointsFinal
    {
		public DateTime Created { get; set; }
		public string AwardedBy { get; set; }
		public string Description { get; set; }
		public ImageSource GreenPointsImage { get; set; }
    }
}
