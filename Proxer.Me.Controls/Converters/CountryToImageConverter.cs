using System;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class CountryToImageConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			string country = (string)value;
			if (country != null)
			{
				string image = "";
				switch (country)
				{
					case "de":
						image = "german";
						break;

					case "us":
						image = "english";
						break;

					default:
						image = "japanese";
						break;
				}
				return $"ms-appx:///Assets/Proxer/Flags/{image}.gif";
			}
			return "";
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return null;
		}
	}
}