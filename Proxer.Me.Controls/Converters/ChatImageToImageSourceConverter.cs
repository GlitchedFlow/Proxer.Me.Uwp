using System;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class ChatImageToImageSourceConverter : IValueConverter
	{
		private const string fallback = "ms-appx:///Assets/LockScreenLogo.scale-400.png";

		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (value == null)
				return fallback;

			if (value.ToString() == "")
				return fallback;

			string[] infos = value.ToString().Split(':');
			if (infos[0] == "avatar")
			{
				return $"http://cdn.proxer.me/avatar/tn/{infos[1]}";
			}
			return fallback;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return null;
		}
	}
}