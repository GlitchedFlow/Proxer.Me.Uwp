using System;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class FSKToImageConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			return $"ms-appx:///Assets/Proxer/PSK/{value}.png";
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return null;
		}
	}
}