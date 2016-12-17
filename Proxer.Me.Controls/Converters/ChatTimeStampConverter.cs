using System;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class ChatTimeStampConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (value == null)
			{
				return null;
			}
			System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
			dtDateTime = dtDateTime.AddSeconds(System.Convert.ToDouble((int)value)).ToLocalTime();
			if (dtDateTime.Year == DateTime.Now.Year)
			{
				if (dtDateTime.Month == DateTime.Now.Month && dtDateTime.Day == DateTime.Now.Day)
				{
					return dtDateTime.ToString("HH:mm");
				}
				else if (dtDateTime.Month == DateTime.Now.Month && dtDateTime.Day < DateTime.Now.Day && dtDateTime.Day >= DateTime.Now.Day - 6)
				{
					return dtDateTime.ToString("ddd");
				}
				else
				{
					return dtDateTime.ToString("dd.MM");
				}
			}
			else
			{
				return dtDateTime.ToString("dd.MM.yyyy");
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return null;
		}
	}
}