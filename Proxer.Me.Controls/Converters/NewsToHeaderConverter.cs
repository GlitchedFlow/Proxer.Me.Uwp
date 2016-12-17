using System;
using Proxer.Me.Support.Api.Data.Notification;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class NewsToHeaderConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (value == null)
			{
				return "";
			}

			News newsValue = (News)value;
			return string.Format("{0} - Autor: {1} - {2} Kommentare - {3} Zugriffe", new DateTime(1970, 1, 1).AddSeconds(System.Convert.ToDouble(newsValue.Time)).ToString("dd.MM.yyyy HH:mm"),
																					 newsValue.Username,
																					 newsValue.Posts,
																					 newsValue.Hits);
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return null;
		}
	}
}