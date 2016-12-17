using System;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class UnixTimeStampConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
			dtDateTime = dtDateTime.AddSeconds(System.Convert.ToDouble((int)value)).ToLocalTime();
			return (dtDateTime.Day < 10 ? "0" : "") + dtDateTime.Day + "." + (dtDateTime.Month < 10 ? "0" : "") + dtDateTime.Month + "." + dtDateTime.Year;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return null;
		}
	}
}