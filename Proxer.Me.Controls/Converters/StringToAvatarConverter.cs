using System;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class StringToAvatarConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
				return $"ms-appx:///Assets/Proxer/Misc/nophoto.png";
			return $"https://cdn.proxer.me/avatar/{value}";
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return null;
		}
	}
}