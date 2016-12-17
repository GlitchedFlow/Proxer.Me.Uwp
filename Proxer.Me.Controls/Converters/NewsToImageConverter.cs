using System;
using Proxer.Me.Support.Api.Data.Notification;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class NewsToImageConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			News _data = (News)value;
			if (_data == null)
				return null;
			return "http://cdn.proxer.me/news/" + _data.NID + "_" + _data.ImageID + ".png";
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}